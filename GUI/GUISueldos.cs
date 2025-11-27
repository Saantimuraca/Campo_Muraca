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
using Servicios.Entidades;
using Servicios.Logica;

namespace GUI
{
    public partial class GUISueldos : Form
    {
        GestorPermisos GP = new GestorPermisos();
        BLLSueldo bllSueldo = new BLLSueldo();
        BLLPago bllPago = new BLLPago();
        public GUISueldos()
        {
            InitializeComponent();
            ErrorRol.Visible = false;
            ErrorNombre.Visible = false;
            foreach(EntidadPermiso p in GP.ObtenerPermisos("Roles"))
            {
                if(p.DevolverNombrePermiso() != "Administrador")
                {
                    comboBox1.Items.Add(p.DevolverNombrePermiso());
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null)
            {
                ErrorRol.Visible = false;
                if(comboBox1.SelectedItem.ToString() != "Vendedor") { numericUpDown1.Enabled = false; numericUpDown1.Value = 0; }
                else { numericUpDown1.Enabled = true; }
                ActualizarSueldos();
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem == null) { ErrorRol.Visible = true; return; }
                if (string.IsNullOrWhiteSpace(TxtSueldo.Text))
                {
                    return;
                }
                if (!decimal.TryParse(TxtSueldo.Text, out decimal importe) || importe < 0)
                {
                    return;
                }
                else
                {
                    ErrorNombre.Visible = false;
                }
                BESueldo sueldo = new BESueldo(comboBox1.SelectedItem.ToString(), Convert.ToDecimal(TxtSueldo.Text), Convert.ToInt32(numericUpDown1.Value), DateTime.Now);
                bllSueldo.Modificar(sueldo);
                MessageBox.Show("Sueldo modificado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void ActualizarSueldos()
        {
            var sueldoSeleccionado = bllSueldo.ObtenerPorRol(comboBox1.SelectedItem.ToString());
            if (sueldoSeleccionado == null)
            {
                TxtSueldo.Text = "";
                numericUpDown1.Value = 0;
                return;
            }
            TxtSueldo.Text = sueldoSeleccionado.sueldo.ToString();
            if (comboBox1.SelectedItem.ToString() == "Vendedor")
            {
                numericUpDown1.Value = sueldoSeleccionado.comision;
            }
            else
            {
                numericUpDown1.Value = 0;
            }
        }

        private void BtnSolicitarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem == null) { ErrorRol.Visible = true; return; }
                if (string.IsNullOrEmpty(TxtSueldo.Text)) { ErrorNombre.Visible = true; return; }
                if(bllPago.ExistePago(DateTime.Now.Month))
                {
                    DialogResult result = MessageBox.Show("Ya se ha solicitado el pago de este mes. ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No) { return; }
                }
                decimal total = bllPago.CalcularTotal();
                BEPago pago = new BEPago("En Revisión",DateTime.Now, total);
                bllPago.SolicitarPago(pago);
                MessageBox.Show("Pago solicitado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
