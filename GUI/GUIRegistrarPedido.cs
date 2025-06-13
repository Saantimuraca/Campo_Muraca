using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Servicios;

namespace GUI
{
    public partial class GUIRegistrarPedido : Form, IObserver
    {
        BLLCliente bllCliente = new BLLCliente();
        BLLProducto bllProducto = new BLLProducto();
        BLLCarrito bllCarrito = new BLLCarrito();
        BLLPedido bllPedido = new BLLPedido();
        public GUIRegistrarPedido()
        {
            InitializeComponent();
            ErrorSeleccionCliente.Visible = false;
            CargarClientes();
            Traductor.INSTANCIA.Suscribir(this);
            Traductor.INSTANCIA.Notificar();
            Mostrar(DgvProductos, LinqProductos());
            numericUpDown1.Enabled = false;
            BtnAgregarCarrito.Enabled = false;
            BtnEliminarProductoCarrito.Enabled = false;
            BtnModificarCantidad.Enabled = false;
            BtnNotificarBajoStock.Enabled = false;
            BtnVaciarCarrito.Enabled=false;
            BtnRegistrarPedido.Enabled=false;
            DgvCarrito.Columns[1].HeaderText = Traductor.INSTANCIA.Traducir("Producto", "");
            DgvCarrito.Columns[2].HeaderText = Traductor.INSTANCIA.Traducir("Cantidad", "");
            DgvCarrito.Columns[3].HeaderText = Traductor.INSTANCIA.Traducir("Precio unitario", "");
        }

        public void CargarClientes()
        {
            comboBox1.Items.Clear();
            foreach (BECliente cliente in bllCliente.ListaClientes())
            {
                comboBox1.Items.Add($"{cliente.dni}, {cliente.nombre}");
            }
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            string texto = comboBox1.Text.Trim();

            // Limpia los ítems actuales
            comboBox1.Items.Clear();

            List<BECliente> resultados;

            if (string.IsNullOrEmpty(texto)) return;

            // Si es número busca por DNI
            if (texto.All(char.IsDigit))
            {
                resultados = bllCliente.ListaClientes()
                    .Where(c => c.dni.ToString().StartsWith(texto))
                    .ToList();
            }
            else // si empieza con letra busca por nombre
            {
                resultados = bllCliente.ListaClientes()
                    .Where(c => c.nombre.StartsWith(texto, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Agrega los ítems que coinciden
            foreach (var cliente in resultados)
            {
                comboBox1.Items.Add($"{cliente.dni}, {cliente.nombre}");
            }

            comboBox1.SelectionStart = comboBox1.Text.Length;
            if (resultados.Any())
            {
                comboBox1.DroppedDown = true;
            }
            else
            {
                comboBox1.DroppedDown = false;
            }
        }

        private void Mostrar(DataGridView dgv, object obj)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
            if(dgv.Name == "DgvProductos")
            {
                numericUpDown1.Enabled = false;
                BtnAgregarCarrito.Enabled = false;
                BtnNotificarBajoStock.Enabled = false;
                dgv.Columns["stockeado"].Visible = false;
                dgv.Columns[0].HeaderText = Traductor.INSTANCIA.Traducir("CODIGO", "");
                dgv.Columns[1].HeaderText = Traductor.INSTANCIA.Traducir("NOMBRE", "");
                dgv.Columns[2].HeaderText = Traductor.INSTANCIA.Traducir("DESCRIPCIÓN", "");
                dgv.Columns[3].HeaderText = Traductor.INSTANCIA.Traducir("PRECIO", "");
                dgv.Columns[4].HeaderText = Traductor.INSTANCIA.Traducir("STOCK", "");
                dgv.Columns[5].HeaderText = Traductor.INSTANCIA.Traducir("CATEGORÍA", "");
            }
            
        }

        private object LinqProductos()
        {
            return (from p in bllProducto.ListarProductos() where p.estado == true select new { ID = p.idProducto, Nombre = p.nombre, Descripción = p.descripcion, Precio = $"${p.precio}", Stock = p.stock, Categoria = p.categoria.nombre, stockeado = p.isBajoStock }).ToList();
        }

        private void BtnNuevoCliente_Click(object sender, EventArgs e)
        {
            GUIRegistrarCliente gui = new GUIRegistrarCliente(1, this);
            gui.Show(); 
        }

        private void GUIRegistrarPedido_FormClosed(object sender, FormClosedEventArgs e)
        {
            BECarrito.INSTANCIA.BorrarCarrito();
            Application.OpenForms["Menu"].Show();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == null) { ErrorSeleccionCliente.Visible = true; BtnAgregarCarrito.Enabled = false; BtnEliminarProductoCarrito.Enabled = false;
                BtnNotificarBajoStock.Enabled = false;}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorSeleccionCliente.Visible = false;
        }

        private void DgvProductos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            numericUpDown1.Enabled = true;
            numericUpDown1.Minimum = 1;
            numericUpDown1.Value = 1;
            numericUpDown1.Maximum = int.Parse(DgvProductos.SelectedRows[0].Cells[4].Value.ToString());
            if (int.Parse(DgvProductos.SelectedRows[0].Cells[0].Value.ToString()) == 0 || comboBox1.SelectedItem == null) { BtnAgregarCarrito.Enabled = false; }
            else { BtnAgregarCarrito.Enabled = true; }
            BtnNotificarBajoStock.Enabled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown1.Value > 0 && numericUpDown1.Value <= numericUpDown1.Maximum && DgvProductos.SelectedRows.Count != 0) { BtnAgregarCarrito.Enabled = true; }
            else { BtnAgregarCarrito.Enabled = false; }
        }

        private void BtnAgregarCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllCarrito.ProductoAgregado(int.Parse(DgvProductos.SelectedRows[0].Cells[0].Value.ToString()))) throw new Exception(Traductor.INSTANCIA.Traducir("Este producto ya se encuentra en el carrito", ""));
                bllCarrito.AgregarProductoCarrito(int.Parse(DgvProductos.SelectedRows[0].Cells[0].Value.ToString()), int.Parse(numericUpDown1.Value.ToString()));
                ActualizarCarrito();
                Mostrar(DgvProductos, LinqProductos());
                LBLTotal.Text = Traductor.INSTANCIA.Traducir("Total: ${calculoTotal}", "");
                LBLTotal.Text = LBLTotal.Text.Replace("{calculoTotal}", CalcularTotalGeneral().ToString());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, Traductor.INSTANCIA.Traducir("Advertencia", ""), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); }
        }

        private void ActualizarCarrito()
        {
            DgvCarrito.Rows.Clear();
            foreach(var p in BECarrito.INSTANCIA.d)
            {
                BEProducto producto = bllProducto.ListarProductos().Find(x => x.idProducto == p.Key);
                DgvCarrito.Rows.Add(producto.idProducto, producto.nombre, p.Value, $"${producto.precio}");
            }
            BtnEliminarProductoCarrito.Enabled = false;
            BtnModificarCantidad.Enabled = false;
            numericUpDown1.Enabled = false;
            if(DgvCarrito.Rows.Count > 0) { BtnVaciarCarrito.Enabled = true; BtnRegistrarPedido.Enabled = true; }
            else { BtnVaciarCarrito.Enabled = false; BtnRegistrarPedido.Enabled = false; }
        }

        private decimal CalcularTotalGeneral()
        {
            decimal totalGeneral = 0;

            foreach (DataGridViewRow fila in DgvCarrito.Rows)
            {
                if (fila.IsNewRow) continue; 
                if (int.TryParse(fila.Cells[2].Value?.ToString(), out int cantidad) &&
                    decimal.TryParse(fila.Cells[3].Value?.ToString().Replace("$", ""), out decimal precioUnitario))
                {
                    totalGeneral += cantidad * precioUnitario;
                }
            }
            return totalGeneral;
        }

        private void DgvCarrito_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BtnEliminarProductoCarrito.Enabled = true;
            BEProducto producto = bllProducto.ListarProductos().Find(x => x.idProducto == int.Parse(DgvCarrito.SelectedRows[0].Cells[0].Value.ToString()));
            numericUpDown1.Value = int.Parse(DgvCarrito.SelectedRows[0].Cells[2].Value.ToString());
            numericUpDown1.Maximum = producto.stock;
            BtnModificarCantidad.Enabled = true;
            numericUpDown1.Enabled = true;
        }

        private void BtnEliminarProductoCarrito_Click(object sender, EventArgs e)
        {
            bllCarrito.EliminarProductoCarrito(int.Parse(DgvCarrito.SelectedRows[0].Cells[0].Value.ToString()));
            ActualizarCarrito();
            LBLTotal.Text = Traductor.INSTANCIA.Traducir("Total: ${calculoTotal}", "");
            LBLTotal.Text = LBLTotal.Text.Replace("{calculoTotal}", CalcularTotalGeneral().ToString());
        }

        private void BtnModificarCantidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(numericUpDown1.Value.ToString()) == int.Parse(DgvCarrito.SelectedRows[0].Cells[2].Value.ToString())) throw new Exception("Esta es la cantidad actual");
                bllCarrito.ModificarCantidadProducto(int.Parse(DgvCarrito.SelectedRows[0].Cells[0].Value.ToString()), int.Parse(numericUpDown1.Value.ToString()));
                ActualizarCarrito();
                LBLTotal.Text = Traductor.INSTANCIA.Traducir("Total: ${calculoTotal}", "");
                LBLTotal.Text = LBLTotal.Text.Replace("{calculoTotal}", CalcularTotalGeneral().ToString());
            }
            catch (Exception ex) {MessageBox.Show(ex.Message, Traductor.INSTANCIA.Traducir("Advertencia", ""), MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void BtnNotificarBajoStock_Click(object sender, EventArgs e)
        {
            bllProducto.NotificarBajoStock(int.Parse(DgvProductos.SelectedRows[0].Cells[0].Value.ToString()));
            Mostrar(DgvProductos, LinqProductos());
        }

        private void DgvProductos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DgvProductos.Rows)
            {
                if (bool.Parse(row.Cells[6].Value.ToString()))
                {
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                }
            }
            DgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            DgvProductos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        }

        private void BtnVaciarCarrito_Click(object sender, EventArgs e)
        {
            bllCarrito.VaciarCarrito();
            ActualizarCarrito();
            LBLTotal.Text = Traductor.INSTANCIA.Traducir("Total: ${calculoTotal}", "");
            LBLTotal.Text = LBLTotal.Text.Replace("{calculoTotal}", CalcularTotalGeneral().ToString());
        }

        private void BtnRegistrarPedido_Click(object sender, EventArgs e)
        {
            string[] vectorCb = comboBox1.SelectedItem.ToString().Split(',');
            BECliente cliente = bllCliente.ListaClientes().Find(x => x.dni == vectorCb[0]);
            string estado = CalcularTotalGeneral() > 5000000 ? "En evaluación" : "Confirmado";
            BEPedido pedido = new BEPedido(cliente, estado, DateTime.Now, CalcularTotalGeneral(), Sesion.INSTANCIA.ObtenerUsuarioActual().Dni_Usuario);
            bllPedido.Agregar(pedido, BECarrito.INSTANCIA.d);
            MessageBox.Show(Traductor.INSTANCIA.Traducir("Pedido registrado", ""), Traductor.INSTANCIA.Traducir("Información", ""), MessageBoxButtons.OK, MessageBoxIcon.Information);
            bllCarrito.VaciarCarrito();
            ActualizarCarrito();
            LBLTotal.Text = Traductor.INSTANCIA.Traducir("Total: ${calculoTotal}", "");
            LBLTotal.Text = LBLTotal.Text.Replace("{calculoTotal}", CalcularTotalGeneral().ToString());
            Mostrar(DgvProductos, LinqProductos());
            numericUpDown1.Value = 1;
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
