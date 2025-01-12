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
    public partial class Login : Form
    {
        public bool islogueado = false;
        Admin_Forms a = Admin_Forms.INSTANCIA;
        public Login()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
           islogueado = true;
            this.Hide();
            a.Mostrar_Menu();
            this.Close();
        }
    }
}
