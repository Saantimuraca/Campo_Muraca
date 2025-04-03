using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DALTraductor
    {
        Gestor_Datos gd = Gestor_Datos.INSTANCIA;
        public Dictionary<string, string> CargarTraduccion(string idioma)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (DataRowView drv in gd.DevolverTabla("Traduccion").DefaultView)
            {
                if (drv[1].ToString() == idioma)
                {
                    d.Add(drv[0].ToString(), drv[2].ToString());   
                }
            }
            return d;
        }

        public List<BETraduccion> ListaTraducciones()
        {
            List<BETraduccion> lista = new List<BETraduccion>();   
            foreach(DataRowView drv in gd.DevolverTabla("Traduccion").DefaultView)
            {
                BETraduccion traduccion = new BETraduccion(drv[0].ToString(), drv[1].ToString(), drv[2].ToString());
                lista.Add(traduccion);
            }
            return lista;
        }

        public List<BETraduccion> ListaIncremental(string consulta, string idioma)
        {
            List<BETraduccion> lista = new List<BETraduccion>();
            DataView dv = new DataView(gd.DevolverTabla("Traduccion"), consulta, "", DataViewRowState.Unchanged);
            foreach (DataRowView drv in dv)
            {
                if (drv[1].ToString() == idioma)
                {
                    BETraduccion traduccion = new BETraduccion(drv[0].ToString(), drv[1].ToString(), drv[2].ToString());
                    lista.Add(traduccion);
                }
            }
            return lista;
        }

        public void ModificarTraduccion(BETraduccion pTraduccion)
        {
            string[] clave = { pTraduccion.textoTraducir, pTraduccion.idioma };
            DataRow dr = gd.DevolverTabla("Traduccion").Rows.Find(clave);
            dr[2] = pTraduccion.textoTraducido;
            gd.ActualizarPorTabla("Traduccion");
        }

        public void AgregarTraduccion(BETraduccion pTraduccion)
        {
            DataRow dr = gd.DevolverTabla("Traduccion").NewRow();
            dr["textoTraducir"] = pTraduccion.textoTraducir;
            dr["idioma"] = pTraduccion.idioma;
            dr["textoTraducido"] = pTraduccion.textoTraducido;
            gd.DevolverTabla("Traduccion").Rows.Add(dr);
            gd.ActualizarPorTabla("Traduccion");
        }

        public void EliminarTraduccion(BETraduccion pTraduccion)
        {
            string[] clave = {pTraduccion.textoTraducir, pTraduccion.idioma};
            DataRow dr = gd.DevolverTabla("Traduccion").Rows.Find(clave);
            dr.Delete();
            gd.ActualizarPorTabla("Traduccion");
        }

        public void ModificarIdiomaTraduccion(BETraduccion pTraduccion, BEIdioma pIdioma, BEIdioma pIdiomaNuevo)
        {
            string[] clave = {pTraduccion.textoTraducir, pTraduccion.idioma};
            DataRow dr = gd.DevolverTabla("Traduccion").Rows.Find(clave);
            dr[1] = pIdiomaNuevo.idioma;
            gd.ActualizarPorTabla("Traduccion");
        }
    }
}
