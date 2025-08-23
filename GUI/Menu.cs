using Microsoft.VisualBasic;
using Servicios;
using Servicios.Entidades;
using Servicios.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            bitacora.RegistrarBitacora(bitacora.CrearBitacora(sesion.ObtenerUsuarioActual(), "Cierre de sesión", 4));
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
                if(nuevaContraseña != "")
                {
                    Encriptador encriptador = new Encriptador();
                    if (sesion.ObtenerUsuarioActual().Contraseña_Usuario == encriptador.GenerarHash(nuevaContraseña)) throw new Exception(traductor.Traducir("La nueva contraseña no puede ser identica a la actual", ""));
                    string confirmarContraseña = Interaction.InputBox(traductor.Traducir("Confirme la contrasena:", sesion.ObtenerIdiomaSesion()));
                    if(confirmarContraseña != "")
                    {
                        if (nuevaContraseña != confirmarContraseña) throw new Exception(traductor.Traducir("La contrasena no coincide!!!", sesion.ObtenerIdiomaSesion()));
                        LogicaUsuario bllUsuario = new LogicaUsuario();
                        bllUsuario.CambiarContraseña(sesion.ObtenerUsuarioActual(), nuevaContraseña);
                        MessageBox.Show(traductor.Traducir("Contrasena cambiada exitosamente!!!", sesion.ObtenerIdiomaSesion()));
                        bitacora.RegistrarBitacora(bitacora.CrearBitacora(sesion.ObtenerUsuarioActual(), "Cambio de contraseña", 1));
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); }   
        }

        private void gestiónDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_Usuarios us = new ABM_Usuarios();
            us.Show();
        }

        private void gestiónDeRolesYPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionRolesUsuarios roles = new GestionRolesUsuarios();
            roles.Show();
        }

        private void bitácoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIBitacroa_ gui = new GUIBitacroa_();
            gui.Show();
        }

        public void ChequearAccesibilidadDeTodosLosControles()
        {
            GestorPermisos gp = new GestorPermisos();
            ChequearAccesibilidadRecursiva(Controls, gp);
        }

        public void ChequearAccesibilidadRecursiva(Control.ControlCollection controles, GestorPermisos gp)
        {
            foreach (Control ctrl in controles)
            {
                ChequearAccesibilidad(ctrl, gp);

                if (ctrl.HasChildren)
                {
                    ChequearAccesibilidadRecursiva(ctrl.Controls, gp);
                }

                if (ctrl is MenuStrip menuStrip)
                {
                    foreach (ToolStripMenuItem item in menuStrip.Items)
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

        public void ChequearAccesibilidadItemMenuStrip(ToolStripMenuItem item, GestorPermisos gp)
        {
            if (!string.IsNullOrEmpty(item.Tag?.ToString()))
                item.Enabled = gp.Configurar_Control(item.Tag.ToString());

            foreach (ToolStripItem subItem in item.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    ChequearAccesibilidadItemMenuStrip(subMenuItem, gp);
                }
            }
        }

        public void ActualizarLenguaje()
        {
            Traductor traductor = Traductor.INSTANCIA;
            foreach(Control ctrl in this.Controls)
            {
                if (ctrl is MenuStrip menuStrip)
                {
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
                bool estaAbierto = Application.OpenForms["GUIIdiomas"] != null;
                if (estaAbierto)
                {
                    GUIIdiomas f = Application.OpenForms["GUIIdiomas"] as GUIIdiomas;
                    f.MostrarCambioMenu();
                }
                bitacora.RegistrarBitacora(bitacora.CrearBitacora(sesion.ObtenerUsuarioActual(), "Cambio de idioma", 1));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void idiomasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GUIIdiomas gUIIdiomas = new GUIIdiomas();
                gUIIdiomas.Show();
                CargarIdiomas();
            }
            catch { }
        }

        private void Menu_Shown(object sender, EventArgs e)
        {
            
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Backup_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show(traductor.Traducir("¿Desea realizar un backup de la base de datos?", ""), traductor.Traducir("Consulta", ""), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    GestorDeCopiasDeDatos gp = new GestorDeCopiasDeDatos();
                    gp.HacerBackUp();
                    MessageBox.Show(traductor.Traducir("BackUp Exitoso", ""), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bitacora.RegistrarBitacora(bitacora.CrearBitacora(sesion.ObtenerUsuarioActual(), "BackUp", 3));
                    var exe = Application.ExecutablePath;
                    Process.Start(exe);
                    Environment.Exit(0);
                }
            }
            catch { MessageBox.Show(traductor.Traducir("Error BackUp", ""), traductor.Traducir("Advertencia", ""), MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void respaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(traductor.Traducir("¿Desea realizar un respaldo de la base de datos?", ""), traductor.Traducir("Consulta", ""), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                GestorDeCopiasDeDatos gp = new GestorDeCopiasDeDatos();
                try
                {
                    if(gp.HacerRespaldo()) { MessageBox.Show(traductor.Traducir("Respaldo exitoso!!!", ""), "", MessageBoxButtons.OK, MessageBoxIcon.Information); var exe = Application.ExecutablePath;
                        Process.Start(exe);
                        Environment.Exit(0);
                    }
                    else { throw new Exception(); }
                }
                catch { MessageBox.Show(traductor.Traducir("Error Restore", ""), traductor.Traducir("Advertencia", ""), MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void aBMClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIRegistrarCliente gui = new GUIRegistrarCliente();
            gui.Show();
        }

        private void registrarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIRegistrarPedido gui = new GUIRegistrarPedido();
            gui.Show();
        }

        private void supervisarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIConfirmarPedido gui = new GUIConfirmarPedido();
            gui.Show();
        }

        private void cobrarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUICobrarPedido gui = new GUICobrarPedido();
            gui.Show();
        }
    }
}
