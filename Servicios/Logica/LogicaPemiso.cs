using Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Logica
{
    public class Permiso
    {
        public virtual void Agregar(EntidadPermiso pPermiso, EntidadPermisoCompuesto pPermisoCompuesto) { }

        public virtual void Eliminar(EntidadPermiso pPermiso, EntidadPermisoCompuesto pPermisoCompuesto) { }
    }
}
