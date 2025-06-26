﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.Datos;
using Servicios.Entidades;
using System.Xml.Linq;
using Org.BouncyCastle.Crypto;
using System.Collections;

namespace Servicios.Logica
{
    public class GestorPermisos
    {
        DatosPermiso ormPermiso = new DatosPermiso();
        public bool Configurar_Control(string tag)
        {
            Sesion sesion = Sesion.INSTANCIA;
            //Si esta funcion devuelve false, el control no va estar habilitado, si devuelve true, si
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
            string tipo = isRol ? "rol" : "permiso";
            EntidadPermiso permiso = new EntidadPermisoCompuesto(pNombre);
            List<EntidadPermiso> lista = ormPermiso.DevolverPermsisosArbol();
            //Verificar si alguno de los permisos en la lista generaría un ciclo
            foreach (string p in permisos)
            {
                EntidadPermisoCompuesto permisoCompuesto = (EntidadPermisoCompuesto)lista.Find(x => x.DevolverNombrePermiso() == p);
                if (BuscarPermiso(pNombre, permisoCompuesto))
                {
                    string error = $"No se puede asignar el permiso {{permisoExistente}} al nuevo {tipo} {{nuevoPermiso}} porque generaría una relación circular.";
                    string aux = error.Replace("{permisoExistente}", p).Replace("{nuevoPermiso}", pNombre);
                    throw new Exception(aux);
                }
            }
            //Verificar si el permiso con ese nombre ya existe en la base de datos
            if (ormPermiso.ExistePermiso(pNombre)) throw new Exception($"{tipo} {"existente"}");
            else
            {
                //Verificar si hay redundancia
                foreach (string p in permisos)
                {
                    EntidadPermisoCompuesto padre = (EntidadPermisoCompuesto)lista.Find(x => x.DevolverNombrePermiso() == p);
                    foreach (string otro in permisos)
                    {
                        if (p != otro && BuscarPermiso(otro, padre))
                        {
                            string error = $"El permiso {{otro}} ya está contenido dentro del permiso {{p}}. No es necesario asignarlo nuevamente.";
                            string aux = error.Replace("{otro}", otro).Replace("{p}", p);
                        }
                    }
                }
                ormPermiso.AgregarPermiso(permiso, isRol);
                foreach (string p in permisos)
                {
                    ormPermiso.AgregarRelaciones(pNombre, p);
                }
            }
            return true;
        }

        public bool BuscarPermiso(string pNombrePermiso, EntidadPermiso pPermisoCompuesto)
        {
            //Buscar si el permiso que se quiere agregar ya se encuentra registrado
            if(pPermisoCompuesto == null) return false;
            pPermisoCompuesto = ormPermiso.DevolverPermsisosArbol().Find(x => x.DevolverNombrePermiso() == pPermisoCompuesto.DevolverNombrePermiso()) as EntidadPermisoCompuesto;
            foreach(var permiso in (pPermisoCompuesto as EntidadPermisoCompuesto).listaPermisos)
            {
                //Si el nombre del permiso, existe se devuelve true
                if(permiso.DevolverNombrePermiso().Equals(pNombrePermiso, StringComparison.OrdinalIgnoreCase)) return true;
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

        public EntidadPermiso DevolverPermisoConHijos(string pNombre)
        {
            return ormPermiso.DevolverPermsisosArbol().Find(x => x.DevolverNombrePermiso() == pNombre);
        }

        public void ActualizarPermisos(string pPermiso, List<string> pPermisosSeleccionados, List<string> listaValidaciones)
        {
            EntidadPermiso p = new EntidadPermisoCompuesto(pPermiso);
            List<EntidadPermiso> lista = ormPermiso.DevolverPermsisosArbol();
            EntidadPermiso permisoEvaluar = DevolverPermisoConHijos(pPermiso);
            foreach (string permiso in listaValidaciones)
            {
                if (BuscarPermiso(permiso, permisoEvaluar))
                {
                    string aux = Traductor.INSTANCIA.Traducir("{permiso} ya se encuentra en la jerarquía", "");
                    string excepcion = aux.Replace("{permiso}", permiso);
                    throw new Exception(excepcion);
                }
            }
            foreach (string permiso in pPermisosSeleccionados)
            {
                EntidadPermisoCompuesto compuesto = (EntidadPermisoCompuesto)lista.Find(x => x.DevolverNombrePermiso() == permiso);
                if (BuscarPermiso(pPermiso, compuesto)) { throw new Exception(Traductor.INSTANCIA.Traducir("Dependencia circular", "")); }

            }
            if (pPermisosSeleccionados.Contains(pPermiso)) { throw new Exception(Traductor.INSTANCIA.Traducir("No puede agregar un permiso a si mismo", "")); }
            foreach (string permiso in pPermisosSeleccionados)
            {
                if (EstaIncluidoEnOtroPermiso(permiso, pPermisosSeleccionados, lista))
                {
                    string error = Traductor.INSTANCIA.Traducir("El permiso {permiso} ya está contenido en otro permiso seleccionado. No es necesario agregarlo.", "");
                    string aux = error.Replace("{permiso}", permiso);
                    throw new Exception(aux);
                }
            }
            if (TienenHijosCompartidos(pPermisosSeleccionados, lista)) { throw new Exception(Traductor.INSTANCIA.Traducir("Dos o más permisos seleccionados incluyen al mismo permiso hijo. Esto generaría una redundancia.", "")); }
            ormPermiso.EliminarRelaciones(pPermiso);
            foreach (string permiso in pPermisosSeleccionados)
            {
                ormPermiso.AgregarRelaciones(pPermiso, permiso);
            }
        }

        private bool EstaIncluidoEnOtroPermiso(string permisoEvaluado, List<string> todosLosSeleccionados, List<EntidadPermiso> arbolPermisos)
        {
            foreach (string otroPermiso in todosLosSeleccionados)
            {
                if (permisoEvaluado == otroPermiso) continue;

                EntidadPermiso padre = arbolPermisos.Find(x => x.DevolverNombrePermiso() == otroPermiso);
                if (padre != null && BuscarPermiso(permisoEvaluado, padre)) return true;
            }
            return false;
        }

        private bool TienenHijosCompartidos(List<string> permisosSeleccionados, List<EntidadPermiso> arbol)
        {
            var hijosTotales = new HashSet<string>();
            foreach (string permiso in permisosSeleccionados)
            {
                EntidadPermiso padre = arbol.Find(x => x.DevolverNombrePermiso() == permiso);
                if (padre != null && padre.isComposite())
                {
                    var hijos = ObtenerTodosLosHijos((EntidadPermisoCompuesto)padre);
                    foreach (string hijo in hijos)
                    {
                        if (!hijosTotales.Add(hijo))
                        {
                            //Redundancia
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private List<string> ObtenerTodosLosHijos(EntidadPermisoCompuesto permiso)
        {
            List<string> hijos = new List<string>();
            foreach (EntidadPermiso hijo in (permiso as EntidadPermisoCompuesto).listaPermisos)
            {
                hijos.Add(hijo.DevolverNombrePermiso());
                if (hijo.isComposite())
                    hijos.AddRange(ObtenerTodosLosHijos((EntidadPermisoCompuesto)hijo));
            }
            return hijos;
        }

        public bool ExistePermiso(string pNombrePermiso)
        {
            return ormPermiso.ExistePermiso(pNombrePermiso);
        }
    }
}
