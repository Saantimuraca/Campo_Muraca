using Servicios.Datos;
using Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Logica
{
    public class LogicaPermisoCompuesto
    {
        DatosPermiso dp = new DatosPermiso();
        public void Agregar(EntidadPermiso pPermiso, EntidadPermisoCompuesto pPermisoCompuesto)
        {
            pPermisoCompuesto.DevolverListaPermisos().Add(pPermiso);
        }
        public void Eliminar(EntidadPermiso pPermiso, EntidadPermisoCompuesto pPermisoCompuesto)
        {
            pPermisoCompuesto.DevolverListaPermisos().Remove(pPermiso);
        }
        public bool VerificarPermisoIncluido(EntidadPermiso permisoActual, string permiso)
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
                    List<EntidadPermiso> lista = (dp.DevolverPermisosArbol().Find(x => x.DevolverNombrePermiso() == permisoActual.DevolverNombrePermiso()) as EntidadPermisoCompuesto).listaPermisos;
                    foreach (EntidadPermiso p in lista)
                    {
                        //Si el pemiso que buscamos esta dentro del permiso compuesto que estamos analizando retorna true.
                        if (VerificarPermisoIncluido(p, permiso)) return true;
                    }
                }
            }
            //Si el permiso no se encontró en todo el árbol se retorna false.
            return false;
        }
    }
}
