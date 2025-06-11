using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DALCategoria
    {
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
    }
}
