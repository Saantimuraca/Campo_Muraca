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
    public partial class Menu : Form
    {
        Admin_Forms a = Admin_Forms.INSTANCIA;
        public Menu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            a.Mostrar_Form_Login();
        }
    }
}
