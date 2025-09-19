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

namespace GUI
{
    public partial class RevisarSolicitudes : Form
    {
        BLLSolicitudReposicion bllSolicitud = new BLLSolicitudReposicion();
        List<BESolicitudReposicion> lista = new List<BESolicitudReposicion>();
        BLLOrdenCompra bllOrdenCompra = new BLLOrdenCompra();
        public RevisarSolicitudes()
        {
            InitializeComponent();
            BtnAceptar.Enabled = false;
            BtnRechazar.Enabled = false;
            BtnCrearOrdenCompra.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null) { Mostrar(Dgv, Linq(comboBox1.SelectedItem.ToString())); }
        }

        private void Mostrar(DataGridView dgv, object obj)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
            dgv.Columns[0].Visible = false;
        }

        private object Linq(string pEstado)
        {
            return (from s in bllSolicitud.SolicitudesEstado(pEstado) select new {Id = s.id, Producto = s.producto.nombre, Fecha = s.fecha, Motivo = s.motivo}).ToList();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                bllSolicitud.Aprobar(int.Parse(Dgv.SelectedRows[0].Cells[0].Value.ToString()));
                Mostrar(Dgv, Linq(comboBox1.SelectedItem.ToString()));
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void Dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(Dgv.SelectedRows.Count > 0 && comboBox1.SelectedItem.ToString() == "En revisión") { BtnAceptar.Enabled = true; BtnRechazar.Enabled = true; }
            else { BtnAceptar.Enabled = false; BtnRechazar.Enabled = false; }
            if(Dgv.SelectedRows.Count > 0 && comboBox1.SelectedItem.ToString() == "Aprobada") { BtnCrearOrdenCompra.Enabled = true;}
            else { BtnCrearOrdenCompra.Enabled=false;}
        }

        private void BtnRechazar_Click(object sender, EventArgs e)
        {
            try
            {
                string motivo = Interaction.InputBox("Ingrese el motivo de rechazo");
                if (string.IsNullOrWhiteSpace(motivo)) throw new Exception("Motivo inválido");
                bllSolicitud.Cancelar(int.Parse(Dgv.SelectedRows[0].Cells[0].Value.ToString()), motivo);
                Mostrar(Dgv, Linq(comboBox1.SelectedItem.ToString()));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void BtnCrearOrdenCompra_Click(object sender, EventArgs e)
        {
            try
            {
                ListarSolicitudes();
                BEOrdenCompra ordenCompra = new BEOrdenCompra("Generada", DateTime.Now);
                bllOrdenCompra.CrearOrden(ordenCompra);
                int idOrdenCompra = bllOrdenCompra.DevolverUltimoId();
                string detalleOrden = "";
                foreach(BESolicitudReposicion solicitud in lista)
                {
                    bllSolicitud.AsignarOrdenCompra(solicitud.id, idOrdenCompra);
                    detalleOrden += $"{solicitud.producto.nombre}" + Environment.NewLine;
                }
                MessageBox.Show("Sé generó la orden de compra para los siguientes productos: " + Environment.NewLine + detalleOrden);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void ListarSolicitudes()
        {
            lista.Clear();
            foreach(DataGridViewRow row in Dgv.SelectedRows)
            {
                BESolicitudReposicion solicitud = bllSolicitud.Solicitudes().Find(x => x.id == int.Parse(row.Cells[0].Value.ToString()));
                lista.Add(solicitud);
            }
        }
    }
}
