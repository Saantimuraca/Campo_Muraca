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

namespace GUI
{
    public partial class ABM_Usuarios : Form
    {
        BLL_Usuario bllUsuario = new BLL_Usuario();
        public ABM_Usuarios()
        {
            InitializeComponent();
        }

        private void BtnAgregarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Information.IsDate(TxtFechaNacimiento.Text)) throw new Exception("Fecha inválida!!!");
                bllUsuario.AgregarUsuario(bllUsuario.CrearUsuario(TxtNombreUsuario.Text, TxtMail.Text, TxtContraseña.Text, TxtFechaNacimiento.Text, TxtTelefonoUsuario.Text));
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

        
    }
}
