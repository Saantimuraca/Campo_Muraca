using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PermisoCompuesto : Permiso
    {
        public PermisoCompuesto(string pNombre) : base(pNombre) { }

        protected List<Permiso> listaPermisos = new List<Permiso>();

        public override void Agregar(Permiso pPermiso)
        {
            listaPermisos.Add(pPermiso);
        }

        public override void Eliminar(Permiso pPermiso)
        {
            listaPermisos.Remove(pPermiso);
        }

        public override bool isComposite()
        {
            return true;
        }

        public bool VerificarPermisoIncluido(Permiso permisoActual, string permiso)
        {
            //Verifico si el objeto permiso que le mando es el permiso que estoy buscando.
            if(permisoActual.DevolverNombrePermiso() == permiso) { return true; }
            else
            {
                //Verfificamos si el permiso es compuesto.
                if(permisoActual.isComposite())
                {
                    //Si es compuesto aplicamos la funcion de verificar si es el permiso que buscamos en cada permiso de ese permiso compuesto.
                    //De esta forma nos aseguramos de verificar en cada permiso del árbol.
                    foreach(Permiso p in (permisoActual as PermisoCompuesto).listaPermisos)
                    {
                        //Si el pemiso que buscamos esta dentro del permiso compuesto que estamos analizando retorna true.
                        if (VerificarPermisoIncluido(p, permiso)) return true;
                    }
                }
            }
            //Si el permiso no se encontró en todo el árbol se retorna false.
            return false;
        }

        public List<Permiso> DevolverListaPermisos()
        {
            return listaPermisos;
        }
    }
}
