using Microsoft.VisualBasic;
using Servicios;
using Servicios.Entidades;
using Servicios.Logica;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Collections.Specialized.BitVector32;

namespace GUI
{
    public partial class GUIIdiomas : Form, IObserver
    {
        LogicaIdioma bllIdioma = new LogicaIdioma();
        Sesion sesion = Sesion.INSTANCIA;
        Traductor traductor = Traductor.INSTANCIA;
        LogicaTraduccion bllTraduccion = new LogicaTraduccion();
        List<EntidadTraduccion> listaAux = new List<EntidadTraduccion>();
        LogicaBitacora b = new LogicaBitacora();
        Dictionary<string, string> cambios = new Dictionary<string, string>();
        public GUIIdiomas()
        {
            InitializeComponent();
            traductor.Suscribir(this);
            traductor.Notificar();

            this.Shown += (s, e) =>
            {
                Mostrar(DgvIdiomas, LinqIdiomas());
                TraducirDgvs();
                BtnModificarTraduccion.Enabled = false;
                Mostrar(DgvTraducciones, LinqTraducciones());
            };
        }
        private void Mostrar(DataGridView dgv, object obj, int pOpcion = 0)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
            if (dgv.Name == DgvTraducciones.Name)
            {
                dgv.Columns[0].Visible = false;
                dgv.Columns[1].Visible = false;
                dgv.Columns["textoTraducido"].HeaderText = traductor.Traducir(sesion.ObtenerIdiomaSesion(), "");
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Name != "nuevaColumna") dgv.Columns[i].ReadOnly = true;
                }
            }
        }

        public void MostrarCambioMenu()
        {
            if (DgvTraducciones.Columns.Count > 3) DgvTraducciones.Columns.Remove("nuevaColumna");
            Mostrar(DgvTraducciones, LinqTraducciones());
        }
       
        private object LinqTraducciones()
        {

            return bllTraduccion.ListaTraduccion()
           .Where(t => t.idioma == sesion.ObtenerIdiomaSesion())
           .OrderBy(t => t.textoTraducir)
           .ToList();
        }

        
        public object LinqIdiomas()
        {
            return (from i in bllIdioma.ListaIdiomas() select new {IDIOMA = i.idioma}).ToList();
        }
        void IObserver.ActualizarLenguaje()
        {
            foreach (Control ctrl in this.Controls)
            { 
              ctrl.Text = traductor.Traducir(ctrl.Name, sesion.ObtenerIdiomaSesion());  
            }
        }
        private void TraducirDgvs()
        {
            DgvIdiomas.Columns[0].HeaderText = traductor.Traducir("IDIOMA", sesion.ObtenerIdiomaSesion());
        }
      

        private void BtnModificarTraduccion_Click(object sender, EventArgs e)
        {
            EntidadIdioma idiomaSeleccionado = bllIdioma.ListaIdiomas().Find(x => x.idioma == DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString());
            bllTraduccion.ModificarTraduccion(cambios, idiomaSeleccionado.idIdioma);
            cambios.Clear();
            EntidadIdioma idiomaEvaluar = bllIdioma.ListaIdiomas().Find(x => x.idioma == idiomaSeleccionado.idioma);
            bllIdioma.ModificarDisponibilidad(idiomaEvaluar, bllTraduccion.EvaluarDisponibilidad());
            Traductor.INSTANCIA.ActualizarIdioma(sesion.ObtenerIdiomaSesion());
            Traductor.INSTANCIA.Notificar();
            b.RegistrarBitacora(b.CrearBitacora(sesion.ObtenerUsuarioActual(), "Modificación de traduccion", 1));
        }
        private void AgregarColumna(string pIdioma)
        {
            if(DgvTraducciones.Columns.Count > 3) DgvTraducciones.Columns.Remove("nuevaColumna");
            DgvTraducciones.Columns.Add("nuevaColumna", pIdioma);
            List<EntidadTraduccion> lista = bllTraduccion.ListaTraduccion().Where(x => x.idioma.Equals(pIdioma)).ToList();
            int indexLista = 0;
            lista = lista.OrderBy(x => x.textoTraducir).ToList();
            foreach (DataGridViewRow fila in DgvTraducciones.Rows)
            {
                if (fila.IsNewRow) continue; // evita la fila vacía al final

                var celda = fila.Cells["nuevaColumna"];
                // Si está vacía, la completamos con la lista
                if (indexLista < lista.Count)
                {
                    celda.Value = lista[indexLista].textoTraducido;
                    indexLista++;
                }
            }
            traductor.ActualizarIdioma(sesion.ObtenerIdiomaSesion());
            traductor.Notificar();
            DgvTraducciones.Columns["nuevaColumna"].HeaderText = traductor.Traducir(pIdioma,"");
        }
        private void GUIIdiomas_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void BtnAgregarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                string idioma = Interaction.InputBox(traductor.Traducir("Idioma:", ""));
                if (idioma == "") throw new Exception("Idioma inválido");
                if (bllIdioma.IsRepetido(idioma)) throw new Exception(traductor.Traducir("El idioma ingresado ya se encuentra registrado", ""));
                EntidadIdioma nuevoIdioma = new EntidadIdioma(idioma);
                bllIdioma.AgregarIdioma(nuevoIdioma);
                Mostrar(DgvIdiomas, LinqIdiomas());
                bool estaAbierto = Application.OpenForms["GUIIdiomas"] != null;
                if(estaAbierto)
                {
                    Menu m = Application.OpenForms["Menu"] as Menu;
                    m.CargarIdiomas();
                }
                b.RegistrarBitacora(b.CrearBitacora(sesion.ObtenerUsuarioActual(), $"Agregó el idioma {idioma}", 1));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, traductor.Traducir("Advertencia", ""), MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void BtnEliminarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvIdiomas.SelectedRows.Count == 0) throw new Exception(traductor.Traducir("Debe seleccionar un idioma!!!", ""));
                if (DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString() == "Español" || DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString() == "Ingles") throw new Exception(traductor.Traducir("No se pueden eliminar los idiomas principales del sistema!!!", ""));
                if (DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString() == sesion.ObtenerIdiomaSesion()) throw new Exception(traductor.Traducir("No puede eliminar el idioma utilizado actualmente!!!", ""));
                EntidadIdioma idioma = new EntidadIdioma(DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString());
                bllIdioma.EliminarIdioma(idioma);
                b.RegistrarBitacora(b.CrearBitacora(sesion.ObtenerUsuarioActual(), $"Eliminó el idioma {idioma.idioma}", 3));
                Mostrar(DgvIdiomas, LinqIdiomas());
                Mostrar(DgvTraducciones, LinqTraducciones());
                if (DgvTraducciones.Columns.Contains("nuevaColumna")) { DgvTraducciones.Columns.Remove("nuevaColumna"); }
                bool estaAbierto = Application.OpenForms["GUIIdiomas"] != null;
                if (estaAbierto)
                {
                    Menu m = Application.OpenForms["Menu"] as Menu;
                    m.CargarIdiomas();
                }
                DgvTraducciones.Columns[1].Visible = false;
                BtnModificarTraduccion.Enabled = false;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, traductor.Traducir("Advertencia", ""), MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void BtnModificarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvIdiomas.SelectedRows.Count == 0) throw new Exception(traductor.Traducir("Debe seleccionar un idioma!!!", ""));
                if (DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString() == "Español" || DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString() == "Ingles") throw new Exception(traductor.Traducir("No se pueden modificar los idiomas principales del sistema!!!", ""));
                if (DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString() == sesion.ObtenerIdiomaSesion()) throw new Exception(traductor.Traducir("No puede modificar el idioma utilizado actualmente!!!", ""));
                string nuevoNombre = Interaction.InputBox(traductor.Traducir("Nuevo nombre", ""));
                if (bllIdioma.IsRepetido(nuevoNombre)) throw new Exception(traductor.Traducir("El idioma ingresado ya se encuentra registrado", ""));
                EntidadIdioma idioma = new EntidadIdioma(nuevoNombre);
                EntidadIdioma idiomaModificar = new EntidadIdioma(DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString());
                bllIdioma.ModificarIdioma(idiomaModificar, idioma);
                Mostrar(DgvIdiomas, LinqIdiomas());
                bool estaAbierto = Application.OpenForms["GUIIdiomas"] != null;
                if (estaAbierto)
                {
                    Menu m = Application.OpenForms["Menu"] as Menu;
                    m.CargarIdiomas();
                }
                b.RegistrarBitacora(b.CrearBitacora(sesion.ObtenerUsuarioActual(), $"Modificó el idioma {idiomaModificar.idioma} a {nuevoNombre}", 1));
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, traductor.Traducir("Advertencia", ""), MessageBoxButtons.OK, MessageBoxIcon.Warning); }   
        }

        private void DgvIdiomas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AgregarColumna(DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString());
            if (DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString() != "Español" && DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString() != "Ingles")
            {
                BtnModificarTraduccion.Enabled = true;
            }
            else
            {
                BtnModificarTraduccion.Enabled = false;
            }
            cambios.Clear();
        }

        private void DgvTraducciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (!DgvTraducciones.Columns.Contains("textoTraducir") ||
                        !DgvTraducciones.Columns.Contains("nuevaColumna"))
                        return;

                    DataGridViewRow fila = DgvTraducciones.Rows[e.RowIndex];

                    string textoTraducir = fila.Cells["textoTraducir"].Value?.ToString();
                    string textoTraducido = fila.Cells["nuevaColumna"].Value?.ToString();

                    if (!string.IsNullOrWhiteSpace(textoTraducir))
                        cambios[textoTraducir] = textoTraducido;
                }
            }
            catch (Exception) { };
        }
    }
}
