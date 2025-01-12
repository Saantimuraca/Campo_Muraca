using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class Admin_Forms
    {
        private static Admin_Forms instancia;
        public static Admin_Forms INSTANCIA
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new Admin_Forms();
                }
                return instancia;
            }
        }

        public void Mostrar_Form_Login()
        {
            using(Login l = new Login())
            {
                l.ShowDialog();
                if(!l.islogueado)
                {
                    Environment.Exit(0);
                }
            }
        }

        public void Mostrar_Menu()
        {
            using (Menu m = new Menu())
            {
                m.ShowDialog();
            }
        }
    }
}
