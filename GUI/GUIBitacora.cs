using Servicios;
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
    public partial class GUIBitacroa_ : Form, IObserver
    {
        Traductor traductor = Traductor.INSTANCIA;
        public GUIBitacroa_()
        {
            InitializeComponent();
            this.Load += GUIBitacroa__Load;
            traductor.Suscribir(this);
            traductor.Notificar();
        }

        public object LinqBitacora()
        {
            LogicaBitacora bitacora = new LogicaBitacora();
            return (from b in bitacora.ListaBitacora() select new { FECHA_HORA = b.fechaHora, USUARIO = b.usuario.Nombre_Usuario, ACCION = b.accion, CRITICIDAD = b.criticidad}).ToList();
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GUIBitacroa__FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["Menu"].Show();
        }

        private void BtnFiltrarFecha_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime desde = dateTimePicker1.Value;
                DateTime hasta = dateTimePicker2.Value;
                Mostrar(Dgv, LinqBitacoraFecha(desde, hasta));
            }
            catch
            {
                MessageBox.Show(traductor.Traducir("No se pudo realizar la consulta", ""), traductor.Traducir("Advertencia", ""), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Mostrar(DataGridView dgv, object obj)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
        }

        public object LinqBitacoraFecha(DateTime pDesde, DateTime pHasta)
        {
            LogicaBitacora bitacora = new LogicaBitacora();
            return (from b in bitacora.ListaBitacoraFecha(pDesde, pHasta) select new { FECHA_HORA = b.fechaHora, USUARIO = b.usuario.Nombre_Usuario, ACCION = b.accion, CRITICIDAD = b.criticidad }).ToList();
        }

        private void BtnFiltrarCriticidad_Click(object sender, EventArgs e)
        {
            try
            {
                Mostrar(Dgv, LinqBitacoraCriticidad(int.Parse(comboBox1.SelectedItem.ToString())));
            }
            catch { MessageBox.Show(traductor.Traducir("No se pudo realizar la consulta", ""), traductor.Traducir("Advertencia", ""), MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public object LinqBitacoraCriticidad(int pCriticidad)
        {
            LogicaBitacora bitacora = new LogicaBitacora();
            return (from b in bitacora.ListaBitacoraCriticidad(pCriticidad) select new { FECHA_HORA = b.fechaHora, USUARIO = b.usuario.Nombre_Usuario, ACCION = b.accion, CRITICIDAD = b.criticidad }).ToList();
        }

        public void ActualizarLenguaje()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button || ctrl is Label)
                {
                    ctrl.Text = traductor.Traducir(ctrl.Name, Sesion.INSTANCIA.ObtenerIdiomaSesion());
                }
            }
        }

        private void Dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach(DataGridViewRow row in Dgv.Rows)
            {
                switch (int.Parse(row.Cells[3].Value.ToString()))
                {
                    case 1: row.DefaultCellStyle.BackColor = Color.GreenYellow; break;
                    case 2: row.DefaultCellStyle.BackColor = Color.Coral; break;
                    case 3: row.DefaultCellStyle.BackColor = Color.Orange; break;
                    case 4: row.DefaultCellStyle.BackColor = Color.OrangeRed; break;
                    case 5: row.DefaultCellStyle.BackColor = Color.Firebrick; break;
                    default: break;
                }
            }
            if (Dgv.Columns.Count > 0)
            {
                Dgv.Columns[0].HeaderText = traductor.Traducir("Fecha y hora", "");
                Dgv.Columns[1].HeaderText = traductor.Traducir("UsuarioB", "");
                Dgv.Columns[2].HeaderText = traductor.Traducir("Acción", "");
                Dgv.Columns[3].HeaderText = traductor.Traducir("Criticidad", "");
            }
        }

        private void GUIBitacroa__Load(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => Mostrar(Dgv, LinqBitacora())));
        }
    }
}
