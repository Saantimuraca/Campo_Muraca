using Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

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

        public void ModificarTraduccion(EntidadTraduccion pTraduccion)
        {

            string[] clave = { pTraduccion.textoTraducir, pTraduccion.idioma };
            DataRow dr = gd.DevolverTabla("Traduccion").Rows.Find(clave);
            dr[2] = pTraduccion.textoTraducido;
            gd.ActualizarPorTabla("Traduccion");
        }

        public void AgregarTraduccion(EntidadTraduccion pTraduccion)
        {
            DataRow dr = gd.DevolverTabla("Traduccion").NewRow();
            dr["textoTraducir"] = pTraduccion.textoTraducir;
            dr["idioma"] = pTraduccion.idioma;
            dr["textoTraducido"] = pTraduccion.textoTraducido;
            gd.DevolverTabla("Traduccion").Rows.Add(dr);
            gd.ActualizarPorTabla("Traduccion");
        }

        public void EliminarTraduccion(EntidadTraduccion pTraduccion)
        {
            string[] clave = {pTraduccion.textoTraducir, pTraduccion.idioma};
            DataRow dr = gd.DevolverTabla("Traduccion").Rows.Find(clave);
            dr.Delete();
            gd.ActualizarPorTabla("Traduccion");
        }

        public void ModificarIdiomaTraduccion(EntidadTraduccion pTraduccion, EntidadIdioma pIdioma, EntidadIdioma pIdiomaNuevo)
        {
            string[] clave = {pTraduccion.textoTraducir, pTraduccion.idioma};
            DataRow dr = gd.DevolverTabla("Traduccion").Rows.Find(clave);
            dr[1] = pIdiomaNuevo.idioma;
            gd.ActualizarPorTabla("Traduccion");
        }
    }
}
