using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class EstadoCerrarApp : Estado
    {
        public override void Cerrar_Estado()
        {
            
        }

        public override void Ejecutar_Estado()
        {
            Environment.Exit(0);
        }
    }
}
