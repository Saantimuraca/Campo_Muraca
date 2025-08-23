using Servicios.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAO;

namespace Servicios.Datos
{
    public class DatosIdioma : IIntegridadRepositorio
    {
        private static DatosIdioma instancia;
        public static DatosIdioma INSTANCIA
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new DatosIdioma();
                }
                return instancia;
            }
        }
        Gestor_Datos gd = Gestor_Datos.INSTANCIA;
        public void Agregar(EntidadIdioma pIdioma)
        {
            DataRow dr = gd.DevolverTabla("Idioma").NewRow();
            dr["idIdioma"] = pIdioma.idIdioma;
            dr["nombre"] = pIdioma.idioma;
            dr["isDisponible"] = pIdioma.isDisponible;
            gd.DevolverTabla("Idioma").Rows.Add(dr);
            gd.ActualizarPorTabla("Idioma");
        }

        public void AgregarDvh(DataRow dr, string pDvh)
        {
            dr["dvh"] = pDvh;
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("Idioma");
        }

        public DataRow DevolverRow(int pId)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Idioma").Rows.Find(pId);
            return dr;
        }

        public int DevolverUltimoId()
        {
            int maxId = 0;
            foreach (DataRow row in Gestor_Datos.INSTANCIA.DevolverTabla("Idioma").Rows)
            {
                int id = int.Parse(row["idIdioma"].ToString());
                if (id > maxId)
                    maxId = id;
            }
            return maxId;
        }

        public void ModificarDisponibilidad(EntidadIdioma pIdioma, bool pDisponibilidad)
        {
            DataRow dr = gd.DevolverTabla("Idioma").Rows.Find(pIdioma.idIdioma);
            dr["isDisponible"] = pDisponibilidad;
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
                EntidadIdioma idioma = new EntidadIdioma(row[1].ToString(), int.Parse(row[0].ToString()), bool.Parse(row[2].ToString()));
                lista.Add(idioma);
            }
            return lista;
        }

        public IEnumerable<DataRow> ObtenerEntidades()
        {
            return Gestor_Datos.INSTANCIA.DevolverTabla("Idioma").Rows.Cast<DataRow>().OrderBy(r => r.Field<int>("idIdioma"));
        }
    }
}
