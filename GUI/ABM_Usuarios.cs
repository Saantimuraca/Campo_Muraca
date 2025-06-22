using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicios;
using System.Text.RegularExpressions;
using Servicios.Logica;
using Servicios.Entidades;

namespace GUI
{
    public partial class ABM_Usuarios : Form, IObserver
    {
        LogicaUsuario bllUsuario = new LogicaUsuario();
        GestorPermisos gp = new GestorPermisos();
        ServicioMail mail = new ServicioMail();
        Sesion Sesion = Sesion.INSTANCIA;
        LogicaBitacora bitacora = new LogicaBitacora();
        Traductor traductor = Traductor.INSTANCIA;
        List<Label> listaLabels = new List<Label>();

        public ABM_Usuarios()
        {
            InitializeComponent();
            Mostrar(DgvUsuarios, LinqUsuarios());
            TraducirDgv();
            CargarRoles();
            CargarIdiomas();
            mail.EmailEnviado += MensajeMailEnviado;
            traductor.Suscribir(this);
            traductor.Notificar();
            EnlistarLabels();
            OcultarLabels();
        }

        private void EnlistarLabels()
        {
            foreach(Control c in this.Controls)
            {
                if(c is  Label && c.Name.StartsWith("Error"))
                {
                    listaLabels.Add((Label)c);
                }
            }
        }

        private void OcultarLabels()
        {
            foreach(Label L in listaLabels)
            {
                L.Visible = false;
            }
        }

        private void CargarIdiomas()
        {
            LogicaIdioma bllIdioma = new LogicaIdioma();
            foreach(EntidadIdioma idioma in bllIdioma.ListaIdiomas())
            {
                CbIdioma.Items.Add(idioma.idioma); 
            }
        }

        private void BtnAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                bool isVisible = false;
                foreach (Label l in listaLabels)
                {
                    if (l.Visible) { isVisible = true; }
                }
                if(!isVisible)
                {
                    if (!Information.IsDate(TxtFechaNacimiento.Text)) throw new Exception(traductor.Traducir("Fecha invalida!!!", Sesion.ObtenerIdiomaSesion()));
                    if (CbRol.SelectedItem == null) throw new Exception(traductor.Traducir("Debe seleccionar un rol para el usuario!!!", Sesion.ObtenerIdiomaSesion()));
                    if (CbIdioma.SelectedItem == null) throw new Exception(traductor.Traducir("Debe seleccionar un idioma para el usuario!!!", Sesion.ObtenerIdiomaSesion()));
                    bllUsuario.AgregarUsuario(bllUsuario.CrearUsuario(TxtDNIUsuario.Text, TxtNombreUsuario.Text, TxtMail.Text, TxtFechaNacimiento.Text, TxtTelefonoUsuario.Text, CbRol.SelectedItem.ToString(), CbIdioma.SelectedItem.ToString(), 0));
                    Mostrar(DgvUsuarios, LinqUsuarios());
                    TraducirDgv();
                    string destinatario = TxtMail.Text;
                    EntidadUsuario usuarioCreado = bllUsuario.ListaUsuarios().Find(x => x.Dni_Usuario == TxtDNIUsuario.Text);
                    string asunto = traductor.Traducir("Registro exitoso!!!", Sesion.ObtenerIdiomaSesion());
                    string usuario = usuarioCreado.Nombre_Usuario;
                    string plantilla = traductor.Traducir("Mensaje mail", Sesion.ObtenerIdiomaSesion());
                    string cuerpo = plantilla.Replace("{usuario}", usuario);
                    string emailOrigen = "saantimuraca12@gmail.com";
                    string contraseña = "sdrjuqddpkdzwsph";
                    string[] vectorMail = TxtMail.Text.Split('@');
                    MessageBox.Show(traductor.Traducir("Usuario creado exitosamente!!!", Sesion.ObtenerIdiomaSesion()));
                    if (vectorMail[1].ToLower() == "gmail.com")
                    {
                        mail.EnviarCorreo(destinatario, asunto, cuerpo, emailOrigen, contraseña);
                    }
                    RefrescarControles();
                    bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.ObtenerUsuarioActual(), "Agregar usuario"));
                }
                
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void Mostrar(DataGridView dgv, object obj)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
        }

        public object LinqUsuarios()
        {
            return (from u in bllUsuario.ListaUsuarios() select new {USUARIO = u.Nombre_Usuario, MAIL = u.Mail_Usuario, EDAD = u.Edad_Usuario, TELEFONO = u.Telefono_Usuario, ESTADO = u.Estado_Usuario == true ? "Activo":"Bloqueado", ROL = u.Rol.DevolverNombrePermiso()}).ToList();
        }

        public void TraducirDgv()
        {
            Traductor traductor = Traductor.INSTANCIA;
            DgvUsuarios.Columns[0].HeaderText = traductor.Traducir("USUARIO", Sesion.ObtenerIdiomaSesion());
            DgvUsuarios.Columns[1].HeaderText = traductor.Traducir("MAIL", Sesion.ObtenerIdiomaSesion());
            DgvUsuarios.Columns[2].HeaderText = traductor.Traducir("EDAD", Sesion.ObtenerIdiomaSesion());
            DgvUsuarios.Columns[3].HeaderText = traductor.Traducir("TELEFONO", Sesion.ObtenerIdiomaSesion());
            DgvUsuarios.Columns[4].HeaderText = traductor.Traducir("ESTADO", Sesion.ObtenerIdiomaSesion());
            DgvUsuarios.Columns[5].HeaderText = traductor.Traducir("ROL", Sesion.ObtenerIdiomaSesion());
        }

        public void CargarRoles()
        {
            CbRol.SelectedIndex = -1;
            CbRol.SelectedItem = null;
            CbRol.Items.Clear();
            foreach (EntidadPermisoCompuesto rol in gp.ObtenerPermisos("Roles"))
            {
                if(rol.DevolverNombrePermiso() != "Administrador") CbRol.Items.Add(rol.DevolverNombrePermiso());
            }
        }

        private void MensajeMailEnviado(object sender, EventArgs e)
        {
            MessageBox.Show(traductor.Traducir("Se ha enviado un mail informando del alta al usuario!!!", Sesion.ObtenerIdiomaSesion()));
        }

        private void BtnHabilitarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvUsuarios.SelectedRows.Count == 0) throw new Exception(traductor.Traducir("Debe seleccionar un usuario!!!", Sesion.ObtenerIdiomaSesion()));
                bllUsuario.HabilitarUsuario(DgvUsuarios.SelectedRows[0].Cells[0].Value.ToString());
                Mostrar(DgvUsuarios, LinqUsuarios());
                TraducirDgv();
                RefrescarControles();
                bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.ObtenerUsuarioActual(), "Habilitar usuario"));
            }
            catch (Exception ex) {MessageBox.Show(ex.Message); }    
        }

        private void BtnBajaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvUsuarios.SelectedRows.Count == 0) throw new Exception(traductor.Traducir("Debe seleccionar un usuario!!!", Sesion.ObtenerIdiomaSesion()));
                bllUsuario.BloquearUsuario(DgvUsuarios.SelectedRows[0].Cells[0].Value.ToString());
                Mostrar(DgvUsuarios, LinqUsuarios());
                TraducirDgv();
                RefrescarControles();
                bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.ObtenerUsuarioActual(), "Baja usuario"));
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnModificarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvUsuarios.SelectedRows.Count == 0) throw new Exception(traductor.Traducir("Debe seleccionar un usuario!!!", Sesion.ObtenerIdiomaSesion()));
                string nuevoNombreUsuario = TxtNombreUsuario.Text;
                string nuevoMailUsuario = TxtMail.Text;
                string nuevafechaNacimiento = TxtFechaNacimiento.Text;
                if (!Information.IsDate(nuevafechaNacimiento)) throw new Exception(traductor.Traducir("La fecha de nacimiento es invalida!!!", Sesion.ObtenerIdiomaSesion()));
                string nuevoTelefonoUsuario = TxtTelefonoUsuario.Text;
                EntidadUsuario usuarioSeleccionado = bllUsuario.ListaUsuarios().Find(x => x.Nombre_Usuario == DgvUsuarios.SelectedRows[0].Cells[0].Value.ToString());
                bllUsuario.ModificarUsuario(bllUsuario.CrearUsuario(usuarioSeleccionado.Dni_Usuario, nuevoNombreUsuario, nuevoMailUsuario, nuevafechaNacimiento, nuevoTelefonoUsuario, CbRol.SelectedItem.ToString(), CbIdioma.SelectedItem.ToString(), 1));
                Mostrar(DgvUsuarios, LinqUsuarios());
                TraducirDgv();
                RefrescarControles();
                bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.ObtenerUsuarioActual(), "Modificar Usuario"));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void RefrescarControles()
        {
            TxtDNIUsuario.Text = "";
            TxtNombreUsuario.Text = "";
            TxtMail.Text = "";
            TxtFechaNacimiento.Text = "";
            TxtTelefonoUsuario.Text = "";
            CargarRoles();
            TxtDNIUsuario.Enabled = true;
            CbIdioma.Enabled = true;
            CbIdioma.SelectedIndex = -1;
            CbIdioma.SelectedItem = null;
            DgvUsuarios.ClearSelection();
        }

        private void DgvUsuarios_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EntidadUsuario usuarioSeleccionado = bllUsuario.ListaUsuarios().Find(x => x.Nombre_Usuario == DgvUsuarios.SelectedRows[0].Cells[0].Value.ToString());
            TxtDNIUsuario.Text = usuarioSeleccionado.Dni_Usuario;
            TxtDNIUsuario.Enabled = false;
            TxtNombreUsuario.Text = usuarioSeleccionado.Nombre_Usuario;
            TxtMail.Text = usuarioSeleccionado.Mail_Usuario;
            TxtFechaNacimiento.Text = usuarioSeleccionado.Fecha_Nacimiento_Usuario.ToShortDateString();
            TxtTelefonoUsuario.Text = usuarioSeleccionado.Telefono_Usuario;
            int index = CbRol.FindStringExact(usuarioSeleccionado.Rol.DevolverNombrePermiso());
            CbRol.SelectedIndex = index;
            int index2 = CbIdioma.FindStringExact(usuarioSeleccionado.Idioma);
            CbIdioma.SelectedIndex = index2;
            CbIdioma.Enabled = false;
        }

        private void BtnEliminarSeleccion_Click(object sender, EventArgs e)
        {
            RefrescarControles();
        }

        public void ActualizarLenguaje()
        {
            Traductor traductor = Traductor.INSTANCIA;
            foreach (Control ctrl in this.Controls)
            {
                if(ctrl is Label || ctrl is Button)
                {
                    ctrl.Text = traductor.Traducir(ctrl.Name, Sesion.ObtenerIdiomaSesion());
                }
            }
        }
        private void ABM_Usuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["Menu"].Show();
        }

        private void TxtDNIUsuario_Leave(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^\d{7,8}$");
            if (!r.IsMatch(TxtDNIUsuario.Text)) { ErrorDNI.Visible = true; }

        }

        private void TxtDNIUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            ErrorDNI.Visible = false;
        }

        private void TxtNombreUsuario_Leave(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(TxtNombreUsuario.Text)) { ErrorNombre.Visible = true; }
        }

        private void TxtNombreUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            ErrorNombre.Visible = false;
        }

        private void TxtMail_Leave(object sender, EventArgs e)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if(!Regex.IsMatch(TxtMail.Text, patron)) { ErrorCorreo.Visible = true; }
            
        }

        private void TxtMail_KeyUp(object sender, KeyEventArgs e)
        {
            ErrorCorreo.Visible = false;
        }

        private void TxtFechaNacimiento_Leave(object sender, EventArgs e)
        {
            string patron = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$";
            if(!Regex.IsMatch(TxtFechaNacimiento.Text, patron)) { ErrorFecha.Visible = true; }
            
        }

        private void TxtFechaNacimiento_KeyUp(object sender, KeyEventArgs e)
        {
            ErrorFecha.Visible = false;
        }

        private void TxtTelefonoUsuario_Leave(object sender, EventArgs e)
        {
            string patron = @"^\d{10}$";
            if(!Regex.IsMatch(TxtTelefonoUsuario.Text, patron)) { ErrorTelefono.Visible = true; }
        }

        private void TxtTelefonoUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            ErrorTelefono.Visible = false;
        }

        private void CbRol_Leave(object sender, EventArgs e)
        {
            if(CbRol.SelectedItem == null) { ErrorRol.Visible = true; }
        }

        private void CbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorRol.Visible = false;
        }

        private void CbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorIdioma.Visible = false;
        }

        private void CbIdioma_Leave(object sender, EventArgs e)
        {
            if(CbIdioma.SelectedItem == null) { ErrorIdioma.Visible=true; }
        }

        private void TxtDNIUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
