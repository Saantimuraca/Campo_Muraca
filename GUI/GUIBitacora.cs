using Servicios;
using Servicios.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class GUIBitacroa_ : Form
    {
        Traductor traductor = Traductor.INSTANCIA;
        public GUIBitacroa_()
        {
            InitializeComponent();
            Dgv.DataSource = null;
            Dgv.DataSource = LinqBitacora();
            Dgv.Columns[0].HeaderText = traductor.Traducir("Fecha y hora", "");
            Dgv.Columns[1].HeaderText = traductor.Traducir("UsuarioB", "");
            Dgv.Columns[2].HeaderText = traductor.Traducir("Acción", "");
            label1.Text = traductor.Traducir("BITÁCORA", "");
        }

        public object LinqBitacora()
        {
            LogicaBitacora bitacora = new LogicaBitacora();
            return (from b in bitacora.ListaBitacora() select new { FECHA_HORA = b.fechaHora, USUARIO = b.usuario.Nombre_Usuario, ACCION = b.accion }).ToList();
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GUIBitacroa__FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms["Menu"].Show();
        }
    }
}
