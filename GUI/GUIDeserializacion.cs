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
using BE;

namespace GUI
{
    public partial class GUIDeserializacion : Form
    {
        BLLCliente BLLCliente = new BLLCliente();
        List<BE.BECliente> listaClientes;
        public GUIDeserializacion(List<BE.BECliente> pLista)
        {
            InitializeComponent();
            listaClientes = pLista;
            Mostrar(Dgv, Linq());
            BtnAgregar.Enabled = false;
            BtnModificar.Enabled = false;
        }

        private void Mostrar(DataGridView dgv, object obj)
        {
            dgv.DataSource = null;
            dgv.DataSource = obj;
        }

        private object Linq()
        {
            return (from c in listaClientes select new { DNI = c.dni, Correo = c.mail, Nombre = c.nombre, IVA = c.condicionIVA, Teléfono = c.telefono, Estado = c.isActivo }).ToList();
        }

        private void Dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = Dgv.SelectedRows[0];
                if (fila.Cells[0].Value != null && !string.IsNullOrWhiteSpace(fila.Cells[0].Value.ToString()) &&
                    fila.Cells[1].Value != null && !string.IsNullOrWhiteSpace(fila.Cells[1].Value.ToString()) &&
                    fila.Cells[2].Value != null && !string.IsNullOrWhiteSpace(fila.Cells[2].Value.ToString()) &&
                    fila.Cells[3].Value != null && !string.IsNullOrWhiteSpace(fila.Cells[3].Value.ToString()) &&
                    fila.Cells[4].Value != null && !string.IsNullOrWhiteSpace(fila.Cells[4].Value.ToString()) &&
                    fila.Cells[5].Value != null)
                {
                    bool estado = Convert.ToBoolean(fila.Cells[5].Value);

                    if (BLLCliente.ExisteCliente(fila.Cells[0].Value.ToString()))
                    {
                        BtnAgregar.Enabled = false;
                        BtnModificar.Enabled = true;
                    }
                    else
                    {
                        BtnAgregar.Enabled = true;
                        BtnModificar.Enabled = false;
                    }
                }
                else
                {
                    BtnAgregar.Enabled = false;
                    BtnModificar.Enabled = false;
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = Dgv.SelectedRows[0].Cells[0].Value.ToString();
                string correo = Dgv.SelectedRows[0].Cells[1].Value.ToString();
                string nombre = Dgv.SelectedRows[0].Cells[2].Value.ToString();
                string iva = Dgv.SelectedRows[0].Cells[3].Value.ToString();
                string telefono = Dgv.SelectedRows[0].Cells[4].Value.ToString();
                bool estado = Convert.ToBoolean(Dgv.SelectedRows[0].Cells[5].Value);
                BECliente cliente = new BECliente(dni, correo, nombre, iva, estado, telefono);
                BLLCliente.Agregar(cliente);
                MessageBox.Show("Cliente agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnAgregar.Enabled = false;
                BtnModificar.Enabled = true;
                bool estaAbierto = Application.OpenForms["GUIRegistrarCliente"] != null;
                if (estaAbierto)
                {
                    GUIRegistrarCliente m = Application.OpenForms["GUIRegistrarCliente"] as GUIRegistrarCliente;
                    m.Actualizar();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = Dgv.SelectedRows[0].Cells[0].Value.ToString();
                string correo = Dgv.SelectedRows[0].Cells[1].Value.ToString();
                string nombre = Dgv.SelectedRows[0].Cells[2].Value.ToString();
                string iva = Dgv.SelectedRows[0].Cells[3].Value.ToString();
                string telefono = Dgv.SelectedRows[0].Cells[4].Value.ToString();
                bool estado = Convert.ToBoolean(Dgv.SelectedRows[0].Cells[5].Value);
                BECliente cliente = new BECliente(dni, correo, nombre, iva, estado, telefono);
                BLLCliente.Modificar(cliente);
                MessageBox.Show("Cliente modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnAgregar.Enabled = false;
                BtnModificar.Enabled = true;
                bool estaAbierto = Application.OpenForms["GUIRegistrarCliente"] != null;
                if (estaAbierto)
                {
                    GUIRegistrarCliente m = Application.OpenForms["GUIRegistrarCliente"] as GUIRegistrarCliente;
                    m.Actualizar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
