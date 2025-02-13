using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPermisoSimple : BE_Permiso
    {
        public BEPermisoSimple(string pNombre) : base(pNombre)
        {

        }

        public override string ToString()
        {
            return DevolverNombrePermiso(); // Devuelve el nombre en lugar del tipo de objeto
        }
    }
}
