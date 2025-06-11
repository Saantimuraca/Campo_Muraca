using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace DAO
{
    public class DALProducto
    {
        public void Agregar(BEProducto pProducto)
        {

        }

        public void CambiarEstado(BEProducto pProducto)
        {

        }

        public void Modificar(BEProducto pProducto)
        {

        }

        public List<BEProducto> ListarProductos()
        {
            DALCategoria dAL = new DALCategoria();
            List<BEProducto> lista = new List<BEProducto>();
            foreach(DataRowView row in Gestor_Datos.INSTANCIA.DevolverTabla("Producto").DefaultView)
            {
                BECategoria categoria = dAL.ListaCategorias().Find(x => x.idCategoria == int.Parse(row[5].ToString()));
                BEProducto producto = new BEProducto(row[1].ToString(), row[2].ToString(), decimal.Parse(row[3].ToString()), int.Parse(row[4].ToString()), categoria, bool.Parse(row[6].ToString()), int.Parse(row[0].ToString()), bool.Parse(row[7].ToString()));
                lista.Add(producto);
            }
            return lista;
        }
    }
}
