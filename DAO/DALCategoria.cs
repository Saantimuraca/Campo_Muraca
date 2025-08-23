using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using DAO;

namespace DAL
{
    public class DALCategoria : IIntegridadRepositorio
    {
        private static DALCategoria instancia;
        public static DALCategoria INSTANCIA
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new DALCategoria();
                }
                return instancia;
            }
        }

        public List<BECategoria> ListaCategorias()
        {
            List<BECategoria> lista = new List<BECategoria>();
            foreach(DataRowView row in Gestor_Datos.INSTANCIA.DevolverTabla("CategoriaProductos").DefaultView)
            {
                BECategoria categoria = new BECategoria(row[1].ToString(), int.Parse(row[0].ToString()));
                lista.Add(categoria);
            }
            return lista;
        }

        public IEnumerable<DataRow> ObtenerEntidades()
        {
            return Gestor_Datos.INSTANCIA.DevolverTabla("CategoriaProductos").Rows.Cast<DataRow>().OrderBy(r => r.Field<int>("idCategoria"));
        }
    }
}
