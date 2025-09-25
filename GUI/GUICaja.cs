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
using Servicios.Logica;

namespace GUI
{
    public partial class GUICaja : Form
    {
        List<Label> errores = new List<Label>();
        BLLMovimientoCaja bllMbvimiento = new BLLMovimientoCaja();
        LogicaBitacora bitacora = new LogicaBitacora();
        public GUICaja()
        {
            InitializeComponent();
            ErrorNombre.Visible = false;
            errores.Clear();
            foreach(Control ctrl in this.Controls)
            {
                if(ctrl is Label && ctrl.Name.StartsWith("Error"))
                {
                    errores.Add(ctrl as Label);
                }
            }
            Mostrar(Dgv, Linq());
            ErrorImporte.Visible = false;
            ErrorRol.Visible=false;
            ErrorTipo.Visible=false;
            LblTotalCaja.Text = $"Caja: $" + bllMbvimiento.CalcularTotalCaja().ToString();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(TxtDescripcion.Text)) { ErrorNombre.Visible = true; }
                if(!decimal.TryParse(TxtImporte.Text, out decimal importe)) { ErrorImporte.Visible = true; }
                if(comboBox1.SelectedItem == null) { ErrorRol.Visible = true; }
                if(comboBox2.SelectedItem == null) { ErrorTipo.Visible = true; }
                if (importe > bllMbvimiento.CalcularTotalCaja() && comboBox2.SelectedItem.ToString() == "Egreso") throw new Exception("El saldo de la caja es menor al importe ingresado");
                if(IsHabilitado())
                {
                    BEMovimientoCaja movimientoCaja = new BEMovimientoCaja(TxtDescripcion.Text, DateTime.Now, importe, comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString() == "Ingreso" ? true:false);
                    bllMbvimiento.Agregar(movimientoCaja);
                    Mostrar(Dgv, Linq());
                    LimpiarControles();
                    LblTotalCaja.Text = $"Caja: $" + bllMbvimiento.CalcularTotalCaja().ToString();
                    bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.INSTANCIA.ObtenerUsuarioActual(), "Registró un movimiento en caja", 3));
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void LimpiarControles()
        {
            TxtDescripcion.Text = "";
            TxtImporte.Text = "";
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
        }

        private void Mostrar(DataGridView dgv, object obj)
        {
            Dgv.DataSource = null;
            Dgv.DataSource = obj;
            Dgv.Columns["Metodo_Pago"].HeaderText = "Método de pago";
        }

        private object Linq()
        {
            return (from m in bllMbvimiento.Movimientos() select new {ID = m.id, Descripción = m.descripcion, Fecha = m.fecha, Importe = m.importe, Metodo_Pago = m.metodoPago, 
            Tipo = m.tipo == true ? "Ingreso":"Egreso"}).ToList();
        }

        private bool IsHabilitado()
        {
            foreach(Label label in errores)
            {
                if(label.Visible) { return false; }
            }
            return true;
        }

        private void TxtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            ErrorNombre.Visible = false;
        }

        private void TxtImporte_KeyUp(object sender, KeyEventArgs e)
        {
            ErrorImporte.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null) { ErrorRol.Visible = false;}
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null) { ErrorTipo.Visible = false; }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if(Dgv.SelectedRows.Count > 0)
                {
                    if (string.IsNullOrWhiteSpace(TxtDescripcion.Text)) { ErrorNombre.Visible = true; }
                    if (!decimal.TryParse(TxtImporte.Text, out decimal importe)) { ErrorImporte.Visible = true; }
                    if (importe > bllMbvimiento.CalcularTotalCaja() && comboBox2.SelectedItem.ToString() == "Egreso") throw new Exception("El saldo de la caja es menor al importe ingresado");
                    BEMovimientoCaja movimiento = new BEMovimientoCaja(TxtDescripcion.Text, DateTime.Parse(Dgv.SelectedRows[0].Cells["Fecha"].Value.ToString()), importe, comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString() == "Ingreso" ? true : false, 
                        int.Parse(Dgv.SelectedRows[0].Cells["ID"].Value.ToString()));
                    if(IsHabilitado())
                    {
                        bllMbvimiento.Modificar(movimiento);
                        Mostrar(Dgv, Linq());
                        LimpiarControles();
                        LblTotalCaja.Text = $"Caja: $" + bllMbvimiento.CalcularTotalCaja().ToString();
                    }

                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }

        private void Dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(Dgv.SelectedRows.Count > 0)
            {
                TxtDescripcion.Text = Dgv.SelectedRows[0].Cells["Descripción"].Value.ToString();
                TxtImporte.Text = Dgv.SelectedRows[0].Cells["Importe"].Value.ToString();
                comboBox1.SelectedItem = Dgv.SelectedRows[0].Cells["Metodo_Pago"].Value.ToString();
                comboBox2.SelectedItem = Dgv.SelectedRows[0].Cells["Tipo"].Value.ToString();
            }
        }
    }
}
