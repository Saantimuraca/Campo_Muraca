using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal abstract class Estado
    {
        public abstract void Cerrar_Estado();

        public abstract void Ejecutar_Estado();
    }
}
