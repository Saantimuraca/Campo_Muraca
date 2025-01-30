using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Permiso
    {
        private string Nombre;

        protected Permiso(string nombre)
        {
            Nombre = nombre;
        }

        public virtual void Agregar(Permiso pPermiso) { }

        public virtual void Eliminar(Permiso pPermiso) { }

        public virtual bool isComposite()
        {
            return false;
        }

        public string DevolverNombrePermiso()
        {
            return Nombre;
        }
    }
}
