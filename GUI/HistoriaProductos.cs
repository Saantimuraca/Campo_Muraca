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
    public partial class HistoriaProductos : Form, IObserver
    {
        BLLProducto bllProducto = new BLLProducto();
        int idProductoSeleccionado;
        BLLCategoria bllCategoria = new BLLCategoria();
        LogicaBitacora bitacora = new LogicaBitacora();
        public HistoriaProductos(int pIdProductoSeleccionado)
        {
            InitializeComponent();
            Traductor.INSTANCIA.Suscribir(this);
            Traductor.INSTANCIA.Notificar();
            idProductoSeleccionado = pIdProductoSeleccionado;
            Dgv.DataSource = null;
            Dgv.DataSource = Linq();
            Dgv.Columns[0].Visible = false;
            Dgv.Columns[1].Visible = false;
            Dgv.Columns["Producto"].HeaderText = Traductor.INSTANCIA.Traducir("LblNombreProducto", "");
            Dgv.Columns["Descripción"].HeaderText = Traductor.INSTANCIA.Traducir("LblDescripcion", "");
            Dgv.Columns["Precio"].HeaderText = Traductor.INSTANCIA.Traducir("LblPrecio", "");
            Dgv.Columns["Stock"].HeaderText = Traductor.INSTANCIA.Traducir("LblStock", "");
            Dgv.Columns["Categoria"].HeaderText = Traductor.INSTANCIA.Traducir("LblCategoria", "");
            Dgv.Columns["Estado"].HeaderText = Traductor.INSTANCIA.Traducir("Estado", "");
            Dgv.Columns["StockBajo"].HeaderText = Traductor.INSTANCIA.Traducir("¿Stock bajo?", "");
            Dgv.Columns["ReposicionAprobada"].HeaderText = Traductor.INSTANCIA.Traducir("¿Reposicion aprobada?", "");
            Dgv.Columns["FechaModificacion"].HeaderText = Traductor.INSTANCIA.Traducir("FECHA DE MODIFICACIÓN", Sesion.INSTANCIA.ObtenerIdiomaSesion());
        }

        private object Linq()
        {
            return (from h in bllProducto.ListaHistorias() where h.idProducto == idProductoSeleccionado select new {Id = h.id, Id_Producto = h.idProducto, Producto = h.nombre, Descripción = h.descripcion, Precio = $"${h.precio}", Stock = h.stock, Categoria = h.categoria.nombre,
            Estado = h.estado, StockBajo = h.isBajoStock, ReposicionAprobada = h.reposicionAprobada, FechaModificacion = h.fechaModificacion}).ToList();
        }

        private void BtnRollBack_Click(object sender, EventArgs e)
        {
            if(Dgv.SelectedRows.Count > 0)
            {
                int id = int.Parse(Dgv.SelectedRows[0].Cells["Id_Producto"].Value.ToString());
                string nombre = Dgv.SelectedRows[0].Cells["Producto"].Value.ToString();
                string descripcion = Dgv.SelectedRows[0].Cells["Descripción"].Value.ToString();
                string sinSimbolo = Dgv.SelectedRows[0].Cells["Precio"].Value.ToString().Replace("$", "");
                decimal precio = decimal.Parse(sinSimbolo);
                int stock = int.Parse(Dgv.SelectedRows[0].Cells["Stock"].Value.ToString());
                BECategoria categoria = bllCategoria.ListaCategoria().Find(x => x.nombre == Dgv.SelectedRows[0].Cells["Categoria"].Value.ToString());
                bool estado = bool.Parse(Dgv.SelectedRows[0].Cells["Estado"].Value.ToString());
                bool stockBajo = bool.Parse(Dgv.SelectedRows[0].Cells["StockBajo"].Value.ToString());
                bool reposicionAprobada = bool.Parse(Dgv.SelectedRows[0].Cells["ReposicionAprobada"].Value.ToString());
                DateTime fechaModificacion = DateTime.Parse(Dgv.SelectedRows[0].Cells["FechaModificacion"].Value.ToString());
                BEProducto producto = new BEProducto(nombre, descripcion, precio, stock, categoria, estado, reposicionAprobada, id, stockBajo);
                if(bllProducto.RollBack(producto))
                {
                    MessageBox.Show(Traductor.INSTANCIA.Traducir("RollBack exitoso", ""));
                    ABMProducto form = Application.OpenForms["ABMProducto"] as ABMProducto;
                    if (form != null) { form.Actualizar(); }
                    bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.INSTANCIA.ObtenerUsuarioActual(), $"RollBack del producto {id} {nombre}", 4));
                }
                else
                {
                    MessageBox.Show(Traductor.INSTANCIA.Traducir("Ocurrió un error", ""));
                    bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.INSTANCIA.ObtenerUsuarioActual(), $"No pudo realizar el RollBack del producto {id} {nombre}", 4));
                }
            }
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
