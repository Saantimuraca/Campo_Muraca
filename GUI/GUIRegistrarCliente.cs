using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Servicios;
using Servicios.Logica;

namespace GUI
{
    public partial class GUIRegistrarCliente : Form, IObserver
    {
        List<Label> listaLabels;
        BLLCliente bllCliente = new BLLCliente();
        bool isHabilitado = false;
        int opcion = 0;
        GUIRegistrarPedido form;
        ServicioMail mail = new ServicioMail();
        GestorPermisos gp = new GestorPermisos();
        LogicaBitacora bitacora = new LogicaBitacora();
        public GUIRegistrarCliente(int pOpcion = 0, GUIRegistrarPedido pForm = null)
        {
            InitializeComponent();
            Traductor.INSTANCIA.Suscribir(this);
            Traductor.INSTANCIA.Notificar();
            listaLabels = new List<Label>();
            ErrorCorreo.Visible = false;
            ErrorIVA.Visible = false;
            ErrorNombre.Visible = false;
            ErrorTelefono.Visible = false;
            ErrorDNI.Visible = false;
            LlenarLista();
            RbActivos.Checked = true;
            Mostrar(DgvClientes, LinqClientes(RbActivos.Checked));
            CargarCB();
            DgvClientes.Focus();
            opcion = pOpcion;
            form = pForm;
            ChequearAccesibilidadControles();
            BtnSerializar.Enabled = false;
        }

        private void ChequearAccesibilidadControles()
        {
            ChequearAccesibilidadRescursiva(this.Controls);
        }

        private void ChequearAccesibilidadRescursiva(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                ChequearAccesibilidad(ctrl);
                if (ctrl.HasChildren) { ChequearAccesibilidadRescursiva(ctrl.Controls); }
            }
        }

        private void ChequearAccesibilidad(Control ctrl)
        {
            ctrl.Enabled = gp.Configurar_Control(ctrl.Tag?.ToString());
        }

        private void Mostrar(DataGridView dgv, object obj)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
            dgv.Columns[1].HeaderText = Traductor.INSTANCIA.Traducir("Correo electrónico", "");
            dgv.Columns[2].HeaderText = Traductor.INSTANCIA.Traducir("Nombre completo", "");
            dgv.Columns[3].HeaderText = Traductor.INSTANCIA.Traducir("Condición de IVA", "");
            dgv.Columns[4].HeaderText = Traductor.INSTANCIA.Traducir("Teléfono", "");
        }

        private object LinqClientes(bool pEstado)
        {
            return (from c in bllCliente.ListaClientes() where c.isActivo == pEstado select new {DNI = c.dni, MAIL = c.mail, NOMBRE = c.nombre, IVA = c.condicionIVA, Teléfono = c.telefono}).ToList();
        }

        private void TxtNombre_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TxtNombre.Text)) { ErrorNombre.Visible = true; }
        }

        private void LlenarLista()
        {
            foreach(Control ctrl in this.Controls)
            {
                if(ctrl is Label && ctrl.Name.StartsWith("Error")) { listaLabels.Add(ctrl as Label); }
            }
        }

        private void TxtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            ErrorNombre.Visible = false;
        }

        private void TxtCorreo_Leave(object sender, EventArgs e)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex rgx = new Regex(patron);
            if (!rgx.IsMatch(TxtCorreo.Text)) { ErrorCorreo.Visible = true; }
        }

        private void TxtCorreo_KeyUp(object sender, KeyEventArgs e)
        {
            ErrorCorreo.Visible = false;
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == null) { ErrorIVA.Visible = true;}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorIVA.Visible = false;
        }

        private void TxtTelefono_Leave(object sender, EventArgs e)
        {
            string patron = @"^11\d{8}$";
            Regex rgx = new Regex(patron);
            if(!rgx.IsMatch(TxtTelefono.Text)) { ErrorTelefono.Visible = true;}
        }

        private void TxtTelefono_KeyUp(object sender, KeyEventArgs e)
        {
            ErrorTelefono.Visible = false;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                EvaluarHabilitación();
                if(isHabilitado)
                {
                    if (bllCliente.ExisteCliente(TxtDNI.Text))
                    {
                        bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.INSTANCIA.ObtenerUsuarioActual(), $"Intentó registrar a un cliente que ya se encontraba en el sistema", 2));
                        throw new Exception(Traductor.INSTANCIA.Traducir("Cliente ya registrado", ""));
                    }
                    BECliente cliente = new BECliente(TxtDNI.Text, TxtCorreo.Text, TxtNombre.Text, comboBox1.SelectedItem.ToString(), true, TxtTelefono.Text);
                    bllCliente.Agregar(cliente);
                    string asunto = "¡Te hemos registrado como cliente en TecnoSoft!";
                    string plantilla = "Hola {cliente},\r\n\r\nQueremos informarte que hemos registrado tus datos en nuestro sistema como nuevo cliente.\r\n\r\nA partir de ahora, vas a poder disfrutar de una atención más personalizada y recibir nuestras novedades, promociones y beneficios.\r\n\r\nDatos registrados:\r\n\r\n📛 Nombre: {nombre}\r\n\r\n📧 Email: {correo}\r\n\r\n📞 Teléfono: {telefono}\r\n\r\n\U0001f9fe Condición frente al IVA: {iva}\r\n\r\nSi alguno de estos datos es incorrecto, por favor comunicate con nosotros para actualizarlo.\r\n\r\n";
                    string cuerpo = plantilla.Replace("{cliente}", cliente.nombre).Replace("{nombre}", cliente.nombre).Replace("{correo}", cliente.mail).Replace("{telefono}", cliente.telefono).Replace("{iva}", cliente.condicionIVA);
                    string mailOrigen = "Saantimuraca12@gmail.com";
                    string contraseña = "sdrjuqddpkdzwsph";
                    string[] vectorMail = cliente.mail.Split('@');
                    if (vectorMail[1].ToLower() == "gmail.com") { mail.EnviarCorreo(cliente.mail, asunto, cuerpo, mailOrigen, contraseña); }
                    Mostrar(DgvClientes, LinqClientes(RbActivos.Checked));
                    MessageBox.Show(Traductor.INSTANCIA.Traducir("Cliente registrado exitosamente", ""), Traductor.INSTANCIA.Traducir("Operación exitosa", ""), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles();
                    bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.INSTANCIA.ObtenerUsuarioActual(), $"Registró al cliente {cliente.dni} {cliente.nombre}", 2));
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, Traductor.INSTANCIA.Traducir("Advertencia", ""), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); }
        }

        private void LimpiarControles()
        {
            TxtDNI.Text = "";
            TxtDNI.Enabled = true;
            TxtCorreo.Text = "";
            TxtNombre.Text = "";
            comboBox1.SelectedItem = null;
            comboBox1.SelectedIndex = -1;
            TxtTelefono.Text = "";
            Mostrar(DgvClientes, LinqClientes(RbActivos.Checked));
        }

        private void EvaluarHabilitación()
        {
            foreach(Label l in listaLabels)
            {
                if(l.Visible)
                {
                    isHabilitado = false;
                    return;
                }
            }
            isHabilitado = true;
        }

        private void TxtDNI_Leave(object sender, EventArgs e)
        {
            string patron = @"^\d{7,8}$";
            Regex rgx = new Regex(patron);
            if(!rgx.IsMatch(TxtDNI.Text)) { ErrorDNI.Visible = true; }
        }

        private void TxtDNI_KeyUp(object sender, KeyEventArgs e)
        {
            ErrorDNI.Visible = false;
        }

        private void CargarCB()
        {
            comboBox1.Items.Add("Responsable inscripto");
            comboBox1.Items.Add("Monotributista");
            comboBox1.Items.Add("Exento de IVA");
            comboBox1.Items.Add("No responsable");
        }

        private void BtnCambiarEstadoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvClientes.SelectedRows.Count == 0) throw new Exception(Traductor.INSTANCIA.Traducir("Debe seleccionar un cliente", ""));
                bllCliente.CambiarEstado(bllCliente.ListaClientes().Find(x => x.dni == DgvClientes.SelectedRows[0].Cells[0].Value.ToString()));
                bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.INSTANCIA.ObtenerUsuarioActual(), $"Deshabilitó al cliente {DgvClientes.SelectedRows[0].Cells[0].Value.ToString()}", 3));
                Mostrar(DgvClientes, LinqClientes(RbActivos.Checked));
                LimpiarControles();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, Traductor.INSTANCIA.Traducir("Advertencia", ""), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvClientes.SelectedRows.Count == 0) throw new Exception(Traductor.INSTANCIA.Traducir("Debe seleccionar un cliente", ""));
                EvaluarHabilitación();
                if(isHabilitado)
                {
                    BECliente cliente = new BECliente(TxtDNI.Text, TxtCorreo.Text, TxtNombre.Text, comboBox1.SelectedItem.ToString(), RbActivos.Checked, TxtTelefono.Text);
                    bllCliente.Modificar(cliente);
                    Mostrar(DgvClientes, LinqClientes(RbActivos.Checked));
                    LimpiarControles();
                    bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.INSTANCIA.ObtenerUsuarioActual(), $"Modificó al cliente {cliente.dni}", 2));
                }
                
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, Traductor.INSTANCIA.Traducir("Advertencia", ""), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); }
        }

        private void DgvClientes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(DgvClientes.SelectedRows.Count > 0)
            {
                TxtDNI.Text = DgvClientes.SelectedRows[0].Cells[0].Value.ToString();
                TxtDNI.Enabled = false;
                TxtCorreo.Text = DgvClientes.SelectedRows[0].Cells[1].Value.ToString();
                TxtNombre.Text = DgvClientes.SelectedRows[0].Cells[2].Value.ToString();
                comboBox1.SelectedItem = DgvClientes.SelectedRows[0].Cells[3].Value.ToString();
                TxtTelefono.Text = DgvClientes.SelectedRows[0].Cells[4].Value.ToString();
                if (DgvClientes.SelectedRows.Count > 0) { BtnSerializar.Enabled = true; }
                else { BtnSerializar.Enabled = false; }
            }
        }

        private void BtnEliminarSeleccion_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void RbActivos_CheckedChanged(object sender, EventArgs e)
        {
            Mostrar(DgvClientes, LinqClientes(true));
            BtnCambiarEstadoCliente.Text = Traductor.INSTANCIA.Traducir("Deshabilitar", "");
        }

        private void RbInactivos_CheckedChanged(object sender, EventArgs e)
        {
            Mostrar(DgvClientes, LinqClientes(false));
            BtnCambiarEstadoCliente.Text = Traductor.INSTANCIA.Traducir("Habilitar", "");
        }

        private void GUIRegistrarCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(opcion == 0) { Application.OpenForms["Menu"].Show(); }
            else { form.CargarClientes(); }
        }

        public void ActualizarLenguaje()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label || ctrl is Button || ctrl is RadioButton)
                {
                    ctrl.Text = Traductor.INSTANCIA.Traducir(ctrl.Name, Sesion.INSTANCIA.ObtenerIdiomaSesion());
                }
            }
        }

        private void BtnSerializar_Click(object sender, EventArgs e)
        {
            try
            {
                List<BECliente> listaClientesAExportar = new List<BECliente>();
                foreach (DataGridViewRow row in DgvClientes.SelectedRows)
                {
                    BECliente cliente = bllCliente.ListaClientes().Find(x => x.dni == row.Cells[0].Value.ToString());
                    listaClientesAExportar.Add(cliente);
                }
                if (listaClientesAExportar.Count == 0) throw new Exception(Traductor.INSTANCIA.Traducir("Debe seleccionar al menos un cliente para exportar", ""));
                string path = bllCliente.Serializar(listaClientesAExportar);
                MessageBox.Show(Traductor.INSTANCIA.Traducir("Clientes exportados exitosamente a la ruta: ", "") + path, Traductor.INSTANCIA.Traducir("Operación exitosa", ""), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex) {  MessageBox.Show(ex.Message, Traductor.INSTANCIA.Traducir("Advertencia", ""), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); }
        }

        private void BtnDeserializar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                ofd.Filter = "Archivos XML (*.xml)|*.xml";
                ofd.Title = "Seleccionar archivo de clientes";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string rutaSeleccionada = ofd.FileName;
                    List<BECliente> listaClientes = Deserializar(rutaSeleccionada);

                }
            catch(Exception ex) { MessageBox.Show(ex.Message, Traductor.INSTANCIA.Traducir("Advertencia", ""), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); }
        }
    }
}
