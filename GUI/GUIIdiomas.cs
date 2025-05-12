using Microsoft.VisualBasic;
using Servicios;
using Servicios.Entidades;
using Servicios.Logica;
using System;
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
            Mostrar(DgvIdiomas, LinqIdiomas());
            TraducirDgvs();
            BtnModificarTraduccion.Enabled = false;
            Mostrar(DgvTraducciones, LinqTraducciones());
        }
        private void Mostrar(DataGridView dgv, object obj)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
            if(dgv.Name == DgvTraducciones.Name)
            {
                dgv.Columns[0].Visible = false;
                dgv.Columns[1].Visible = false;
                dgv.Columns[2].HeaderText = traductor.Traducir(sesion.ObtenerIdiomaSesion(), "");
                for(int i=0; i<dgv.Columns.Count;i++)
                {
                    if (dgv.Columns[i].Name != "nuevaColumna") dgv.Columns[i].ReadOnly = true;
                }
            }
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
            b.RegistrarBitacora(b.CrearBitacora(sesion.ObtenerUsuarioActual(), "Modificar traducción"));
        }
        private void AgregarColumna(string pIdioma)
        {
            if(DgvTraducciones.Columns.Count > 3) DgvTraducciones.Columns.Remove("nuevaColumna");
            DgvTraducciones.Columns.Add("nuevaColumna", pIdioma);
            List<EntidadTraduccion> lista = bllTraduccion.ListaTraduccion().Where(x => x.idioma == pIdioma).ToList();
            int indexLista = 0;
            lista = lista.OrderBy(x => x.textoTraducir).ToList();
            foreach (DataGridViewRow fila in DgvTraducciones.Rows)
            {
                if (fila.IsNewRow) continue; // evita la fila vacía al final

                var celda = fila.Cells["nuevaColumna"];
                // Si está vacía, la completamos con la lista
                if (celda.Value == null || string.IsNullOrWhiteSpace(celda.Value.ToString()))
                {
                    if (indexLista < lista.Count)
                    {
                        celda.Value = lista[indexLista].textoTraducido;
                        indexLista++;
                    }
                }
            }
            traductor.ActualizarIdioma(sesion.ObtenerIdiomaSesion());
            traductor.Notificar();
            DgvTraducciones.Columns[3].HeaderText = traductor.Traducir(pIdioma,"");
            //if(pIdioma != "Español" && pIdioma != "Ingles") DgvTraducciones.Columns[3].ReadOnly = false;
        }
        private void GUIIdiomas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["Menu"].Show();

        }
        private void BtnAgregarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                string idioma = Interaction.InputBox(traductor.Traducir("Idioma:", ""));
                if (bllIdioma.IsRepetido(idioma)) throw new Exception(traductor.Traducir("El idioma ingresado ya se encuentra registrado!!!", ""));
                EntidadIdioma nuevoIdioma = new EntidadIdioma(idioma);
                bllIdioma.AgregarIdioma(nuevoIdioma);
                Mostrar(DgvIdiomas, LinqIdiomas());
                b.RegistrarBitacora(b.CrearBitacora(sesion.ObtenerUsuarioActual(), "Agregar idioma"));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
                Mostrar(DgvIdiomas, LinqIdiomas());
                Mostrar(DgvTraducciones, LinqTraducciones());
                b.RegistrarBitacora(b.CrearBitacora(sesion.ObtenerUsuarioActual(), "Eliminar idioma"));
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void BtnModificarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvIdiomas.SelectedRows.Count == 0) throw new Exception(traductor.Traducir("Debe seleccionar un idioma!!!", ""));
                if (DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString() == "Español" || DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString() == "Ingles") throw new Exception(traductor.Traducir("No se pueden modificar los idiomas principales del sistema!!!", ""));
                if (DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString() == sesion.ObtenerIdiomaSesion()) throw new Exception(traductor.Traducir("No puede modificar el idioma utilizado actualmente!!!", ""));
                string nuevoNombre = Interaction.InputBox(traductor.Traducir("Nuevo nombre", ""));
                EntidadIdioma idioma = new EntidadIdioma(nuevoNombre);
                EntidadIdioma idiomaModificar = new EntidadIdioma(DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString());
                bllIdioma.ModificarIdioma(idiomaModificar, idioma);
                Mostrar(DgvIdiomas, LinqIdiomas());
                b.RegistrarBitacora(b.CrearBitacora(sesion.ObtenerUsuarioActual(), "Modificar idioma"));
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }   
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
            if(e.RowIndex >= 0)
            {
                DataGridViewRow fila = DgvTraducciones.Rows[e.RowIndex];
                string textoTraducir = fila.Cells[0].Value?.ToString();
                string textoTraducido = fila.Cells[3].Value?.ToString();
                cambios.Add(textoTraducir, textoTraducido);
            }
        }
    }
}
