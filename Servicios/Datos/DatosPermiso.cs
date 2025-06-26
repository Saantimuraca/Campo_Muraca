﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Servicios.Entidades;

namespace Servicios.Datos
{
    public class DatosPermiso
    {
        
        Gestor_Datos dao = Gestor_Datos.INSTANCIA;

        public bool EliminarPermiso(string pNombre)
        {
            try
            {
               foreach(DataRowView row in dao.DevolverTabla("RelacionPermisos").DefaultView)
               {
                    if (row[0].ToString() == pNombre || row[1].ToString() == pNombre)
                    {
                        object[] claveCompuesta = { row[0], row[1] };
                        DataRow drRelacionPermisos = dao.DevolverTabla("RelacionPermisos").Rows.Find(claveCompuesta);
                        drRelacionPermisos.Delete();
                    }
               }
               DataRow drPermiso = dao.DevolverTabla("Permiso").Rows.Find(pNombre);
               drPermiso.Delete();
                dao.ActualizarPorTabla("RelacionPermisos");
                dao.ActualizarPorTabla("Permiso");
               return true;
            }
            catch { return false; }
        }

        public void EliminarRelaciones(string pNombrePermiso)
        {
            // Guardo las relaciones a eliminar en una lista auxiliar
            List<DataRow> filasAEliminar = new List<DataRow>();
            DataTable tablaRelaciones = dao.DevolverTabla("RelacionPermisos");

            foreach (DataRow fila in tablaRelaciones.Rows)
            {
                if (fila.RowState != DataRowState.Deleted && fila[0].ToString() == pNombrePermiso)
                {
                    filasAEliminar.Add(fila);
                }
            }

            // Elimino las filas fuera del foreach original para evitar errores
            foreach (DataRow fila in filasAEliminar)
            {
                fila.Delete();
            }

            dao.ActualizarPorTabla("RelacionPermisos");
        }

        public List<EntidadPermiso> DevolverPermisos(string tipo)
        {
            List<EntidadPermiso> lista = new List<EntidadPermiso>();
            foreach (DataRowView row in dao.DevolverTabla("Permiso").DefaultView)
            {
                if (tipo == "Todos excepto roles" && bool.Parse(row[2].ToString()) == false)
                {
                    if (row[1].ToString() == "Compuesto")
                    {
                        EntidadPermisoCompuesto permisoCompuesto = new EntidadPermisoCompuesto(row[0].ToString());
                        lista.Add(permisoCompuesto);
                    }
                    else
                    {
                        EntidadPermisoSimple permisoSimple = new EntidadPermisoSimple(row[0].ToString());
                        lista.Add(permisoSimple);
                    }
                }
                if(tipo == "Compuestos" && row[1].ToString() == "Compuesto")
                {
                    EntidadPermisoCompuesto permisoCompuesto = new EntidadPermisoCompuesto(row[0].ToString());
                    lista.Add(permisoCompuesto);
                }
                if(tipo == "Roles" && bool.Parse(row[2].ToString()) == true)
                {
                    EntidadPermisoCompuesto permisoCompuesto = new EntidadPermisoCompuesto(row[0].ToString());
                    lista.Add(permisoCompuesto);
                }
            }
            return lista;
        }

        public bool ExistePermiso(string pNombrePermiso)
        {
            foreach (DataRowView row in dao.DevolverTabla("Permiso").DefaultView)
            {
                if (row[0].ToString().Equals(pNombrePermiso, StringComparison.OrdinalIgnoreCase)) { return true; }
            }
            return false;
        }

        public bool AgregarPermiso(EntidadPermiso pNuevoPermiso, bool isRol)
        {
            try
            {
                DataRow drPermiso = dao.DevolverTabla("Permiso").NewRow();
                drPermiso[0] = pNuevoPermiso.DevolverNombrePermiso();
                drPermiso[1] = pNuevoPermiso.isComposite() == true ? "Compuesto" : "Simple";
                drPermiso[2] = isRol;
                dao.DevolverTabla("Permiso").Rows.Add(drPermiso);
                dao.ActualizarPorTabla("Permiso");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AgregarRelaciones(string compuesto, string simple)
        {
            try
            {
                DataRow drRelacionPermiso = dao.DevolverTabla("RelacionPermisos").NewRow();
                drRelacionPermiso[0] = compuesto;
                drRelacionPermiso[1] = simple;
                dao.DevolverTabla("RelacionPermisos").Rows.Add (drRelacionPermiso);
                dao.ActualizarPorTabla("RelacionPermisos");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<EntidadPermiso> DevolverPermsisosArbol()
        {
            //Primero agrego los permisos a sus lista correspondientes.
            List<EntidadPermiso> listaCompuestos = new List<EntidadPermiso>();
            List<EntidadPermiso> listaPermisos = new List<EntidadPermiso>();
            foreach (DataRowView row in dao.DevolverTabla("Permiso").DefaultView)
            {
                if (row[1].ToString() == "Compuesto")
                {
                    EntidadPermisoCompuesto permisoCompuesto = new EntidadPermisoCompuesto(row[0].ToString());
                    listaCompuestos.Add(permisoCompuesto);
                    listaPermisos.Add(permisoCompuesto);
                }
                else
                {
                    EntidadPermisoSimple permisoSimple = new EntidadPermisoSimple(row[0].ToString());
                    listaPermisos.Add(permisoSimple);
                }
            }
            //Ahora agrego los permisos simples o compuestos a los permisos compuestos que correspondan.
            foreach (DataRowView row in dao.DevolverTabla("RelacionPermisos").DefaultView)
            {
                string nombrePadre = row[0].ToString();
                string nombreHijo = row[1].ToString();
                EntidadPermisoCompuesto permisoCompuesto = (EntidadPermisoCompuesto)listaCompuestos.Find(x => x.DevolverNombrePermiso() == nombrePadre);
                if (permisoCompuesto == null)
                {
                    continue;
                }
                //Buscar el permiso hijo en la lista general (puede ser simple o compuesto)
                var resultado = listaPermisos.Find(x => x.DevolverNombrePermiso() == nombreHijo);
                if (resultado == null)
                {
                    continue;
                }
                //Agregar hijo si es válido
                permisoCompuesto.DevolverListaPermisos().Add(resultado);
            }
            return listaCompuestos;
        }

        public void ModificarNombrePermiso(string pNombre, string pNuevoNombre)
        {
            foreach (DataRowView row in dao.DevolverTabla("RelacionPermisos").DefaultView)
            {
                if (row[0].ToString() == pNombre)
                {
                    object[] claveCompuesta = { row[0], row[1] };
                    DataRow drRelacionPermisos = dao.DevolverTabla("RelacionPermisos").Rows.Find(claveCompuesta);
                    drRelacionPermisos[0] = pNuevoNombre;
                }
            }
            DataRow drPermiso = dao.DevolverTabla("Permiso").Rows.Find(pNombre);
            drPermiso[0] = pNuevoNombre;
            dao.ActualizarPorTabla("RelacionPermisos");
            dao.ActualizarPorTabla("Permiso");
        }   
    }
}
