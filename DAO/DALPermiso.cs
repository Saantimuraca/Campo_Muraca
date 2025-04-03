using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace ORM
{
    public class DALPermiso
    {
        Gestor_Datos dao = Gestor_Datos.INSTANCIA;
        public List<BE_Permiso> DevolverPermisosArbol()
        {
            //Primero creamos una lista para los permisos simples y otra para los compuestos.
            List<BE_Permiso> listaPermisos = new List<BE_Permiso>();
            List<BE_Permiso> listaPermisosCompuestos = new List<BE_Permiso>();
            //Recorremos cada permiso en la tabla permisos.
            foreach(DataRowView row in dao.DevolverTabla("Permiso").DefaultView)
            {
                string nombrePermiso = row[0].ToString();
                string tipoPermiso = row[1].ToString();
                if(tipoPermiso == "Compuesto")
                {
                    //Si el permiso es compuesto, lo creo y agrego a ambas listas.
                    BEPermisoCompuesto permisoCompuesto = new BEPermisoCompuesto(nombrePermiso);
                    listaPermisosCompuestos.Add(permisoCompuesto);   
                    listaPermisos.Add(permisoCompuesto);
                }
                else
                {
                    //Sino es compuesto, lo agrego solo a la lista de permisos simples.
                    BEPermisoSimple permisoSimple = new BEPermisoSimple(nombrePermiso);
                    listaPermisos.Add(permisoSimple);
                }
            }
            //Inicio un foreach para recorrer la tabla de realaciones de permisos.
            foreach (DataRowView row in dao.DevolverTabla("RelacionPermisos").DefaultView)
            {
                string nombrePermisoCompuesto = row[0].ToString();
                string nombrePermisoIncluido = row[1].ToString();
                //Encontramos el permiso compuesto al que le queremos agregar el permiso simple.
                BEPermisoCompuesto permisoCompuesto = listaPermisosCompuestos.FirstOrDefault(x => x.DevolverNombrePermiso() == nombrePermisoCompuesto) as BEPermisoCompuesto;
                //Encontramos el permiso simple que se quiere agregar y lo agregamos
                BEPermisoSimple permisoIncluido = listaPermisos.FirstOrDefault(x => x.DevolverNombrePermiso() == nombrePermisoIncluido) as BEPermisoSimple;
                permisoCompuesto.DevolverListaPermisos().Add(permisoIncluido);
            }
            //Una vez que tenemos todos los permisos compuestos por los permisos simples retornamos la lista.
            return listaPermisosCompuestos;
        }

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

        public List<BE_Permiso> DevolverPermisos(string tipo)
        {
            List<BE_Permiso> lista = new List<BE_Permiso>();
            foreach (DataRowView row in dao.DevolverTabla("Permiso").DefaultView)
            {
                if (tipo == "Todos excepto roles" && bool.Parse(row[2].ToString()) == false)
                {
                    if (row[1].ToString() == "Compuesto")
                    {
                        BEPermisoCompuesto permisoCompuesto = new BEPermisoCompuesto(row[0].ToString());
                        lista.Add(permisoCompuesto);
                    }
                    else
                    {
                        BEPermisoSimple permisoSimple = new BEPermisoSimple(row[0].ToString());
                        lista.Add(permisoSimple);
                    }
                }
                if(tipo == "Compuestos" && row[1].ToString() == "Compuesto")
                {
                    BEPermisoCompuesto permisoCompuesto = new BEPermisoCompuesto(row[0].ToString());
                    lista.Add(permisoCompuesto);
                }
                if(tipo == "Roles" && bool.Parse(row[2].ToString()) == true)
                {
                    BEPermisoCompuesto permisoCompuesto = new BEPermisoCompuesto(row[0].ToString());
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

        public bool AgregarPermiso(BE_Permiso pNuevoPermiso, bool isRol)
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

        public List<BE_Permiso> DevolverPermsisosArbol()
        {
            //Primero agregamos los permisos a sus lista correspondientes.
            List<BE_Permiso> listaCompuestos = new List<BE_Permiso>();
            List<BE_Permiso> listaPermisos = new List<BE_Permiso>();
            foreach (DataRowView row in dao.DevolverTabla("Permiso").DefaultView)
            {
                if (row[1].ToString() == "Compuesto")
                {
                    BEPermisoCompuesto permisoCompuesto = new BEPermisoCompuesto(row[0].ToString());
                    listaCompuestos.Add(permisoCompuesto);
                    listaPermisos.Add(permisoCompuesto);
                }
                else
                {
                    BEPermisoSimple permisoSimple = new BEPermisoSimple(row[0].ToString());
                    listaPermisos.Add(permisoSimple);
                }
            }
            //Ahora trabajamos con las relaciones agregando los permisos simples a los permisos compuestos que correspondan.
            foreach (DataRowView row in dao.DevolverTabla("RelacionPermisos").DefaultView)
            {
                BEPermisoCompuesto permisoCompuesto = (BEPermisoCompuesto)listaCompuestos.Find(x => x.DevolverNombrePermiso() == row[0].ToString());
                BEPermisoSimple permisoSimple = (BEPermisoSimple)listaPermisos.Find(x => x.DevolverNombrePermiso() == row[1].ToString());
                permisoCompuesto.DevolverListaPermisos().Add(permisoSimple);
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
