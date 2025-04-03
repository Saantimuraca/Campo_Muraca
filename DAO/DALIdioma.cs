using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DALIdioma
    {
        Gestor_Datos gd = Gestor_Datos.INSTANCIA;
        public void Agregar(BEIdioma pIdioma)
        {
            DataRow dr = gd.DevolverTabla("Idioma").NewRow();
            dr["idIdioma"] = pIdioma.idIdioma;
            dr["nombre"] = pIdioma.idioma;
            gd.DevolverTabla("Idioma").Rows.Add(dr);
            gd.ActualizarPorTabla("Idioma");
        }

        public void Eliminar(BEIdioma pIdioma)
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

        public void Modificar(BEIdioma pIdiomaModificar, BEIdioma pIdiomaModificado)
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

        public List<BEIdioma> ListaIdiomas()
        {
            List<BEIdioma> lista = new List<BEIdioma>();
            foreach (DataRowView row in gd.DevolverTabla("Idioma").DefaultView)
            {
                BEIdioma idioma = new BEIdioma(row[1].ToString());
                lista.Add(idioma);
            }
            return lista;
        }

        
    }
}
