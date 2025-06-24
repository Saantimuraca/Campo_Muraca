using iTextSharp.text;
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
    public partial class GestionRolesUsuarios : Form, IObserver
    {
        LogicaBitacora bitacora = new LogicaBitacora();
        Sesion sesion = Sesion.INSTANCIA;
        Traductor traductor = Traductor.INSTANCIA;
        LogicaUsuario lu = new LogicaUsuario();
        GestorPermisos gp = new GestorPermisos();
        List<string> lista;
        public GestionRolesUsuarios()
        {
            InitializeComponent();
            RefrescarControles();
            traductor.Suscribir(this);
            traductor.Notificar();
            CargarPermisosArbol();
            BtnModificarPermisos.Enabled = false;
            lista = new List<string>();
        }

        private void CargarPermisosArbol()
        {
            treeView1.Nodes.Clear();
            foreach (var permiso in gp.ObtenerPermisosArbol())
            {
                foreach(var p in gp.ObtenerPermisos("Roles"))
                {
                    if(permiso.DevolverNombrePermiso() == p.DevolverNombrePermiso())
                    {
                        TreeNode nodo = CrearNodo(permiso);
                        treeView1.Nodes.Add(nodo);
                    }
                }
            }
        }

        private TreeNode CrearNodo(EntidadPermiso pPermiso)
        {
            TreeNode nodo = new TreeNode(pPermiso.DevolverNombrePermiso());
            if(pPermiso.isComposite())
            {
                EntidadPermisoCompuesto permisoCompuesto = pPermiso as EntidadPermisoCompuesto;
                foreach(var permiso in permisoCompuesto.listaPermisos)
                {
                    nodo.Nodes.Add(CrearNodo(permiso));
                }
            }
                return nodo;
        }

        private void BtnCrearRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaPermisos.CheckedItems.Count == 0) throw new Exception(traductor.Traducir("Debe seleccionar almenos un permiso de la lista de permisos!!!", sesion.ObtenerIdiomaSesion()));
                string nombrePermiso = Interaction.InputBox(traductor.Traducir("Ingrese el nombre del permiso:", sesion.ObtenerIdiomaSesion()));
                if (nombrePermiso.Length == 0 || string.IsNullOrWhiteSpace(nombrePermiso)) throw new Exception(traductor.Traducir("Debe ingresar un nombre para el permiso!!!", sesion.ObtenerIdiomaSesion()));
                CrearPermisoCompuesto(nombrePermiso, true);
                bitacora.RegistrarBitacora(bitacora.CrearBitacora(sesion.ObtenerUsuarioActual(), "Crear rol"));
                RefrescarControles();
                CargarPermisosArbol();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void RefrescarControles()
        {
            CbRolesGrupos.SelectedIndex = -1;
            CargarPermisos();
            CargarCbRolesGrupos();
        }

        public void CargarCbRolesGrupos()
        {
            CbRolesGrupos.Items.Clear();
            var permisoscompuestos = gp.ObtenerPermisos("Compuestos").Where(x => x.DevolverNombrePermiso() != "Administrador");
            CbRolesGrupos.Items.AddRange(permisoscompuestos.ToArray());
        }

        public void CrearPermisoCompuesto(string pNombrePermiso, bool isRol)
        {
            List<string> items = GenerarLista();
            string error = $"Ocurrió un error";
            if(!gp.AgregarPermisoCompuesto(pNombrePermiso, items, isRol)) { MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public List<string> GenerarLista()
        {
            List<string> items = new List<string>();
            foreach (var x in ListaPermisos.CheckedItems)
            {
                items.Add(x.ToString());
            }
            return items;   
        }

        public void CargarPermisos()
        {
            ListaPermisos.Items.Clear();
            var permisos = gp.ObtenerPermisos("Todos excepto roles");
            ListaPermisos.Items.AddRange(permisos.ToArray());
        }

        private void CbRolesGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarSeleccionPermisos();
            if(CbRolesGrupos.SelectedItem != null )
            {
                List<EntidadPermiso> permisoRaiz = gp.ObtenerPermisosArbol();
                EntidadPermiso permisoSeleccionado = permisoRaiz.Find(x => x.DevolverNombrePermiso() == CbRolesGrupos.SelectedItem.ToString());
                if(permisoSeleccionado is EntidadPermisoCompuesto pPermisoCompuesto)
                {
                    CheckearPermisosenLista(pPermisoCompuesto);
                }
                BtnModificarPermisos.Enabled = true;

            }
        }

        public void LimpiarSeleccionPermisos()
        {
            for(int i = 0; i <  ListaPermisos.Items.Count; i++)
            {
                ListaPermisos.SetItemChecked(i, false);
            }
        }

        public void CheckearPermisosenLista(EntidadPermisoCompuesto permisoRaiz)
        {
            if(permisoRaiz.DevolverNombrePermiso() != "Administrador")
            {
                foreach (EntidadPermiso p in permisoRaiz.DevolverListaPermisos())
                {
                    int index = ListaPermisos.Items.Cast<object>()
                    .ToList()
                    .FindIndex(item => item.ToString() == p.DevolverNombrePermiso());
                    if (index != -1)
                    {
                        ListaPermisos.SetItemChecked(index, true);
                        lista.Add(p.DevolverNombrePermiso()); 
                    }
                }
            }
            else
            {
                for (int i = 0; i < ListaPermisos.Items.Count; i++)
                {
                    ListaPermisos.SetItemChecked(i, true);
                }
            }
        }

        private void BtnEliminarPermisosSeleccionados_Click(object sender, EventArgs e)
        {
            try
            {
                if (CbRolesGrupos.SelectedIndex != -1)
                {
                    if (lu.RolIsInUso(CbRolesGrupos.SelectedItem.ToString())) throw new Exception(Traductor.INSTANCIA.Traducir("Este rol se encuentra en uso", ""));
                    if (gp.EliminarPermiso(CbRolesGrupos.SelectedItem.ToString())) MessageBox.Show(traductor.Traducir("Se ha eliminado el permiso con exito!!!", sesion.ObtenerIdiomaSesion()));
                    RefrescarControles();
                    CargarPermisosArbol();
                    bitacora.RegistrarBitacora(bitacora.CrearBitacora(sesion.ObtenerUsuarioActual(), "Eliminar permiso"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, traductor.Traducir("Advertencia", ""), MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void BtnModificarNombre_Click(object sender, EventArgs e)
        {
            try
            {
                if (CbRolesGrupos.SelectedIndex != -1)
                {
                    string nuevoNombre = Interaction.InputBox(traductor.Traducir("Ingrese el nuevo nombre para el permiso:", sesion.ObtenerIdiomaSesion()), traductor.Traducir("Modificando...", sesion.ObtenerIdiomaSesion()), CbRolesGrupos.SelectedItem.ToString());
                    if (string.IsNullOrWhiteSpace(nuevoNombre)) throw new Exception(traductor.Traducir("Debe ingresar un nombre para el nuevo permiso!!!", sesion.ObtenerIdiomaSesion()));
                    if (gp.ExistePermiso(nuevoNombre)) throw new Exception(traductor.Traducir("Permiso o rol existente", ""));
                    gp.ModificarNombrePermiso(CbRolesGrupos.SelectedItem.ToString(), nuevoNombre);
                    MessageBox.Show("Se ha modificado el permiso con éxito!!!");
                    RefrescarControles();
                    bitacora.RegistrarBitacora(bitacora.CrearBitacora(sesion.ObtenerUsuarioActual(), "Modificar permiso"));
                }
            }
            catch(Exception ex) {MessageBox.Show(ex.Message, traductor.Traducir("Advertencia", ""), MessageBoxButtons.OK, MessageBoxIcon.Warning); } 
            
        }

        private void BtnCrearGrupoPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaPermisos.CheckedItems.Count < 1) throw new Exception(traductor.Traducir("Debe seleccionar al menos 2 permisos para crear un grupo!!!", sesion.ObtenerIdiomaSesion()));
                string nombreGrupo = Interaction.InputBox(traductor.Traducir("Ingrese el nombre para el grupo de permisos:", sesion.ObtenerIdiomaSesion()));
                if (string.IsNullOrWhiteSpace(nombreGrupo)) throw new Exception(traductor.Traducir("Debe ingresar un nombre para el grupo de permisos!!!", sesion.ObtenerIdiomaSesion()));
                CrearPermisoCompuesto(nombreGrupo, false);
                RefrescarControles();
                CargarPermisosArbol();
                bitacora.RegistrarBitacora(bitacora.CrearBitacora(sesion.ObtenerUsuarioActual(), "Crear permiso"));
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void ActualizarLenguaje()
        {
            Traductor traductor = Traductor.INSTANCIA;
            foreach (Control ctrl in this.Controls)
            {
                if(ctrl is Button || ctrl is Label)
                {
                    ctrl.Text = traductor.Traducir(ctrl.Name, sesion.ObtenerIdiomaSesion());
                }  
            }
        }
        private void GestionRolesUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["Menu"].Show();
        }

        private void BtnModificarPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> permisosCheckeados = new List<string>();
                List<string> permisosCheckeadosNivel1 = new List<string>();
                foreach (object item in ListaPermisos.CheckedItems)
                {
                    permisosCheckeados.Add(item.ToString());
                    permisosCheckeadosNivel1.Add(item.ToString());
                    EntidadPermiso permiso = gp.ObtenerPermisosArbol().Find(x => x.DevolverNombrePermiso() == item.ToString());
                    if (permiso != null && permiso.isComposite())
                    {
                        AgregarHijosRecursivos((EntidadPermisoCompuesto)permiso, permisosCheckeados);
                    }
                }
                var diferencia = permisosCheckeados.Where(u => !lista.Any(x => x == u)).ToList();
                gp.ActualizarPermisos(CbRolesGrupos.SelectedItem.ToString(), permisosCheckeadosNivel1, diferencia);
                MessageBox.Show(traductor.Traducir("Permiso actualizado exitosamente", ""), traductor.Traducir("Información", ""), MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarPermisosArbol();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AgregarHijosRecursivos(EntidadPermisoCompuesto compuesto, List<string> lista)
        {
            foreach (EntidadPermiso hijo in compuesto.DevolverListaPermisos())
            {
                string nombreHijo = hijo.DevolverNombrePermiso();
                if (!lista.Contains(nombreHijo))
                    lista.Add(nombreHijo);

                if (hijo is EntidadPermisoCompuesto hijoCompuesto)
                    AgregarHijosRecursivos(hijoCompuesto, lista);
            }
        }

        private void BtnEliminarSeleccion_Click(object sender, EventArgs e)
        {
            RefrescarControles();
            CargarPermisosArbol();
        }

        private void ListaPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListaPermisos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Obtener el permiso sobre el que se hace click
            /*EntidadPermiso permisoSeleccionado = gp.DevolverPermisoConHijos(ListaPermisos.Items[e.Index].ToString());

            // Si es compuesto...
            if (permisoSeleccionado != null && permisoSeleccionado.isComposite())
            {
                // Esperar que termine el cambio actual
                this.BeginInvoke((MethodInvoker)delegate
                {
                    // Recorremos sus hijos
                    foreach (EntidadPermiso hijo in ((EntidadPermisoCompuesto)permisoSeleccionado).DevolverListaPermisos())
                    {
                        int indexHijo = ListaPermisos.Items.IndexOf(hijo.DevolverNombrePermiso());
                        if (indexHijo != -1)
                        {
                            ListaPermisos.SetItemChecked(indexHijo, e.NewValue == CheckState.Checked);
                        }
                    }
                });
            }*/
        }
    }
}
