using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.Entidades;

namespace Servicios.Entidades
{
    public class EntidadPermisoSimple : EntidadPermiso
    {
        public EntidadPermisoSimple(string pNombre) : base(pNombre)
        {

        }

        public override string ToString()
        {
            return DevolverNombrePermiso(); // Devuelve el nombre en lugar del tipo de objeto
        }
    }
}
