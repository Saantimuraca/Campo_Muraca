using Microsoft.VisualBasic;
using Servicios;
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
    public partial class Menu : Form, IObserver
    {
        Admin_Forms a = Admin_Forms.INSTANCIA;
        Sesion sesion = Sesion.INSTANCIA;
        LogicaBitacora bitacora = new LogicaBitacora();
        Traductor traductor = Traductor.INSTANCIA;
        public Menu()
        {
            InitializeComponent();
            sesion.ConfigurarIdioma(sesion.ObtenerIdiomaSesion());
            traductor.ActualizarIdioma(sesion.ObtenerIdiomaSesion());
            CbIdioma.SelectedItem = sesion.ObtenerIdiomaSesion();
            label2.Text += $" {sesion.ObtenerUsuarioActual().Idioma}";
            label3.Text += $" {sesion.ObtenerUsuarioActual().Rol.DevolverNombrePermiso()}";
            label1.Text += $", {sesion.ObtenerUsuarioActual().Nombre_Usuario}";
            ChequearAccesibilidadDeTodosLosControles();
            traductor.Suscribir(this);
            traductor.Notificar();
            CargarIdiomas();
            
        }

        public void CargarIdiomas()
        {
            CbIdioma.Items.Clear(); 
            LogicaIdioma bllIdioma = new LogicaIdioma();
            foreach(EntidadIdioma idioma in bllIdioma.ListaIdiomas())
            {
                CbIdioma.Items.Add(idioma.idioma);
            }
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
           Environment.Exit(0);
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            LogicaUsuario bllUsuario = new LogicaUsuario();
            Sesion sesion = Sesion.INSTANCIA;
            bitacora.RegistrarBitacora(bitacora.CrearBitacora(sesion.ObtenerUsuarioActual(), "Cerrar sesión"));
            bllUsuario.CerrarSesion(sesion.ObtenerUsuarioActual());
            MessageBox.Show(traductor.Traducir("Sesión cerrada correctamente!!!", sesion.ObtenerIdiomaSesion()));
            a.Definir_Estado(new EstadoIniciarSesion());
        }

        private void BtnCambiarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                Sesion sesion = Sesion.INSTANCIA;
                string nuevaContraseña = Interaction.InputBox(traductor.Traducir("Ingrese la nueva contrasena:", sesion.ObtenerIdiomaSesion()));
                string confirmarContraseña = Interaction.InputBox(traductor.Traducir("Confirme la contrasena:", sesion.ObtenerIdiomaSesion()));
                if (nuevaContraseña != confirmarContraseña) throw new Exception(traductor.Traducir("La contrasena no coincide!!!", sesion.ObtenerIdiomaSesion()));
                LogicaUsuario bllUsuario = new LogicaUsuario();
                bllUsuario.CambiarContraseña(sesion.ObtenerUsuarioActual(), nuevaContraseña);
                MessageBox.Show(traductor.Traducir("Contrasena cambiada exitosamente!!!", sesion.ObtenerIdiomaSesion()));
                bitacora.RegistrarBitacora(bitacora.CrearBitacora(sesion.ObtenerUsuarioActual(), "Cambiar contraseña"));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }   
        }

        private void gestiónDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ABM_Usuarios us = new ABM_Usuarios();
            us.ShowDialog();
        }

        private void gestiónDeRolesYPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestionRolesUsuarios roles = new GestionRolesUsuarios();
            roles.ShowDialog();
        }

        private void bitácoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUIBitacroa_ gui = new GUIBitacroa_();
            gui.ShowDialog();
        }

        public void ChequearAccesibilidadDeTodosLosControles()
        {
            GestorPermisos gp = new GestorPermisos();
            ChequearAccesibilidadRecursiva(Controls, gp);
        }

        public void ChequearAccesibilidadRecursiva(Control.ControlCollection controles, GestorPermisos gp)
        {
            foreach(Control ctrl in controles)
            {
                //Verificar la accesibilidad del control actual.
                ChequearAccesibilidad(ctrl, gp);
                //Si el control tiene controles hijos, se llama recursivamente para recorrer los mismos.
                if(ctrl.HasChildren)
                {
                    ChequearAccesibilidadRecursiva(ctrl.Controls, gp);
                }
                if(ctrl is MenuStrip)
                {
                    foreach (ToolStripMenuItem item in menuStrip1.Items)
                    {
                        ChequearAccesibilidadItemMenuStrip(item, gp);
                    }
                }
            }
        }

        public void ChequearAccesibilidad(Control control, GestorPermisos gp)
        {
            control.Enabled = gp.Configurar_Control(control.Tag?.ToString());
        }

        public void ChequearAccesibilidadItemMenuStrip(ToolStripMenuItem pItem, GestorPermisos gp)
        {
            pItem.Enabled = gp.Configurar_Control(pItem.Tag?.ToString());
        }

        public void ActualizarLenguaje()
        {
            Traductor traductor = Traductor.INSTANCIA;
            foreach(Control ctrl in this.Controls)
            {
                if (ctrl is MenuStrip menuStrip)
                {
                    // Traducir elementos dentro de un MenuStrip
                    TraducirMenuStrip(menuStrip, traductor);
                }
                else
                {
                    ctrl.Text = traductor.Traducir(ctrl.Name, sesion.ObtenerIdiomaSesion());
                }
            }
            string idioma = sesion.ObtenerUsuarioActual().Idioma;
            string plantilla = traductor.Traducir("label2", sesion.ObtenerIdiomaSesion());
            label2.Text = plantilla.Replace("{idioma}", idioma);
            string rol = sesion.ObtenerUsuarioActual().Rol.DevolverNombrePermiso();
            string plantilla2 = traductor.Traducir("label3", sesion.ObtenerIdiomaSesion());
            label3.Text = plantilla2.Replace("{rol}", rol);
            string usuario = sesion.ObtenerUsuarioActual().Nombre_Usuario;
            string plantilla3 = traductor.Traducir("label1", sesion.ObtenerIdiomaSesion());
            label1.Text = plantilla3.Replace("{usuario}", usuario);
        }

        private void TraducirMenuStrip(MenuStrip menuStrip, Traductor traductor)
        {
            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                TraducirMenuItem(item, traductor);
            }
        }

        private void TraducirMenuItem(ToolStripMenuItem menuItem, Traductor traductor)
        {
            menuItem.Text = traductor.Traducir(menuItem.Name, sesion.ObtenerIdiomaSesion());

            // Si tiene submenús, traducirlos también
            foreach (ToolStripItem subItem in menuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    TraducirMenuItem(subMenuItem, traductor);
                }
            }
        }

        private void BtnCambiarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                LogicaUsuario bllUsuario = new LogicaUsuario();
                bllUsuario.CambiarIdioma(sesion.ObtenerUsuarioActual(), CbIdioma.SelectedItem.ToString());
                Traductor traductor = Traductor.INSTANCIA;
                traductor.ActualizarIdioma(sesion.ObtenerIdiomaSesion());
                traductor.Notificar();
                bitacora.RegistrarBitacora(bitacora.CrearBitacora(sesion.ObtenerUsuarioActual(), "Cambiar idioma"));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void idiomasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUIIdiomas gUIIdiomas = new GUIIdiomas();
            gUIIdiomas.ShowDialog();
            CargarIdiomas();
        }

        private void Menu_Shown(object sender, EventArgs e)
        {
            
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Backup_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(traductor.Traducir("¿Desea realizar un backup de la base de datos?", ""), traductor.Traducir("Consulta", ""), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                GestorDeCopiasDeDatos gp = new GestorDeCopiasDeDatos();
                gp.HacerBackUp();
                MessageBox.Show(traductor.Traducir("Backup exitoso!!!", ""));
            }
        }

        private void respaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(traductor.Traducir("¿Desea realizar un respaldo de la base de datos?", ""), traductor.Traducir("Consulta", ""), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                GestorDeCopiasDeDatos gp = new GestorDeCopiasDeDatos();
                gp.HacerBackUp();
                MessageBox.Show(traductor.Traducir("Respaldo exitoso!!!", ""));
            }
        }
    }
}
