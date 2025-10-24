using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;

namespace GUI
{
    public partial class GUIEvaluarViabilidad : Form
    {
        BLLPago BLLPago = new BLLPago();
        BLLMovimientoCaja bllMovimiento = new BLLMovimientoCaja();
        public GUIEvaluarViabilidad()
        {
            InitializeComponent();
            chartSueldos.Visible = false;
            BtnAprobar.Enabled = false;
            BtnRechazar.Enabled = false;
            LblDetalle.Visible = false;
            textBox1.Visible = false;
        }

        private void Mostrar(DataGridView dgv, object obj)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
            dgv.Columns[0].Visible = false;
            if(comboBox2.SelectedItem.ToString() == "Rechazado" || comboBox2.SelectedItem.ToString() == "Pendiente" || comboBox2.SelectedItem.ToString() == "En Revisión")
            {
                dgv.Columns[2].Visible = false;
                dgv.Columns[4].Visible = false;
            }
            else
            {
                dgv.Columns[2].Visible = true;
                dgv.Columns[4].Visible = true;
            }
            LblDetalle.Visible = false;
            textBox1.Visible = false;
        }

        private object Linq()
        {
            return (from p in BLLPago.ListarPagos() where p.estado == comboBox2.SelectedItem.ToString() select new { ID = p.id, Estado = p.estado, Fecha_Pago = p.fechaPago, Fecha_Solicitud = p.fecha, Metodo_Pago = p.metodoPago, Total = $"${p.monto}" }).ToList();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                Mostrar(Dgv, Linq());
                if (comboBox2.SelectedItem.ToString() != "En Revisión") { BtnAprobar.Enabled = false; BtnRechazar.Enabled = false; }
            }
        }

        private void Dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(Dgv.SelectedRows.Count != 0)
            {
                if(comboBox2.SelectedItem.ToString() != "En Revisión")
                {
                    textBox1.Text = "";
                    LblDetalle.Visible = true;
                    textBox1.Visible = true;
                    foreach (var par in BLLPago.DetallePago(int.Parse(Dgv.SelectedRows[0].Cells[0].Value.ToString())))
                    {
                        textBox1.Text += $"{par.Key} ${par.Value}" + Environment.NewLine + Environment.NewLine;
                    }
                    textBox1.Text += "\r\n-------------------------------------------------------------------------------------\r\n";
                    textBox1.Text += "Total:" +
                        "" + Dgv.SelectedRows[0].Cells[5].Value.ToString();
                }
                if (Dgv.SelectedRows[0].Cells[1].Value.ToString() == "En Revisión") { BtnAprobar.Enabled = true; BtnRechazar.Enabled = true; }
                else { BtnAprobar.Enabled = false; BtnRechazar.Enabled = false; }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Gráfico de sueldos por área") { GraficarSueldoArea(); }
            else { GraficarGastosGanancia(); }
        }

        private void GraficarSueldoArea()
        {
            chartSueldos.Visible = true;
            chartSueldos.Series.Clear();
            chartSueldos.ChartAreas.Clear();
            chartSueldos.Titles.Clear();
            chartSueldos.Legends.Clear();
            ChartArea area = new ChartArea("MainArea");
            area.BackColor = Color.White;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = -25; 
            chartSueldos.ChartAreas.Add(area);
            Legend legend = new Legend("Leyenda");
            legend.BackColor = Color.Transparent;
            legend.Docking = Docking.Right; 
            chartSueldos.Legends.Add(legend);
            Series serie = new Series("Sueldos por Área");
            serie.ChartType = SeriesChartType.Column;
            serie.IsValueShownAsLabel = true;
            serie.LabelForeColor = Color.Black;
            serie.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            serie["PointWidth"] = "0.5";
            serie["PixelPointWidth"] = "45"; 
            serie.Palette = ChartColorPalette.BrightPastel;
            foreach (var par in BLLPago.SueldosArea(BLLPago.ObtenerPagoMasReciente().id))
            {
                serie.Points.AddXY(par.Key, par.Value);
            }
            chartSueldos.Series.Add(serie);
            chartSueldos.Titles.Add("Distribución de Sueldos por Área");
            chartSueldos.Titles[0].Font = new Font("Segoe UI", 10, FontStyle.Bold);
            chartSueldos.Titles[0].ForeColor = Color.Black;
            chartSueldos.Dock = DockStyle.None;
            chartSueldos.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            chartSueldos.Size = new Size(500, 350);
        }

        private void GraficarGastosGanancia()
        {
            chartSueldos.Visible = true;
            var b = bllMovimiento.Balance();
            decimal ingresos = b["Ingresos"];
            decimal sueldos = b["Sueldos"];
            decimal otros = b["Otros Gastos"];
            chartSueldos.ChartAreas.Clear();
            chartSueldos.Series.Clear();
            chartSueldos.Titles.Clear();
            chartSueldos.Legends.Clear();
            chartSueldos.Titles.Add("Balance Financiero Mensual");
            ChartArea area = new ChartArea("MainArea");
            area.AxisY.LabelStyle.Format = "C0";
            area.AxisY.Title = "Monto ($)";
            area.AxisX.Interval = 1;
            chartSueldos.ChartAreas.Add(area);
            Series sIngresos = new Series("Ingresos");
            sIngresos.ChartType = SeriesChartType.Column;
            sIngresos.IsValueShownAsLabel = true;
            sIngresos.Color = Color.SeaGreen;
            sIngresos.Points.AddXY("Mes actual", (double)ingresos);
            Series sSueldos = new Series("Sueldos");
            sSueldos.ChartType = SeriesChartType.Column;
            sSueldos.IsValueShownAsLabel = true;
            sSueldos.Color = Color.IndianRed;
            sSueldos.Points.AddXY("Mes actual", (double)sueldos);
            Series sOtros = new Series("Otros Gastos");
            sOtros.ChartType = SeriesChartType.Column;
            sOtros.IsValueShownAsLabel = true;
            sOtros.Color = Color.Goldenrod;
            sOtros.Points.AddXY("Mes actual", (double)otros);
            chartSueldos.Series.Add(sIngresos);
            chartSueldos.Series.Add(sSueldos);
            chartSueldos.Series.Add(sOtros);
            Legend leyenda = new Legend("Leyenda");
            leyenda.Docking = Docking.Bottom;
            leyenda.Alignment = StringAlignment.Center;
            leyenda.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            chartSueldos.Legends.Add(leyenda);
        }

        private void BtnAprobar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea aprobar este pago?", "Confirmar aprobación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    BLLPago.CambiarEstado("Aprobado", int.Parse(Dgv.SelectedRows[0].Cells[0].Value.ToString()));
                    Mostrar(Dgv, Linq());
                    BtnAprobar.Enabled = false;
                    BtnRechazar.Enabled = false;
                    MessageBox.Show("Pago aprobado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRechazar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea rechazar este pago?", "Confirmar rechazo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    BLLPago.CambiarEstado("Rechazado", int.Parse(Dgv.SelectedRows[0].Cells[0].Value.ToString()));
                    Mostrar(Dgv, Linq());
                    BtnAprobar.Enabled = false;
                    BtnRechazar.Enabled = false;
                    MessageBox.Show("Pago rechazado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
