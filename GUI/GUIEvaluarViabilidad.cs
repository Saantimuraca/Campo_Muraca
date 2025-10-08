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

namespace GUI
{
    public partial class GUIEvaluarViabilidad : Form
    {
        BLLPago BLLPago = new BLLPago();
        public GUIEvaluarViabilidad()
        {
            InitializeComponent();
        }

        private void Mostrar(DataGridView dgv, object obj)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
            dgv.Columns[0].Visible = false;
            if(comboBox1.SelectedItem.ToString() == "Rechazado" || comboBox1.SelectedItem.ToString() == "Pendiente" || comboBox1.SelectedItem.ToString() == "En Revisión")
            {
                dgv.Columns[2].Visible = false;
                dgv.Columns[4].Visible = false;
            }
        }

        private object Linq()
        {
            return (from p in BLLPago.ListarPagos() where p.estado == comboBox2.SelectedItem.ToString() select new { ID = p.id, Estado = p.estado, Fecha_Pago = p.fechaPago, Fecha_Solicitud = p.fecha, Metodo_Pago = p.metodoPago, Total = $"${p.monto}" }).ToList();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedItem != null)
            {
                Mostrar(Dgv, Linq());
            }
        }
    }
}
