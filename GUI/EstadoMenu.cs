using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class EstadoMenu : Estado
    {
        Menu Menu;
        public override void Cerrar_Estado()
        {
            Menu?.Dispose();
        }

        public override void Ejecutar_Estado()
        {
            Menu = new Menu();
            Menu.ShowDialog();
        }
    }
}
