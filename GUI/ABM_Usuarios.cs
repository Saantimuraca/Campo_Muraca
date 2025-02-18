using BE;
using BLL;
using FluentValidation;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class ABM_Usuarios : Form
    {
        BLL_Usuario bllUsuario = new BLL_Usuario();
        GestorPermisos gp = new GestorPermisos();
        ServicioMail mail = new ServicioMail(); 
        
        public ABM_Usuarios()
        {
            InitializeComponent();
            Mostrar(DgvUsuarios, LinqUsuarios());
            CargarRoles();
            mail.EmailEnviado += MensajeMailEnviado;
        }

        private void BtnAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Information.IsDate(TxtFechaNacimiento.Text)) throw new Exception("Fecha inválida!!!");
                if (CbRol.SelectedItem == null) throw new Exception("Debe seleccionar un rol para el usuario!!!");
                if (CbIdioma.SelectedItem == null) throw new Exception("Debe seleccionar un idioma para el usuario!!!");
                bllUsuario.AgregarUsuario(bllUsuario.CrearUsuario(TxtDNIUsuario.Text, TxtNombreUsuario.Text, TxtMail.Text, TxtFechaNacimiento.Text, TxtTelefonoUsuario.Text, CbRol.SelectedItem.ToString(), CbIdioma.SelectedItem.ToString()));
                Mostrar(DgvUsuarios, LinqUsuarios());
                string destinatario = TxtMail.Text;
                string asunto = "Registro exitoso!!!";
                string cuerpo = $"Estimado/a {TxtNombreUsuario.Text},\r\n\r\n¡Bienvenido/a al sistema de Santiago Muraca! 🎉\r\n\r\nTu cuenta ha sido creada con éxito. Ahora puedes acceder a nuestro sistema y disfrutar de todos los beneficios.";
                string emailOrigen = "saantimuraca12@gmail.com";
                string contraseña = "sdrjuqddpkdzwsph";
                string[] vectorMail = TxtMail.Text.Split('@');
                MessageBox.Show("Usuario creado con exito!!!");
                if (vectorMail[1].ToLower() == "gmail.com")
                {
                    mail.EnviarCorreo(destinatario, asunto, cuerpo, emailOrigen, contraseña);
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

        public void CargarRoles()
        {
            CbRol.SelectedIndex = -1;
            CbRol.SelectedItem = null;
            CbRol.Items.Clear();
            foreach (BEPermisoCompuesto rol in gp.ObtenerPermisos("Roles"))
            {
                CbRol.Items.Add(rol.DevolverNombrePermiso());
            }
        }

        private void MensajeMailEnviado(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha enviado un mail informando del alta al usuario!!!");
        }

        private void BtnHabilitarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvUsuarios.SelectedRows.Count == 0) throw new Exception("Debe seleccionar un usuario!!!");
                bllUsuario.HabilitarUsuario(DgvUsuarios.SelectedRows[0].Cells[0].Value.ToString());
                Mostrar(DgvUsuarios, LinqUsuarios());
            }
            catch (Exception ex) {MessageBox.Show(ex.Message); }    
        }

        private void BtnBajaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvUsuarios.SelectedRows.Count == 0) throw new Exception("Debe seleccionar un usuario!!!");
                bllUsuario.BloquearUsuario(DgvUsuarios.SelectedRows[0].Cells[0].Value.ToString());
                Mostrar(DgvUsuarios, LinqUsuarios());
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
