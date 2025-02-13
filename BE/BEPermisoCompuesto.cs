using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPermisoCompuesto : BE_Permiso
    {
        public BEPermisoCompuesto(string pNombre) : base(pNombre) { }

        public List<BE_Permiso> listaPermisos = new List<BE_Permiso>();

        public List<BE_Permiso> DevolverListaPermisos()
        {
            return listaPermisos;
        }

        public override bool isComposite()
        {
            return true;
        }

        public override string ToString()
        {
            return DevolverNombrePermiso(); // Devuelve el nombre en lugar del tipo de objeto
        }
    }
}
