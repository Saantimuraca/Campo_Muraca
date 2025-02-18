using BE;
using BLL;
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
    public partial class Login : Form
    {
        public bool islogueado = false;
        Admin_Forms a = Admin_Forms.INSTANCIA;
        BLL_Usuario bllUsuario = new BLL_Usuario();
        Sesion sesion = Sesion.INSTANCIA;
        private bool contraseñaVisible = false;
        public Login()
        {
            InitializeComponent();

        }

        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = TxtNombreUsuario.Text;
                string contraseñaUsuario = TxtContraseña.Text;
                if (!bllUsuario.ExisteUsuario(nombreUsuario)) throw new Exception();
                if (!bllUsuario.Login(nombreUsuario, contraseñaUsuario)) throw new Exception();
                a.Definir_Estado(new EstadoMenu());
                bllUsuario.AumentarIntentos(nombreUsuario);
                BE_Usuario usuario = bllUsuario.ListaUsuarios().Find(x => x.Nombre_Usuario ==  nombreUsuario);
                switch (usuario.Intentos)
                {
                  case 1: MessageBox.Show("Le quedan 2 intentos antes de que se bloquee el usuario!!!"); break;
                  case 2: MessageBox.Show("Le quedan 1 intento antes de que se bloquee el usuario!!!"); break;
                  default: MessageBox.Show("Usuario bloqueado!!!"); break;
                }
            }
            catch { MessageBox.Show("Credenciales incorrectas!!!"); ; }
            
        }

        private void BtnVisibilidadContraseña_Click(object sender, EventArgs e)
        {
            if(contraseñaVisible)
            {
                contraseñaVisible = false;
                TxtContraseña.PasswordChar = '*';
                BtnVisibilidadContraseña.Text = "VER";
            }
            else
            {
                contraseñaVisible = true;
                TxtContraseña.PasswordChar = '\0';
                BtnVisibilidadContraseña.Text = "OCULTAR";
            }
        }
    }
}
