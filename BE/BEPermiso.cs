using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class BE_Permiso
    {
        private string Nombre;

        public BE_Permiso(string nombre)
        {
            Nombre = nombre;
        }

        public string DevolverNombrePermiso()
        {
            return Nombre;
        }

        public virtual bool isComposite()
        {
            return false;
        }
    }
}
