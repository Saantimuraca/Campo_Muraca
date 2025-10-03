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
using Microsoft.VisualBasic;
using Servicios;
using Servicios.Logica;

namespace GUI
{
    public partial class ABMProducto : Form, Servicios.IObserver
    {
        List<Label> labels = new List<Label>();
        BLLCategoria bllCategoria = new BLLCategoria();
        BLLProducto BLLProducto = new BLLProducto();
        BLLSolicitudReposicion BLLSolicitud = new BLLSolicitudReposicion();
        List<string> lista = new List<string>();
        LogicaBitacora bitacora = new LogicaBitacora();
        public ABMProducto()
        {
            InitializeComponent();
            Traductor.INSTANCIA.Suscribir(this);
            Traductor.INSTANCIA.Notificar();
            labels.Clear();
            foreach(Control ctrl in this.Controls)
            {
                if(ctrl.Name.StartsWith("Error")) { labels.Add(ctrl as Label); }
            }
            foreach(Label l in labels) { l.Visible = false; }
            LlenarComboBox();
            RbActivos.Checked = true;
            Mostrar(Dgv, LinqProductos());
            BtnActualizarStock.Enabled = false;
            BtnSolicitarReposición.Enabled = false;
            lista.Clear();
        }

        private void Mostrar(DataGridView dgv, object obj)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
            dgv.Columns[0].Visible = false;
            dgv.Columns["BajoStock"].Visible = false;
            dgv.Columns["Producto"].HeaderText = Traductor.INSTANCIA.Traducir("LblNombreProducto", "");
            dgv.Columns["Descripción"].HeaderText = Traductor.INSTANCIA.Traducir("LblDescripcion", "");
            dgv.Columns["Precio"].HeaderText = Traductor.INSTANCIA.Traducir("LblPrecio", "");
            dgv.Columns["Stock"].HeaderText = Traductor.INSTANCIA.Traducir("LblStock", "");
            dgv.Columns["Categoria"].HeaderText = Traductor.INSTANCIA.Traducir("LblCategoria", "");
        }

        private object LinqProductos()
        {
            return (from p in BLLProducto.ListarProductos() where p.estado == RbActivos.Checked select new { ID = p.idProducto, Producto = p.nombre, Descripción = p.descripcion, Precio = $"${p.precio}", Stock = p.stock, Categoria = p.categoria.nombre, BajoStock = p.isBajoStock }).ToList();
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
                    bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.INSTANCIA.ObtenerUsuarioActual(), $"Agregó el producto {nombre}", 1));
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
                    bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.INSTANCIA.ObtenerUsuarioActual(), $"{(RbActivos.Checked ? "Deshabilitó" : "Habilitó")} el producto {Dgv.SelectedRows[0].Cells["Producto"].Value.ToString()}", 2));
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void RbActivos_CheckedChanged(object sender, EventArgs e)
        {
            if(RbActivos.Checked) { BtnCambiarEstadoProducto.Text = Traductor.INSTANCIA.Traducir("Deshabilitar", ""); }
            else { BtnCambiarEstadoProducto.Text = Traductor.INSTANCIA.Traducir("Habilitar", ""); }
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
            if (EvaluarOdenCompra(int.Parse(Dgv.SelectedRows[0].Cells[0].Value.ToString()))) { BtnActualizarStock.Enabled = true; }
            else { BtnActualizarStock.Enabled= false; }
            if (Dgv.SelectedRows.Count > 0) { BtnSolicitarReposición.Enabled = true; }
            else { BtnSolicitarReposición.Enabled = false; }
        }

        private bool EvaluarOdenCompra(int pIdProducto)
        {
            return BLLProducto.ListaProductosAprobados().Find(x => x.idProducto == pIdProducto) == null ? false : true;
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
                if (ValidarInputs() == 0 && Dgv.SelectedRows.Count != 0)
                {
                    string nombre = TxtProducto.Text;
                    string descripcion = TxtDescripcion.Text;
                    string sinSimbolo = TxtPrecio.Text.Replace("$", "");
                    decimal precio = decimal.Parse(sinSimbolo);
                    int stock = int.Parse(numericUpDown1.Value.ToString());
                    BECategoria categoria = comboBox1.SelectedItem as BECategoria;
                    BEProducto producto = new BEProducto(nombre, descripcion, precio, stock, categoria, RbActivos.Checked);
                    producto.idProducto = int.Parse(Dgv.SelectedRows[0].Cells[0].Value.ToString());
                    string historiaNombre = Dgv.SelectedRows[0].Cells["Producto"].Value.ToString();
                    string historiaDescripcion = Dgv.SelectedRows[0].Cells["Descripción"].Value.ToString();
                    string sinSimbolo2 = Dgv.SelectedRows[0].Cells["Precio"].Value.ToString().Replace("$", "");
                    decimal historiaPrecio = decimal.Parse(sinSimbolo2);
                    BLLProducto.Modificar(producto);    
                    BECategoria historiaCategoria = bllCategoria.ListaCategoria().Find(x => x.nombre == Dgv.SelectedRows[0].Cells["Categoria"].Value.ToString());
                    BEProducto historiaProducto = new BEProducto(historiaNombre, historiaDescripcion, historiaPrecio, stock, historiaCategoria, RbActivos.Checked, producto.idProducto);
                    BLLProducto.AgregarHistoria(historiaProducto);
                    LimpiarControles();
                    bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.INSTANCIA.ObtenerUsuarioActual(), $"Modificó el producto {historiaNombre}", 2));
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnActualizarStock_Click(object sender, EventArgs e)
        {
            try
            {
                if(Dgv.SelectedRows.Count != 0)
                {
                    string aux = Interaction.InputBox(Traductor.INSTANCIA.Traducir("Ingrese la nueva cantidad", ""));
                    if (!int.TryParse(aux, out int stock)) throw new Exception(Traductor.INSTANCIA.Traducir("Número inválido", ""));
                    if (stock == int.Parse(Dgv.SelectedRows[0].Cells["Stock"].Value.ToString())) throw new Exception("No puede ingresar la misma cantidad de stock que el producto tiene actualmente");
                    int id = int.Parse(Dgv.SelectedRows[0].Cells[0].Value.ToString());
                    string historiaNombre = Dgv.SelectedRows[0].Cells["Producto"].Value.ToString();
                    string historiaDescripcion = Dgv.SelectedRows[0].Cells["Descripción"].Value.ToString();
                    string sinSimbolo2 = Dgv.SelectedRows[0].Cells["Precio"].Value.ToString().Replace("$", "");
                    decimal historiaPrecio = decimal.Parse(sinSimbolo2);
                    BLLProducto.ModificarStock(id, stock);
                    BLLProducto.CambiarEstadoStock(id, false);
                    BECategoria historiaCategoria = bllCategoria.ListaCategoria().Find(x => x.nombre == Dgv.SelectedRows[0].Cells["Categoria"].Value.ToString());
                    BEProducto historiaProducto = new BEProducto(historiaNombre, historiaDescripcion, historiaPrecio, stock, historiaCategoria, RbActivos.Checked, id);
                    BLLProducto.AgregarHistoria(historiaProducto);
                    LimpiarControles();
                    lista.Add(historiaNombre);
                    TxtStockActualizado.Text = "";
                    foreach(string producto in  lista)
                    {
                        TxtStockActualizado.Text += producto + Environment.NewLine;
                    }
                    bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.INSTANCIA.ObtenerUsuarioActual(), $"Actualizó stock de {historiaNombre}", 3));
                }
       
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked) { Mostrar(Dgv, LinqProductosAprobados()); }
            else { Mostrar(Dgv, LinqProductos()); }
        }

        private object LinqProductosAprobados()
        {
            return (from p in BLLProducto.ListaProductosAprobados() where p.estado == RbActivos.Checked select new { ID = p.idProducto, Producto = p.nombre, Descripción = p.descripcion, Precio = $"${p.precio}", Stock = p.stock, Categoria = p.categoria.nombre, BajoStock = p.isBajoStock }).ToList();
        }

        public void ActualizarLenguaje()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label || ctrl is Button || ctrl is CheckBox)
                {
                    ctrl.Text = Traductor.INSTANCIA.Traducir(ctrl.Name, Sesion.INSTANCIA.ObtenerIdiomaSesion());
                }
            }
        }

        private void Dgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            HistoriaProductos gui = new HistoriaProductos(int.Parse(Dgv.SelectedRows[0].Cells[0].Value.ToString()));
            gui.Show();
            if (RbActivos.Checked) { BtnCambiarEstadoProducto.Text = Traductor.INSTANCIA.Traducir("Deshabilitar", ""); }
            else { BtnCambiarEstadoProducto.Text = Traductor.INSTANCIA.Traducir("Habilitar", ""); }
        }

        public void Actualizar()
        {
            Mostrar(Dgv, LinqProductos());
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnSolicitarReposición_Click(object sender, EventArgs e)
        {
            try
            {
                BEProducto producto = BLLProducto.ListarProductos().Find(x => x.idProducto == int.Parse(Dgv.SelectedRows[0].Cells[0].Value.ToString()));
                if (BLLSolicitud.ExisteSolicitud(producto.idProducto)) throw new Exception("Ya existe una solicitud pendiente o en revisión de este producto");
                string motivo = Interaction.InputBox("Motivo");
                if (string.IsNullOrWhiteSpace(motivo)) throw new Exception("Motivo inválido");
                BESolicitudReposicion solicitudReposicion = new BESolicitudReposicion(producto, DateTime.Now, motivo, "En revisión");
                BLLSolicitud.Agregar(solicitudReposicion);
                MessageBox.Show("Solicitud de reposición solicitada con éxito");
                bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.INSTANCIA.ObtenerUsuarioActual(), $"Solicitó reposición del producto {producto.nombre}", 3));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void Dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in Dgv.Rows)
                {
                    if (bool.Parse(row.Cells[6].Value.ToString()))
                    {
                        row.DefaultCellStyle.BackColor = Color.Gray;
                    }
                }
                Dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }
            catch { }
        }

        private void RbInactivos_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
