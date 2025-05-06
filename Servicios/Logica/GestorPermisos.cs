using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.Datos;
using Servicios.Entidades;

namespace Servicios.Logica
{
    public class GestorPermisos
    {
        DatosPermiso ormPermiso = new DatosPermiso();
        public bool Configurar_Control(string tag)
        {
            Sesion sesion = Sesion.INSTANCIA;
            //Si esta funcion devuelve false, el control no estará habilitado, si devuelve true, si estará
            if (tag == null || tag == "" || sesion.ObtenerUsuarioActual().Rol.DevolverNombrePermiso() == "Administrador")
            {
                return true;
            }
            return sesion.SesionTienePermiso(tag);
        }

        public bool EliminarPermiso(string pNombre)
        {
            return ormPermiso.EliminarPermiso(pNombre);
        }

        public List<EntidadPermiso> ObtenerPermisos(string tipo)
        {
            return ormPermiso.DevolverPermisos(tipo);
        }
        public bool AgregarPermisoCompuesto(string pNombre, List<string> permisos, bool isRol)
        {
            // Crear un nuevo permiso compuesto con el nombre dado
            EntidadPermiso permiso = new EntidadPermisoCompuesto(pNombre);

            // Obtener la lista de permisos existentes en una estructura de árbol
            List<EntidadPermiso> lista = ormPermiso.DevolverPermisosArbol();

            // Verificar si alguno de los permisos en la lista generaría un ciclo
            foreach (string p in permisos)
            {
                // Buscar el permiso en la lista y convertirlo a tipo BEPermisoCompuesto
                EntidadPermisoCompuesto permisoCompuesto = (EntidadPermisoCompuesto)lista.Find(x => x.DevolverNombrePermiso() == p);

                // Si el permiso a agregar ya existe en la jerarquía, cancelar la operación
                if (BuscarPermiso(pNombre, permisoCompuesto)) return false;
            }

            // Verificar si el permiso con ese nombre ya existe en la base de datos
            if (ormPermiso.ExistePermiso(pNombre)) return false; 
            else
            {
                // Agregar el nuevo permiso a la base de datos
                ormPermiso.AgregarPermiso(permiso, isRol);

                // Establecer las relaciones con los permisos hijos
                foreach (string p in permisos)
                {
                    ormPermiso.AgregarRelaciones(pNombre, p);
                }
            }

            // Si todo salió bien, devolver true para indicar que el permiso se creó correctamente
            return true;
        }

        public bool BuscarPermiso(string pNombrePermiso, EntidadPermisoCompuesto pPermisoCompuesto)
        {
            //Buscar si el permiso que se quiere agregar ya se encuentra registrado
            if(pPermisoCompuesto == null) return false;
            foreach(var permiso in pPermisoCompuesto.DevolverListaPermisos())
            {
                //Si el nombre del permiso, existe se devuelve true
                if(permiso.DevolverNombrePermiso() == pNombrePermiso) return true;
                else if(permiso.isComposite())
                {
                    if (BuscarPermisoRecursivo(pNombrePermiso, (EntidadPermisoCompuesto)permiso)) return true;
                }
            }
            return false;
        }

        public bool BuscarPermisoRecursivo(string pNombrePermiso, EntidadPermisoCompuesto pPermisoCompuesto)
        {
            foreach(var permiso in pPermisoCompuesto.DevolverListaPermisos())
            {
                if (permiso.DevolverNombrePermiso() == pNombrePermiso) return true;
                else if (permiso.isComposite())
                {
                    if (BuscarPermisoRecursivo(pNombrePermiso, (EntidadPermisoCompuesto)permiso)) return true;
                }
            }
            return false;
        }

        public List<EntidadPermiso> ObtenerPermisosArbol()
        {
            return ormPermiso.DevolverPermsisosArbol();
        }

        public void ModificarNombrePermiso(string pNombrePermiso, string pNuevoNombre)
        {
            ormPermiso.ModificarNombrePermiso(pNombrePermiso, pNuevoNombre);
        }
    }
}
