using Servicios;
using Servicios.Datos;
using Servicios.Entidades;
using Servicios.Logica;
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
        LogicaUsuario bllUsuario = new LogicaUsuario();
        Sesion sesion = Sesion.INSTANCIA;
        private bool contraseñaVisible = false;
        public Login()
        {
            InitializeComponent();
            TxtNombreUsuario.Text = "Saantimuraca";
            TxtContraseña.Text = "Hola123";
        }

        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                LogicaBitacora bitacora = new LogicaBitacora();
                string nombreUsuario = TxtNombreUsuario.Text;
                string contraseñaUsuario = TxtContraseña.Text;
                if (!bllUsuario.ExisteUsuario(nombreUsuario, 0, "")) throw new Exception("Credenciales incorrectas!!!");
                if (!bllUsuario.Login(nombreUsuario, contraseñaUsuario))
                {
                    if(DatosDV.INSTANCIA.VerificarIntegridadBD()) { bllUsuario.AumentarIntentos(nombreUsuario); }
                    EntidadUsuario usuario = bllUsuario.ListaUsuarios().Find(x => x.Nombre_Usuario == nombreUsuario);
                    switch (usuario.Intentos)
                    {
                        case 1: MessageBox.Show("Le quedan 2 intentos antes de que se bloquee el usuario!!!"); break;
                        case 2: MessageBox.Show("Le queda 1 intento antes de que se bloquee el usuario!!!"); break;
                        default: MessageBox.Show("Usuario bloqueado!!!"); break;
                    }
                    if (usuario.Estado_Usuario != false) throw new Exception("Credenciales incorrectas!!!");
                }
                else
                {
                    if (!DatosDV.INSTANCIA.VerificarIntegridadBD() && sesion.ObtenerUsuarioActual().Rol.DevolverNombrePermiso() != "Administrador")
                    {
                        sesion.CerrarSesion();
                        throw new Exception(Traductor.INSTANCIA.Traducir("La integridad de la base de datos se vió afectada, comuniquese con el administrador del sistema", ""));
                    }
                    else if(!DatosDV.INSTANCIA.VerificarIntegridadBD() && sesion.ObtenerUsuarioActual().Rol.DevolverNombrePermiso() == "Administrador")
                    {
                        MessageBox.Show(Traductor.INSTANCIA.Traducir("La integridad de la base de datos se vió afectada, por favor realice un restore inmediatamente", ""), Traductor.INSTANCIA.Traducir("Advertencia", ""), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        bitacora.RegistrarBitacora(bitacora.CrearBitacora(sesion.ObtenerUsuarioActual(), "Inicio de sesión", 4));
                    }
                        //DatosDV.INSTANCIA.VerificarIntegridadBD();
                        a.Definir_Estado(new EstadoMenu());
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
            
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
