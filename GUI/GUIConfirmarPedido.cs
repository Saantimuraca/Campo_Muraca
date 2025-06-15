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
using Microsoft.VisualBasic;
using Servicios.Logica;

namespace GUI
{
    public partial class GUIConfirmarPedido : Form
    {
        BLLPedido bllPedido = new BLLPedido();
        LogicaUsuario logicaUsuario = new LogicaUsuario();
        public GUIConfirmarPedido()
        {
            InitializeComponent();
            BtnConfirmarPedido.Visible = false;
            BtnRechazar.Visible = false;
        }

        private void GUIConfirmarPedido_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedItem.ToString())
            {
                case "Aprobado": Mostrar(DgvPedidos, LinqAprobados()); BtnRechazar.Visible = false; BtnConfirmarPedido.Visible = false; break;
                case "En evaluación": Mostrar(DgvPedidos, LinqEnEvaluacion()); BtnRechazar.Visible = true; BtnConfirmarPedido.Visible = true; break;
                case "Rechazado": Mostrar(DgvPedidos, LinqRechazados()); BtnRechazar.Visible = false; BtnConfirmarPedido.Visible = false; break;
                case "Cobrado": Mostrar(DgvPedidos, LinqCobrados()); BtnRechazar.Visible = false; BtnConfirmarPedido.Visible = false; break;
                case "Facturado": Mostrar(DgvPedidos, LinqFacturados()); BtnRechazar.Visible = false; BtnConfirmarPedido.Visible = false; break;
                case "Todos": Mostrar(DgvPedidos, LinqTodos()); BtnRechazar.Visible = false; BtnConfirmarPedido.Visible = false; PintarFilas(); break;
                default: break;
            }
        }

        private void Mostrar(DataGridView dgv, object obj)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
        }

        private object LinqAprobados()
        {
            return (from p in bllPedido.ListarPedidos() where p.estado == "Aprobado" select new {ID = p.id, Cliente = $"{p.cliente.dni}, {p.cliente.nombre}", FECHA = p.fecha, TOTAL = $"${p.total}", VENDEDOR = logicaUsuario.ListaUsuarios().Find(x => x.Dni_Usuario == p.dniVendedor).Nombre_Usuario}) .ToList();
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
            return (from p in bllPedido.ListarPedidos() select new { ID = p.id, Cliente = $"{p.cliente.dni}, {p.cliente.nombre}", FECHA = p.fecha, TOTAL = $"${p.total}", VENDEDOR = logicaUsuario.ListaUsuarios().Find(x => x.Dni_Usuario == p.dniVendedor).Nombre_Usuario, MOTIVO = p.Motivo == "" ? "Sin motivo": p.Motivo, ESTADO = p.estado }).ToList();
        }

        private void PintarFilas()
        {
            foreach (DataGridViewRow row in DgvPedidos.Rows)
            {
                switch(row.Cells[6].Value.ToString())
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

        private void GUIConfirmarPedido_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["Menu"].Show();
        }

        private void BtnConfirmarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvPedidos.SelectedRows.Count == 0) throw new Exception("Debe seleccionar un pedido");
                bllPedido.CambiarEstado("Aprobado", int.Parse(DgvPedidos.SelectedRows[0].Cells[0].Value.ToString()));
                Mostrar(DgvPedidos, LinqEnEvaluacion());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void BtnRechazar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvPedidos.SelectedRows.Count == 0) throw new Exception("Debe seleccionar un pedido");
                string motivo = Interaction.InputBox("Ingrese el motivo", "Motivo");
                if (string.IsNullOrWhiteSpace(motivo)) throw new Exception("Debe indicar el motivo de rechazo del pedido");
                bllPedido.CambiarEstado("Rechazado", int.Parse(DgvPedidos.SelectedRows[0].Cells[0].Value.ToString()), motivo);
                Mostrar(DgvPedidos, LinqEnEvaluacion());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
    }
}
