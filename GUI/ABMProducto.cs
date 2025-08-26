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

namespace GUI
{
    public partial class ABMProducto : Form
    {
        List<Label> labels = new List<Label>();
        BLLCategoria bllCategoria = new BLLCategoria();
        BLLProducto BLLProducto = new BLLProducto();
        public ABMProducto()
        {
            InitializeComponent();
            labels.Clear();
            foreach(Control ctrl in this.Controls)
            {
                if(ctrl.Name.StartsWith("Error")) { labels.Add(ctrl as Label); }
            }
            foreach(Label l in labels) { l.Visible = false; }
            LlenarComboBox();
            RbActivos.Checked = true;
            Mostrar(Dgv, LinqProductos());
        }

        private void Mostrar(DataGridView dgv, object obj)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
            dgv.Columns[0].Visible = false;
        }

        private object LinqProductos()
        {
            return (from p in BLLProducto.ListarProductos() where p.estado == RbActivos.Checked select new { ID = p.idProducto, Producto = p.nombre, Descripción = p.descripcion, Precio = $"${p.precio}", Stock = p.stock, Categoria = p.categoria.nombre }).ToList();
        }

        private void LlenarComboBox()
        {
            foreach(BECategoria categoria in bllCategoria.ListaCategoria())
            {
                comboBox1.Items.Add(categoria);
            }
            comboBox1.DisplayMember = "nombre";
        }

        private void ErrorIdioma_Click(object sender, EventArgs e)
        {

        }

        private void TxtProducto_KeyUp(object sender, KeyEventArgs e)
        {
            ErrorNombre.Visible = false;
        }

        private void TxtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            ErrorIdioma.Visible = false;
        }

        private void TxtPrecio_KeyUp(object sender, KeyEventArgs e)
        {
            ErrorPrecio.Visible = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorRol.Visible = false;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if(ValidarInputs() == 0)
                {
                    string nombre = TxtProducto.Text;
                    string descripcion = TxtDescripcion.Text;
                    decimal precio = decimal.Parse(TxtPrecio.Text);
                    int stock = int.Parse(numericUpDown1.Value.ToString());
                    BECategoria categoria = comboBox1.SelectedItem as BECategoria;
                    BEProducto producto = new BEProducto(nombre, descripcion, precio, stock, categoria, true);
                    BLLProducto.Agregar(producto);
                    LimpiarControles();
                }


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private int ValidarInputs()
        {
            int cont = 0;
            if (string.IsNullOrWhiteSpace(TxtProducto.Text)) { ErrorNombre.Visible = true; cont++; }
            if (string.IsNullOrWhiteSpace(TxtDescripcion.Text)) { ErrorIdioma.Visible = true; cont++; }
            string sinSimbolo = TxtPrecio.Text.Replace("$", "");
            if (!decimal.TryParse(sinSimbolo, out var precio) || string.IsNullOrWhiteSpace(TxtPrecio.Text)) { ErrorPrecio.Visible = true; cont++; }
            if (comboBox1.SelectedItem == null) { ErrorRol.Visible = true; cont++; }
            return cont;
        }

        private void BtnCambiarEstadoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dgv.SelectedRows.Count != 0)
                {
                    BLLProducto.CambiarEstado(int.Parse(Dgv.SelectedRows[0].Cells[0].Value.ToString()));
                    LimpiarControles();
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void RbActivos_CheckedChanged(object sender, EventArgs e)
        {
            if(RbActivos.Checked) { BtnCambiarEstadoProducto.Text = "Deshabilitar"; }
            else { BtnCambiarEstadoProducto.Text = "Habilitar"; }
            Mostrar(Dgv, LinqProductos());
        }

        private void Dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtProducto.Text = Dgv.SelectedRows[0].Cells["Producto"].Value.ToString();
            TxtDescripcion.Text = Dgv.SelectedRows[0].Cells["Descripción"].Value.ToString();
            TxtPrecio.Text = Dgv.SelectedRows[0].Cells["Precio"].Value.ToString();
            numericUpDown1.Value = Dgv.SelectedRows[0].Cells["Precio"].Value.ToString().Length;
            numericUpDown1.Enabled = false;
            var categoriaNombre = Dgv.SelectedRows[0].Cells["Categoria"].Value.ToString();
            var item = comboBox1.Items.Cast<BECategoria>().FirstOrDefault(x => x.nombre == categoriaNombre);
            comboBox1.SelectedItem = item;
        }

        private void LimpiarControles()
        {
            TxtProducto.Text = "";
            TxtDescripcion.Text = "";
            TxtPrecio.Text = "";
            numericUpDown1.Value = 1;
            numericUpDown1.Enabled = true;
            comboBox1.SelectedItem = null;
            comboBox1.SelectedIndex = -1;
            Mostrar(Dgv, LinqProductos());
        }

        private void BtnEliminarSeleccion_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarInputs() == 0)
                {
                    string nombre = TxtProducto.Text;
                    string descripcion = TxtDescripcion.Text;
                    string sinSimbolo = TxtPrecio.Text.Replace("$", "");
                    decimal precio = decimal.Parse(sinSimbolo);
                    int stock = int.Parse(numericUpDown1.Value.ToString());
                    BECategoria categoria = comboBox1.SelectedItem as BECategoria;
                    BEProducto producto = new BEProducto(nombre, descripcion, precio, stock, categoria, RbActivos.Checked);
                    producto.idProducto = int.Parse(Dgv.SelectedRows[0].Cells[0].Value.ToString());
                    BLLProducto.Modificar(producto);    
                    LimpiarControles();
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
