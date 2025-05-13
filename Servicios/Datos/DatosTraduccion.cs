using Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.SqlClient;

namespace Servicios.Datos
{
    public class DatosTraduccion
    {
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

        public List<EntidadTraduccion> ListaIncremental(string consulta, string idioma)
        {
            List<EntidadTraduccion> lista = new List<EntidadTraduccion>();
            DataView dv = new DataView(gd.DevolverTabla("Traduccion"), consulta, "", DataViewRowState.Unchanged);
            foreach (DataRowView drv in dv)
            {
                DataRow drIdioma = gd.DevolverTabla("Idioma").Rows.Find(int.Parse(drv[1].ToString()));
                if (drIdioma[1].ToString() == idioma)
                {
                    DataRow drEtiqueta = gd.DevolverTabla("Etiqueta").Rows.Find(int.Parse(drv[0].ToString()));
                    EntidadTraduccion traduccion = new EntidadTraduccion(drEtiqueta[1].ToString(), drIdioma[1].ToString(), drv[2].ToString());
                    lista.Add(traduccion);
                }
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
            gd.DevolverConexion().Open();
            using (SqlBulkCopy bulk = new SqlBulkCopy(gd.DevolverConexion()))
            {
                bulk.DestinationTableName = "Traduccion"; 
                bulk.WriteToServer(CrearDataTableTemporal(idIdioma));
            }
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
                dr["textoTraducido"] = "";
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
        
    }
}
