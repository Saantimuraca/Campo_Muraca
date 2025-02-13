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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class ABM_Usuarios : Form
    {
        BLL_Usuario bllUsuario = new BLL_Usuario();
        GestorPermisos gp = new GestorPermisos();
        public ABM_Usuarios()
        {
            InitializeComponent();
            Mostrar(DgvUsuarios, LinqUsuarios());
            CargarRoles();
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
            return (from u in bllUsuario.ListaUsuarios() select new {USUARIO = u.Nombre_Usuario, MAIL = u.Mail_Usuario, EDAD = u.Edad_Usuario, TELEFONO = u.Telefono_Usuario, ESTADO = u.Estado_Usuario == true ? "Activo":"Bloqueado"}).ToList();
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
    }
}
