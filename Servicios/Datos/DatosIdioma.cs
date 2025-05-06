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
    public class DatosIdioma
    {
        Gestor_Datos gd = Gestor_Datos.INSTANCIA;
        public void Agregar(EntidadIdioma pIdioma)
        {
            DataRow dr = gd.DevolverTabla("Idioma").NewRow();
            dr["idIdioma"] = pIdioma.idIdioma;
            dr["nombre"] = pIdioma.idioma;
            gd.DevolverTabla("Idioma").Rows.Add(dr);
            gd.ActualizarPorTabla("Idioma");
        }

        public void Eliminar(EntidadIdioma pIdioma)
        {
            DataRow dr;
            foreach(DataRowView row in gd.DevolverTabla("Idioma").DefaultView)
            {
                if (row[1].ToString() == pIdioma.idioma)
                {
                    dr = gd.DevolverTabla("Idioma").Rows.Find(int.Parse(row[0].ToString()));
                    dr.Delete();
                }
            }
            gd.ActualizarPorTabla("Idioma");
        }

        public void Modificar(EntidadIdioma pIdiomaModificar, EntidadIdioma pIdiomaModificado)
        {
            DataRow dr;
            foreach (DataRowView row in gd.DevolverTabla("Idioma").DefaultView)
            {
                if (row[1].ToString() == pIdiomaModificar.idioma)
                {
                    dr = gd.DevolverTabla("Idioma").Rows.Find(int.Parse(row[0].ToString()));
                    dr["nombre"] = pIdiomaModificado.idioma;
                }
            }
            gd.ActualizarPorTabla("Idioma");
        }

        public List<EntidadIdioma> ListaIdiomas()
        {
            List<EntidadIdioma> lista = new List<EntidadIdioma>();
            foreach (DataRowView row in gd.DevolverTabla("Idioma").DefaultView)
            {
                EntidadIdioma idioma = new EntidadIdioma(row[1].ToString());
                lista.Add(idioma);
            }
            return lista;
        }

        
    }
}
