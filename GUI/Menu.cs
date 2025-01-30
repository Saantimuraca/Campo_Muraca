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
            
        }

        

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void opcion1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_Usuarios us = new ABM_Usuarios();
            us.ShowDialog();
        }

        private void opcion3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            a.Definir_Estado(new EstadoIniciarSesion());
        }
    }
}
