using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Servicios;
using Servicios.Entidades;
using Servicios.Logica;

namespace GUI
{
    public partial class HistoriaUsuarios : Form, IObserver
    {
        string dniSeleccionado;
        LogicaUsuario logicaUsuario = new LogicaUsuario();
        GestorPermisos gp = new GestorPermisos();
        LogicaBitacora bitacora = new LogicaBitacora();
        public HistoriaUsuarios(string pDniSeleccionado)
        {
            InitializeComponent();
            Traductor.INSTANCIA.Suscribir(this);
            Traductor.INSTANCIA.Notificar();
            this.dniSeleccionado = pDniSeleccionado;
            Dgv.DataSource = null;
            Dgv.DataSource = Linq();
            Dgv.Columns[0].Visible = false;
            Dgv.Columns["Nombre"].HeaderText = Traductor.INSTANCIA.Traducir("USUARIO", Sesion.INSTANCIA.ObtenerIdiomaSesion());
            Dgv.Columns["Mail"].HeaderText = Traductor.INSTANCIA.Traducir("MAIL", Sesion.INSTANCIA.ObtenerIdiomaSesion());
            Dgv.Columns["Contraseña"].HeaderText = Traductor.INSTANCIA.Traducir("CONTRASEÑA", Sesion.INSTANCIA.ObtenerIdiomaSesion());
            Dgv.Columns["FechaNacimiento"].HeaderText = Traductor.INSTANCIA.Traducir("FECHA DE NACIMIENTO", Sesion.INSTANCIA.ObtenerIdiomaSesion());
            Dgv.Columns["FechaCreacion"].HeaderText = Traductor.INSTANCIA.Traducir("FECHA DE CREACIÓN", Sesion.INSTANCIA.ObtenerIdiomaSesion());
            Dgv.Columns["Telefono"].HeaderText = Traductor.INSTANCIA.Traducir("TELEFONO", Sesion.INSTANCIA.ObtenerIdiomaSesion());
            Dgv.Columns["Estado"].HeaderText = Traductor.INSTANCIA.Traducir("ESTADO", Sesion.INSTANCIA.ObtenerIdiomaSesion());
            Dgv.Columns["Rol"].HeaderText = Traductor.INSTANCIA.Traducir("ROL", Sesion.INSTANCIA.ObtenerIdiomaSesion());
            Dgv.Columns["Idioma"].HeaderText = Traductor.INSTANCIA.Traducir("IDIOMA", Sesion.INSTANCIA.ObtenerIdiomaSesion());
            Dgv.Columns["FechaModificacion"].HeaderText = Traductor.INSTANCIA.Traducir("FECHA DE MODIFICACIÓN", Sesion.INSTANCIA.ObtenerIdiomaSesion());
        }

        private object Linq()
        {
            return (from h in logicaUsuario.ListaHistorias() where h.Dni_Usuario == dniSeleccionado select new {Id = h.id, Nombre = h.Nombre_Usuario, Mail = h.Mail_Usuario,
            Contraseña = h.Contraseña_Usuario, FechaNacimiento = h.Fecha_Nacimiento_Usuario, FechaCreacion = h.Fecha_Creacion_Usuario, Telefono = h.Telefono_Usuario,
            Estado = h.Estado_Usuario, Rol = h.Rol.DevolverNombrePermiso(), Idioma = h.Idioma, FechaModificacion = h.fechaModificacion}).ToList();
        }

        private void BtnRollBack_Click(object sender, EventArgs e)
        {
            if (Dgv.SelectedRows.Count > 0)
            {
                string nombre = Dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                string mail = Dgv.SelectedRows[0].Cells["Mail"].Value.ToString();
                string contraseña = Dgv.SelectedRows[0].Cells["Contraseña"].Value.ToString();
                DateTime fechaNacimiento = DateTime.Parse(Dgv.SelectedRows[0].Cells["FechaNacimiento"].Value.ToString());
                DateTime fechaCreacion = DateTime.Parse(Dgv.SelectedRows[0].Cells["FechaCreacion"].Value.ToString());
                string telefono = Dgv.SelectedRows[0].Cells["Telefono"].Value.ToString();
                bool estado = bool.Parse(Dgv.SelectedRows[0].Cells["Estado"].Value.ToString());
                EntidadPermisoCompuesto rol = gp.ObtenerPermisosArbol().Find(x => x.DevolverNombrePermiso() == Dgv.SelectedRows[0].Cells["Rol"].Value.ToString()) as EntidadPermisoCompuesto;
                string idioma = Dgv.SelectedRows[0].Cells["Idioma"].Value.ToString();
                int intentos = logicaUsuario.ListaUsuarios().Find(x => x.Dni_Usuario == dniSeleccionado).Intentos;
                EntidadUsuario usuario = new EntidadUsuario(dniSeleccionado, nombre, mail, contraseña, fechaNacimiento, fechaCreacion, telefono, estado, rol, idioma, intentos);
                if (logicaUsuario.RollBack(usuario))
                {
                    MessageBox.Show(Traductor.INSTANCIA.Traducir("RollBack exitoso", ""));
                    ABM_Usuarios gui = Application.OpenForms["ABM_Usuarios"] as ABM_Usuarios;
                    if (gui != null) { gui.Actualizar(); }
                    bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.INSTANCIA.ObtenerUsuarioActual(), $"RollBack del usuario {dniSeleccionado} {nombre}", 4));
                }
                else
                {
                    MessageBox.Show(Traductor.INSTANCIA.Traducir("Ocurrió un error", ""));
                    bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.INSTANCIA.ObtenerUsuarioActual(), $"No pudo realizar el RollBack del usuario {dniSeleccionado} {nombre}", 4));
                }
            }
        }

        public void ActualizarLenguaje()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label || ctrl is Button)
                {
                    ctrl.Text = Traductor.INSTANCIA.Traducir(ctrl.Name, Sesion.INSTANCIA.ObtenerIdiomaSesion());
                }
            }
        }
    }
}
