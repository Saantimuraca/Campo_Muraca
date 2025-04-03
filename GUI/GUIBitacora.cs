using Servicios;
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
        
        public GUIBitacroa_()
        {
            InitializeComponent();
            Dgv.DataSource = null;
            Dgv.DataSource = LinqBitacora();
        }

        public object LinqBitacora()
        {
            Bitacora bitacora = new Bitacora();
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
