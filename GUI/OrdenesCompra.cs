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
using Servicios;
using Servicios.Logica;

namespace GUI
{
    public partial class OrdenesCompra : Form
    {
        BLLSolicitudReposicion bllSolicitud = new BLLSolicitudReposicion();
        BLLOrdenCompra bllOrden = new BLLOrdenCompra();
        LogicaBitacora bitacora = new LogicaBitacora();
        public OrdenesCompra()
        {
            InitializeComponent();
            BtnFinalizar.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "Finalizada")
            {
                Mostrar(DgvOrdenes, LinqOrdenes("Finalizada"));
                DgvDetalle.DataSource = null;
            }
            else
            {
                Mostrar(DgvOrdenes, LinqOrdenes("Generada"));
            }
        }

        private void Mostrar(DataGridView dgv, object obj)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
        }

        private object LinqOrdenes(string filtro)
        {
            return (from o in new BLL.BLLOrdenCompra().Ordenes() where o.estado == filtro select new { Id = o.id, Estado = o.estado, Fecha = o.fecha }).ToList();
        }

        private void DgvOrdenes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(DgvOrdenes.SelectedRows.Count > 0)
            {
                Mostrar(DgvDetalle, LinqDetalle(int.Parse(DgvOrdenes.SelectedRows[0].Cells[0].Value.ToString())));
            }
            if (comboBox1.SelectedItem.ToString() == "Finalizada" && DgvOrdenes.SelectedRows.Count != 0)
            {
                BtnFinalizar.Enabled = false;
            }
            else
            {
                BtnFinalizar.Enabled = true;
            }
        }

        private object LinqDetalle(int pIdOrden)
        {
            return (from s in bllSolicitud.Solicitudes() where s.ordenCompra != null && s.ordenCompra.id == pIdOrden select new { Id = s.id, Producto = s.producto.nombre, Estado = s.estado }).ToList();
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                bllOrden.Finalizar(int.Parse(DgvOrdenes.SelectedRows[0].Cells[0].Value.ToString()));
                MessageBox.Show($"Orden {DgvOrdenes.SelectedRows[0].Cells[0].Value.ToString()} finalizada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Mostrar(DgvOrdenes, LinqOrdenes(comboBox1.SelectedItem.ToString()));
                DgvDetalle.DataSource = null;
                bitacora.RegistrarBitacora(bitacora.CrearBitacora(Sesion.INSTANCIA.ObtenerUsuarioActual(), $"Finalizó la orden de compra {DgvOrdenes.SelectedRows[0].Cells[0].Value.ToString()}", 1));
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
    }
}
