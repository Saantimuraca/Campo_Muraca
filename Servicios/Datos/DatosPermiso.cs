using System;
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

        /*public List<EntidadPermiso> DevolverPermisosArbol()
        {
            //Primero creamos una lista para los permisos simples y otra para los compuestos.
            List<EntidadPermiso> listaPermisos = new List<EntidadPermiso>();
            List<EntidadPermiso> listaPermisosCompuestos = new List<EntidadPermiso>();
            //Recorremos cada permiso en la tabla permisos.
            foreach(DataRowView row in dao.DevolverTabla("Permiso").DefaultView)
            {
                string nombrePermiso = row[0].ToString();
                string tipoPermiso = row[1].ToString();
                if(tipoPermiso == "Compuesto")
                {
                    //Si el permiso es compuesto, lo creo y agrego a ambas listas.
                    EntidadPermisoCompuesto permisoCompuesto = new EntidadPermisoCompuesto(nombrePermiso);
                    listaPermisosCompuestos.Add(permisoCompuesto);   
                    listaPermisos.Add(permisoCompuesto);
                }
                else
                {
                    //Sino es compuesto, lo agrego solo a la lista de permisos.
                    EntidadPermisoSimple permisoSimple = new EntidadPermisoSimple(nombrePermiso);
                    listaPermisos.Add(permisoSimple);
                }
            }
            //Inicio un foreach para recorrer la tabla de realaciones de permisos.
            foreach (DataRowView row in dao.DevolverTabla("RelacionPermisos").DefaultView)
            {
                string nombrePermisoCompuesto = row[0].ToString();
                string nombrePermisoIncluido = row[1].ToString();
                //Encontramos el permiso compuesto al que le queremos agregar el permiso simple.
                EntidadPermisoCompuesto permisoCompuesto = listaPermisosCompuestos.FirstOrDefault(x => x.DevolverNombrePermiso() == nombrePermisoCompuesto) as EntidadPermisoCompuesto;
                //Encontramos el permiso simple que se quiere agregar y lo agregamos
                EntidadPermisoSimple permisoIncluido = listaPermisos.FirstOrDefault(x => x.DevolverNombrePermiso() == nombrePermisoIncluido) as EntidadPermisoSimple;
                permisoCompuesto.DevolverListaPermisos().Add(permisoIncluido);
            }
            //Una vez que tenemos todos los permisos compuestos por los permisos simples retornamos la lista.
            return listaPermisosCompuestos;
        }*/

        public bool EliminarPermiso(string pNombre)
        {
            try
            {
               foreach(DataRowView row in dao.DevolverTabla("RelacionPermisos").DefaultView)
               {
                    if (row[0].ToString() == pNombre)
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
                if (row[0].ToString() == pNombrePermiso) { return true; }
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
            //Primero agregamos los permisos a sus lista correspondientes.
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

                //Buscar el permiso compuesto
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

        public void ActualizarPermisos(string pPermiso, List<string> pPermisosSeleccionados)
        {
            EntidadPermiso permisoSeleccionado = DevolverPermsisosArbol().Find(x => x.DevolverNombrePermiso() == pPermiso);
            foreach(string nombrePermiso in pPermisosSeleccionados)
            {
                if(!ContienePermiso(permisoSeleccionado, nombrePermiso))
                {
                    DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("RelacionPermisos").NewRow();
                    dr["NombrePermisoCompuesto"] = pPermiso;
                    dr["NombrePermisoIncluido"] = nombrePermiso;
                    Gestor_Datos.INSTANCIA.DevolverTabla("RelacionPermisos").Rows.Add(dr);
                    Gestor_Datos.INSTANCIA.ActualizarPorTabla("RelacionPermisos");
                }
            }
            foreach(EntidadPermiso permisoYaAgregado in (permisoSeleccionado as EntidadPermisoCompuesto).listaPermisos)
            {
                if (!EstaEnSeleccionados(permisoYaAgregado, pPermisosSeleccionados))
                {
                    string[] clave = { permisoSeleccionado.DevolverNombrePermiso(), permisoYaAgregado.DevolverNombrePermiso() };
                    DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("RelacionPermisos").Rows.Find(clave);
                    if (dr != null)
                    {
                        dr.Delete();
                    }
                }
            }
        }

        private bool ContienePermiso(EntidadPermiso pPermisoActual, string pNombrePermisoBuscado)
        {
            //Caso base
            if(pPermisoActual.DevolverNombrePermiso() == pNombrePermisoBuscado) { return true; }
            //Si es compuesto
            if(pPermisoActual.isComposite())
            {
                foreach(EntidadPermiso hijo in (pPermisoActual as EntidadPermisoCompuesto).listaPermisos)
                {
                    if(ContienePermiso(hijo, pNombrePermisoBuscado)) {  return true; }
                }
            }
            //Si no se encontró
            return false;
        }

        private bool EstaEnSeleccionados(EntidadPermiso permisoEvaluado, List<string> pPermisosSeleccionados)
        {
            // Caso base
            if (pPermisosSeleccionados.Contains(permisoEvaluado.DevolverNombrePermiso()))
                return true;

            // Si es compuesto, reviso los hijos
            if (permisoEvaluado.isComposite())
            {
                foreach (EntidadPermiso hijo in ((EntidadPermisoCompuesto)permisoEvaluado).DevolverListaPermisos())
                {
                    if (EstaEnSeleccionados(hijo, pPermisosSeleccionados))
                        return true;
                }
            }

            // No está en la lista
            return false;
        }
    }
}
