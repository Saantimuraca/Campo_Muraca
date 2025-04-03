using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Permiso
    {
        public virtual void Agregar(BE_Permiso pPermiso, BEPermisoCompuesto pPermisoCompuesto) { }

        public virtual void Eliminar(BE_Permiso pPermiso, BEPermisoCompuesto pPermisoCompuesto) { }

        public virtual bool isComposite()
        {
            return false;
        }
    }
}
