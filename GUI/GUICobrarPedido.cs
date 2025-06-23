using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
    public partial class GUICobrarPedido : Form, IObserver
    {
        BLLPedido bllPedido = new BLLPedido();
        LogicaUsuario logicaUsuario = new LogicaUsuario();
        GeneradorFactura gf = new GeneradorFactura();
        public GUICobrarPedido()
        {
            InitializeComponent();
            BtnCobrarPedido.Enabled = false;
            BtnRealizarFactura.Enabled = false;
            BtnVerFactura.Enabled = false;
            Traductor.INSTANCIA.Suscribir(this);
            Traductor.INSTANCIA.Notificar();
        }

        private void GUICobrarPedido_Load(object sender, EventArgs e)
        {

        }

        private void Mostrar(DataGridView dgv, object obj)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
            dgv.Columns["ID"].HeaderText = Traductor.INSTANCIA.Traducir("CODIGO", "");
            dgv.Columns["Cliente"].HeaderText = Traductor.INSTANCIA.Traducir("CLIENTE", "");
            dgv.Columns["FECHA"].HeaderText = Traductor.INSTANCIA.Traducir("FECHA", "");
            dgv.Columns["TOTAL"].HeaderText = Traductor.INSTANCIA.Traducir("TOTAL", "");
            dgv.Columns["VENDEDOR"].HeaderText = Traductor.INSTANCIA.Traducir("VENDEDOR", "");
            if (comboBox2.SelectedItem.ToString() == "Rechazado" || comboBox2.SelectedItem.ToString() == "Todos")
            {
                dgv.Columns["MOTIVO"].HeaderText = Traductor.INSTANCIA.Traducir("MOTIVO", "");
                if (comboBox2.SelectedItem.ToString() == "Todos") { dgv.Columns["ESTADO"].HeaderText = Traductor.INSTANCIA.Traducir("ESTADO", ""); }
            }
        }

        private object LinqAprobados()
        {
            return (from p in bllPedido.ListarPedidos() where p.estado == "Aprobado" select new { ID = p.id, Cliente = $"{p.cliente.dni}, {p.cliente.nombre}", FECHA = p.fecha, TOTAL = $"${p.total}", VENDEDOR = logicaUsuario.ListaUsuarios().Find(x => x.Dni_Usuario == p.dniVendedor).Nombre_Usuario }).ToList();
        }

        private object LinqEnEvaluacion()
        {
            return (from p in bllPedido.ListarPedidos() where p.estado == "En evaluación" select new { ID = p.id, Cliente = $"{p.cliente.dni}, {p.cliente.nombre}", FECHA = p.fecha, TOTAL = $"${p.total}", VENDEDOR = logicaUsuario.ListaUsuarios().Find(x => x.Dni_Usuario == p.dniVendedor).Nombre_Usuario }).ToList();
        }

        private object LinqRechazados()
        {
            return (from p in bllPedido.ListarPedidos() where p.estado == "Rechazado" select new { ID = p.id, Cliente = $"{p.cliente.dni}, {p.cliente.nombre}", FECHA = p.fecha, TOTAL = $"${p.total}", VENDEDOR = logicaUsuario.ListaUsuarios().Find(x => x.Dni_Usuario == p.dniVendedor).Nombre_Usuario, MOTIVO = p.Motivo }).ToList();
        }

        private object LinqCobrados()
        {
            return (from p in bllPedido.ListarPedidos() where p.estado == "Cobrado" select new { ID = p.id, Cliente = $"{p.cliente.dni}, {p.cliente.nombre}", FECHA = p.fecha, TOTAL = $"${p.total}", VENDEDOR = logicaUsuario.ListaUsuarios().Find(x => x.Dni_Usuario == p.dniVendedor).Nombre_Usuario }).ToList();
        }

        private object LinqFacturados()
        {
            return (from p in bllPedido.ListarPedidos() where p.estado == "Facturado" select new { ID = p.id, Cliente = $"{p.cliente.dni}, {p.cliente.nombre}", FECHA = p.fecha, TOTAL = $"${p.total}", VENDEDOR = logicaUsuario.ListaUsuarios().Find(x => x.Dni_Usuario == p.dniVendedor).Nombre_Usuario }).ToList();
        }

        private object LinqTodos()
        {
            return (from p in bllPedido.ListarPedidos() select new { ID = p.id, Cliente = $"{p.cliente.dni}, {p.cliente.nombre}", FECHA = p.fecha, TOTAL = $"${p.total}", VENDEDOR = logicaUsuario.ListaUsuarios().Find(x => x.Dni_Usuario == p.dniVendedor).Nombre_Usuario, MOTIVO = p.Motivo == "" ? "Sin motivo" : p.Motivo, ESTADO = p.estado }).ToList();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedItem.ToString())
            {
                case "Aprobado": Mostrar(DgvPedidos, LinqAprobados()); BtnVerFactura.Enabled = false; BtnCobrarPedido.Enabled = false; break;
                case "En evaluación": Mostrar(DgvPedidos, LinqEnEvaluacion()); BtnRealizarFactura.Enabled = false; BtnVerFactura.Enabled = false; BtnCobrarPedido.Enabled = false; break;
                case "Rechazado": Mostrar(DgvPedidos, LinqRechazados()); BtnRealizarFactura.Enabled = false; BtnVerFactura.Enabled = false; BtnCobrarPedido.Enabled = false; break;
                case "Cobrado": Mostrar(DgvPedidos, LinqCobrados()); BtnRealizarFactura.Enabled = false; BtnVerFactura.Enabled = false; BtnCobrarPedido.Enabled = false; break;
                case "Facturado": Mostrar(DgvPedidos, LinqFacturados()); BtnRealizarFactura.Enabled = false; break;
                case "Todos": Mostrar(DgvPedidos, LinqTodos()); PintarFilas(); BtnRealizarFactura.Enabled = false; BtnVerFactura.Enabled = false; BtnCobrarPedido.Enabled = false; break;
                default: break;
            }
        }

        private void PintarFilas()
        {
            foreach (DataGridViewRow row in DgvPedidos.Rows)
            {
                switch (row.Cells[6].Value.ToString())
                {
                    case "Aprobado": row.DefaultCellStyle.BackColor = Color.LightGreen; break;
                    case "En evaluación": row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow; break;
                    case "Rechazado": row.DefaultCellStyle.BackColor = Color.LightCoral; break;
                    case "Cobrado": row.DefaultCellStyle.BackColor = Color.LightBlue; break;
                    case "Facturado": row.DefaultCellStyle.BackColor = Color.Lavender; break;
                    default: break;
                }
            }
        }

        private void BtnRealizarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvPedidos.SelectedRows.Count == 0) throw new Exception(Traductor.INSTANCIA.Traducir("Debe seleccionar un pedido", ""));
                if (comboBox1.SelectedItem == null) throw new Exception(Traductor.INSTANCIA.Traducir("Debe seleccionar un método de pago", ""));
                BEPedido pedido = bllPedido.ListarPedidos().Find(x => x.id == int.Parse(DgvPedidos.SelectedRows[0].Cells[0].Value.ToString()));
                gf.GenerarFactura(pedido, comboBox1.SelectedItem.ToString());
                Mostrar(DgvPedidos, LinqAprobados());
                BtnRealizarFactura.Enabled = false;
                string[] vectorMail = pedido.cliente.mail.Split('@');
                if (vectorMail[1] == "gmail.com") { MessageBox.Show(Traductor.INSTANCIA.Traducir("La factura fue enviada al cliente", "")); }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, Traductor.INSTANCIA.Traducir("Advertencia", ""), MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void GUICobrarPedido_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["Menu"].Show();
        }

        private void DgvPedidos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(comboBox2.SelectedItem.ToString() == "Aprobado" && comboBox1.SelectedItem != null) { BtnRealizarFactura.Enabled = true; }
            if(comboBox2.SelectedItem.ToString() == "Facturado" || comboBox2.SelectedItem.ToString() == "Cobrado") { BtnVerFactura.Enabled = true; }
            if(comboBox2.SelectedItem.ToString() == "Facturado" && comboBox1.SelectedItem != null) { BtnCobrarPedido.Enabled = true; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DgvPedidos.SelectedRows.Count != 0 && comboBox2.SelectedItem.ToString() == "Aprobado") { BtnRealizarFactura.Enabled = true; }
            if(DgvPedidos.SelectedRows.Count != 0 && comboBox2.SelectedItem.ToString() == "Facturado") { BtnCobrarPedido.Enabled = true; }
        }

        private void BtnVerFactura_Click(object sender, EventArgs e)
        {
            try
            {
                BEPedido pedido = bllPedido.ListarPedidos().Find(x => x.id == int.Parse(DgvPedidos.SelectedRows[0].Cells[0].Value.ToString()));
                string carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Facturas");
                if (!Directory.Exists(carpeta)) { Directory.CreateDirectory(carpeta); }
                string nombreArchivo = $"Factura_{pedido.cliente.dni}_Pedido{pedido.id}.pdf";
                string rutaCompleta = Path.Combine(carpeta, nombreArchivo);
                gf.VerFactura(rutaCompleta);
            }
            catch { MessageBox.Show("No se pudo encontrar la factura", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void BtnCobrarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                bllPedido.CambiarEstado("Cobrado", int.Parse(DgvPedidos.SelectedRows[0].Cells[0].Value.ToString()));
                Mostrar(DgvPedidos, LinqFacturados());
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);}
        }

        public void ActualizarLenguaje()
        {
            Traductor traductor = Traductor.INSTANCIA;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button || ctrl is Label)
                {
                    ctrl.Text = traductor.Traducir(ctrl.Name, Sesion.INSTANCIA.ObtenerIdiomaSesion());
                }
            }
        }
    }
}
