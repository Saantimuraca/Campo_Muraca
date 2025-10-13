using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class GUIPagos : Form
    {
        BLLPago bllPago = new BLLPago();
        public GUIPagos()
        {
            InitializeComponent();
            dateTimePicker1.Enabled = false;
            BtnAsentarPago.Enabled = false;
        }

        private void Mostrar(DataGridView dgv, object obj)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
            dgv.Columns[0].Visible = false;
            if (comboBox1.SelectedItem.ToString() == "Rechazado" || comboBox1.SelectedItem.ToString() == "Aprobado" || comboBox1.SelectedItem.ToString() == "En Revisión")
            {
                dgv.Columns[2].Visible = false;
                dgv.Columns[4].Visible = false;
            }
            else
            {
                dgv.Columns[2].Visible = true;
                dgv.Columns[4].Visible = true;
            }
        }

        private object Linq()
        {
            return (from p in bllPago.ListarPagos() where p.estado == comboBox1.SelectedItem.ToString() select new { ID = p.id, Estado = p.estado, Fecha_Pago = p.fechaPago, Fecha_Solicitud = p.fecha, Metodo_Pago = p.metodoPago, Total = $"${p.monto}" }).ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mostrar(Dgv, Linq());
        }

        private void Dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "Aprobado" && Dgv.SelectedRows.Count != 0)
            {
                BtnAsentarPago.Enabled = true;
            }
            else
            {
                BtnAsentarPago.Enabled = false;
            }
        }

        private void BtnAsentarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBox2.SelectedItem == null) throw new Exception("Seleccione un método de pago.");
                DateTime fecha = dateTimePicker1.Value;
                int idPago = (int)Dgv.SelectedRows[0].Cells[0].Value;
                string metodoPago = comboBox2.SelectedItem.ToString();
                bllPago.AsentarPago(idPago, metodoPago, fecha);
                MessageBox.Show("Pago asentado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mostrar(Dgv, Linq());
                BtnAsentarPago.Enabled = false;
                comboBox2.SelectedItem = null;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
    }
}
