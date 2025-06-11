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

namespace GUI
{
    public partial class GUIRegistrarCliente : Form, IObserver
    {
        List<Label> listaLabels;
        BLLCliente bllCliente = new BLLCliente();
        bool isHabilitado = false;
        int opcion = 0;
        public GUIRegistrarCliente(int pOpcion = 0)
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
                    if (bllCliente.ExisteCliente(TxtDNI.Text)) throw new Exception(Traductor.INSTANCIA.Traducir("Cliente ya registrado", ""));
                    BECliente cliente = new BECliente(TxtDNI.Text, TxtCorreo.Text, TxtNombre.Text, comboBox1.SelectedItem.ToString(), true, TxtTelefono.Text);
                    bllCliente.Agregar(cliente);
                    Mostrar(DgvClientes, LinqClientes(RbActivos.Checked));
                    MessageBox.Show(Traductor.INSTANCIA.Traducir("Cliente registrado exitosamente", ""), Traductor.INSTANCIA.Traducir("Operación exitosa", ""), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles();
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
            comboBox1.Items.Add(Traductor.INSTANCIA.Traducir("Responsable inscripto", ""));
            comboBox1.Items.Add(Traductor.INSTANCIA.Traducir("Monotributista", ""));
            comboBox1.Items.Add(Traductor.INSTANCIA.Traducir("Exento de IVA", ""));
            comboBox1.Items.Add(Traductor.INSTANCIA.Traducir("No responsable", ""));
        }

        private void BtnCambiarEstadoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvClientes.SelectedRows.Count == 0) throw new Exception(Traductor.INSTANCIA.Traducir("Debe seleccionar un cliente", ""));
                bllCliente.CambiarEstado(bllCliente.ListaClientes().Find(x => x.dni == DgvClientes.SelectedRows[0].Cells[0].Value.ToString()));
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
                }
                
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, Traductor.INSTANCIA.Traducir("Advertencia", ""), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); }
        }

        private void DgvClientes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtDNI.Text = DgvClientes.SelectedRows[0].Cells[0].Value.ToString();
            TxtDNI.Enabled = false;
            TxtCorreo.Text = DgvClientes.SelectedRows[0].Cells[1].Value.ToString();
            TxtNombre.Text = DgvClientes.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.SelectedItem = DgvClientes.SelectedRows[0].Cells[3].Value.ToString();
            TxtTelefono.Text = DgvClientes.SelectedRows[0].Cells[4].Value.ToString();
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
    }
}
