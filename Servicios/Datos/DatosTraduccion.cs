using Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.SqlClient;
using DAO;

namespace Servicios.Datos
{
    public class DatosTraduccion : IIntegridadRepositorio
    {
        private static DatosTraduccion instancia;
        public static DatosTraduccion INSTANCIA
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new DatosTraduccion();
                }
                return instancia;
            }
        }
        Gestor_Datos gd = Gestor_Datos.INSTANCIA;
        public Dictionary<string, string> CargarTraduccion(string idioma)
        {
            int idIdioma = 0;
            foreach(DataRowView drv in gd.DevolverTabla("Idioma").DefaultView)
            {
                if (drv[1].ToString() == idioma)
                {
                   idIdioma = int.Parse(drv[0].ToString());
                }
            }
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (DataRowView drv in gd.DevolverTabla("Traduccion").DefaultView)
            {
                DataRow dr = gd.DevolverTabla("Etiqueta").Rows.Find(int.Parse(drv[0].ToString()));
                string textoTraducir = dr[1].ToString();
                if (int.Parse(drv[1].ToString()) == idIdioma)
                {
                    d.Add(textoTraducir, drv[2].ToString());   
                }
            }
            return d;
        }

        public void AgregarDvh(DataRow dr, string pDvh)
        {
            dr["dvh"] = pDvh;
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("Traduccion");
        }

        public DataRow DevolverRow(string pTextoTraducir, int pIdioma)
        {
            int idTextoTraducir = DevolverIdTextoTraducir(pTextoTraducir);
            object[] clave = { idTextoTraducir, pIdioma };
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Traduccion").Rows.Find(clave);
            return dr;
        }

        private int DevolverIdTextoTraducir(string pTextoTraducir)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Traduccion").Select($"nombre = '{pTextoTraducir}'").FirstOrDefault();
            return int.Parse(dr[1].ToString());
        }

        public int DevolverUltimoId()
        {
            int maxId = 0;
            foreach (DataRow row in Gestor_Datos.INSTANCIA.DevolverTabla("Traduccion").Rows)
            {
                int id = int.Parse(row["idIdioma"].ToString());
                if (id > maxId)
                    maxId = id;
            }
            return maxId;
        }

        public bool EvaluarDisponibilidad()
        {
            foreach(DataRowView row in gd.DevolverTabla("Traduccion").DefaultView)
            {
                if (row[2].ToString() == "") return false;
            }
            return true;
        }

        public List<EntidadTraduccion> ListaTraducciones()
        {
            List<EntidadTraduccion> lista = new List<EntidadTraduccion>();   
            foreach(DataRowView drv in gd.DevolverTabla("Traduccion").DefaultView)
            {
                DataRow drEtiqueta = gd.DevolverTabla("Etiqueta").Rows.Find(int.Parse(drv[0].ToString()));
                DataRow drIdioma = gd.DevolverTabla("Idioma").Rows.Find(int.Parse(drv[1].ToString()));
                EntidadTraduccion traduccion = new EntidadTraduccion(drEtiqueta[1].ToString(), drIdioma[1].ToString(), drv[2].ToString());
                lista.Add(traduccion);
            }
            return lista;
        }

        public int DevolverIdTraduccion(string pEtiqueta)
        {
            foreach(DataRowView row in gd.DevolverTabla("Etiqueta").DefaultView)
            {
                if(row[1].ToString() == pEtiqueta)
                {
                    return int.Parse(row[0].ToString());
                }
            }
            return 0;
        }

        public void ModificarTraduccion(Dictionary<string, string> cambios, int idIdioma)
        {
            foreach(var par in cambios)
            {
                string key = par.Key;
                DataRow dr = gd.DevolverTabla("Traduccion").Rows.Find(new object[] { DevolverIdTraduccion(key), idIdioma });
                dr["textoTraducido"] = par.Value;
                gd.ActualizarPorTabla("Traduccion");
            }
        }

        public void AgregarTraduccion(int idIdioma)
        {
            SqlConnection conn = gd.DevolverConexion();

            if (conn.State != ConnectionState.Open)
                conn.Open();

            using (SqlBulkCopy bulk = new SqlBulkCopy(conn))
            {
                bulk.DestinationTableName = "Traduccion";
                bulk.WriteToServer(CrearDataTableTemporal(idIdioma));
            }
            gd.ActualizarPorTabla("Traduccion");
        }

        public List<DataRow> ColeccionDataRow(int pIdIdioma)
        {
            List<DataRow> lista = new List<DataRow>();
            foreach (DataRow row in Gestor_Datos.INSTANCIA.DevolverTabla("Traduccion").Rows)
            {
                if(pIdIdioma == int.Parse(row[1].ToString())) { lista.Add(row); }
            }
            return lista;
        }

        private DataTable CrearDataTableTemporal(int idIdioma)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("textoTraducir", typeof(int));
            tabla.Columns.Add("idioma", typeof(int));
            tabla.Columns.Add("textoTraducido", typeof(string));
            tabla.PrimaryKey = new DataColumn[] { tabla.Columns[0], tabla.Columns[1] };
            foreach(DataRowView row in gd.DevolverTabla("Etiqueta").DefaultView)
            {
                DataRow dr = tabla.NewRow();
                dr["textoTraducir"] = int.Parse(row[0].ToString());
                dr["idioma"] = idIdioma;
                dr["textoTraducido"] = "Sin traducción";
                tabla.Rows.Add(dr); 
            }
            return tabla;
        }
        public void EliminarTraduccion(EntidadTraduccion pTraduccion)
        {
            int idIdioma = 0;
            int idEtiqueta = 0;
            foreach(DataRowView row in gd.DevolverTabla("Idioma").DefaultView)
            {
                if(pTraduccion.idioma == row[1].ToString()) idIdioma = int.Parse(row[0].ToString()); continue;
            }
            foreach(DataRowView row in gd.DevolverTabla("Etiqueta").DefaultView)
            {
                if(pTraduccion.textoTraducir == row[1].ToString()) idEtiqueta = int.Parse(row[0].ToString()); continue;
            }
            DataRow dr = gd.DevolverTabla("Traduccion").Rows.Find(new object[] {idEtiqueta, idIdioma});
            dr.Delete();
            gd.ActualizarPorTabla("Traduccion");
        }

        public IEnumerable<DataRow> ObtenerEntidades()
        {
            return Gestor_Datos.INSTANCIA.DevolverTabla("Traduccion").Rows.Cast<DataRow>().OrderBy(r => r.Field<int>("textoTraducir")).OrderBy(r => r.Field<int>("idioma")).Concat(Gestor_Datos.INSTANCIA.DevolverTabla("Etiqueta").Rows.Cast<DataRow>().OrderBy(r => r.Field<int>("id")));
        }

    }
}
