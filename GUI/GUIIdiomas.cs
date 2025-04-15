using BE;
using BLL;
using Microsoft.VisualBasic;
using Servicios;
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
using static System.Collections.Specialized.BitVector32;

namespace GUI
{
    public partial class GUIIdiomas : Form, IObserver
    {
        BLLIdioma bllIdioma = new BLLIdioma();
        Sesion sesion = Sesion.INSTANCIA;
        Traductor traductor = Traductor.INSTANCIA;
        BLLTraduccion bllTraduccion = new BLLTraduccion();
        List<BETraduccion> listaAux = new List<BETraduccion>();
        Bitacora b = new Bitacora();
        public GUIIdiomas()
        {
            InitializeComponent();
            traductor.Suscribir(this);
            traductor.Notificar();
            Mostrar(DgvIdiomas, LinqIdiomas());
            TraducirDgvs();
            Mostrar(DgvIdiomaActual, LinqIdiomaActual());
            DgvIdiomaActual.Columns[0].Visible = false;
            TxtBusqueda.Text = "";
            TxtTraduccion.Text = "";
            BtnModificarTraduccion.Enabled = false;
            LBL_IdiomaActual.Text = sesion.ObtenerIdiomaSesion();
            LBL_IdiomaSeleccionado.Visible = false;
            LBL_Seleccion.Visible = false;
            CargarCb();
            DgvIdiomaActual.Columns[1].HeaderText = traductor.Traducir("TEXTO", "");
        }

        private void Mostrar(DataGridView dgv, object obj)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
        }

        private void CargarCb()
        {
            CbIdiomas.Items.Clear();
            foreach(BEIdioma idioma in bllIdioma.ListaIdiomas())
            {
                CbIdiomas.Items.Add(idioma.idioma);
            }
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


        private object LinqIdiomaActual()
        {
            List<BETraduccion> lista = new List<BETraduccion>();
            foreach(BETraduccion traduccion in bllTraduccion.ListaTraduccion())
            {
                if(traduccion.idioma == sesion.ObtenerIdiomaSesion())
                {
                    lista.Add(traduccion);
                }
            }
            return (from i in lista select new { CODIGO = i.textoTraducir, TEXTO = i.textoTraducido }).ToList();
        }

        private void DgvIdiomas_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Mostrar(DgvIdiomaSeleccionado, LinqIdiomaSeleccionado(DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString()));
            DgvIdiomaSeleccionado.Columns[0].Visible = false;
            TxtTraduccion.Text = "";
            LBL_IdiomaSeleccionado.Visible = true;
            LBL_IdiomaSeleccionado.Text = DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString();
            LBL_Seleccion.Visible = true;
            DgvIdiomaSeleccionado.Columns[1].HeaderText = traductor.Traducir("TEXTO", "");
        }

        private object LinqIdiomaSeleccionado(string pIdioma)
        {
            List<BETraduccion> lista = new List<BETraduccion>();
            foreach (BETraduccion traduccion in bllTraduccion.ListaTraduccion())
            {
                if(traduccion.idioma == pIdioma)
                {
                    lista.Add(traduccion);
                }
            }
            return (from i in lista select new { CODIGO = i.textoTraducir, TEXTO = i.textoTraducido }).ToList();
        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
                listaAux.Clear();
                string consulta = $"textoTraducido LIKE '{TxtBusqueda.Text}%'";
                Mostrar(DgvIdiomaActual, LinqIncremental(consulta, bllTraduccion.ListaIncremental(consulta, sesion.ObtenerIdiomaSesion())));
                DgvIdiomaActual.Columns[0].Visible = false;
                if (DgvIdiomas.SelectedRows.Count != 0)
                {
                 traductor.ActualizarIdioma(DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString());
                foreach (BETraduccion traduccion in bllTraduccion.ListaIncremental(consulta, sesion.ObtenerIdiomaSesion()))
                {
                        BETraduccion nt = new BETraduccion(traduccion.textoTraducir, DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString(), traductor.Traducir(traduccion.textoTraducir, DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString()));
                        listaAux.Add(nt);
                }
                    Mostrar(DgvIdiomaSeleccionado, LinqIncremental(consulta, listaAux));
                    DgvIdiomaSeleccionado.Columns[0].Visible = false;
                    traductor.ActualizarIdioma(sesion.ObtenerIdiomaSesion());
                }
            TxtTraduccion.Text = "";
        }

        private object LinqIncremental(string consulta, List<BETraduccion> lista)
        {
            return (from i in lista select new { CODIGO = i.textoTraducir, TEXTO = i.textoTraducido }).ToList();
        }

        private void BtnModificarTraduccion_Click(object sender, EventArgs e)
        {
            BETraduccion traduccion = new BETraduccion(DgvIdiomaActual.SelectedRows[0].Cells[0].Value.ToString(), CbIdiomas.SelectedItem.ToString(), TxtTraduccion.Text);
            bllTraduccion.ModificarTraduccion(traduccion);
            traductor.ActualizarIdioma(sesion.ObtenerIdiomaSesion());
            traductor.Notificar();
            Mostrar(DgvIdiomaActual, LinqIdiomaActual());
            DgvIdiomaActual.Columns[0].Visible = false;
            if(DgvIdiomaSeleccionado.SelectedRows.Count != 0)
            {
                Mostrar(DgvIdiomaSeleccionado, LinqIdiomaSeleccionado(DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString()));
                DgvIdiomaSeleccionado.Columns[0].Visible = false;
            } 
            TxtBusqueda.Text = "";
            b.RegistrarBitacora(b.CrearBitacora(sesion.ObtenerUsuarioActual(), "Modificar traducción"));
            LBL_IdiomaSeleccionado.Visible = false;
            LBL_Seleccion.Visible = false;
        }

        private void TxtTraduccion_TextChanged(object sender, EventArgs e)
        {
            if(TxtTraduccion.Text.Length > 0)
            {
                BtnModificarTraduccion.Enabled = true;
            }
            else
            {
                BtnModificarTraduccion.Enabled = false;
            }
        }

        private void GUIIdiomas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["Menu"].Show();

        }

        

        private void DgvIdiomaActual_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(CbIdiomas.SelectedItem != null)
            {
                traductor.ActualizarIdioma(CbIdiomas.SelectedItem.ToString());
                string traduccion = traductor.Traducir(DgvIdiomaActual.SelectedRows[0].Cells[0].Value.ToString(), "");
                if (string.IsNullOrEmpty(traduccion)) TxtTraduccion.Text = traductor.Traducir("Sin traducción", "");
                else TxtTraduccion.Text = traduccion;
                traductor.ActualizarIdioma(sesion.ObtenerIdiomaSesion());
            }
        }

        private void BtnAgregarIdioma_Click(object sender, EventArgs e)
        {
            try
            {
                string idioma = Interaction.InputBox(traductor.Traducir("Idioma:", ""));
                if (bllIdioma.IsRepetido(idioma)) throw new Exception(traductor.Traducir("El idioma ingresado ya se encuentra registrado!!!", ""));
                BEIdioma nuevoIdioma = new BEIdioma(idioma);
                bllIdioma.AgregarIdioma(nuevoIdioma);
                Mostrar(DgvIdiomas, LinqIdiomas());
                Mostrar(DgvIdiomaActual, LinqIdiomaActual());
                DgvIdiomaActual.Columns[0].Visible = false;
                CargarCb();
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
                BEIdioma idioma = new BEIdioma(DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString());
                bllIdioma.EliminarIdioma(idioma);
                Mostrar(DgvIdiomas, LinqIdiomas());
                DgvIdiomaSeleccionado.DataSource = null;
                TxtTraduccion.Text = "";
                TxtBusqueda.Text = "";
                LBL_IdiomaSeleccionado.Visible = false;
                CargarCb();
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
                BEIdioma idioma = new BEIdioma(nuevoNombre);
                BEIdioma idiomaModificar = new BEIdioma(DgvIdiomas.SelectedRows[0].Cells[0].Value.ToString());
                bllIdioma.ModificarIdioma(idiomaModificar, idioma);
                Mostrar(DgvIdiomas, LinqIdiomas());
                DgvIdiomaSeleccionado.DataSource = null;
                TxtTraduccion.Text = "";
                TxtBusqueda.Text = "";
                LBL_IdiomaSeleccionado.Visible = false;
                CargarCb();
                b.RegistrarBitacora(b.CrearBitacora(sesion.ObtenerUsuarioActual(), "Modificar idioma"));
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }   
        }

        private void DgvIdiomaActual_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
