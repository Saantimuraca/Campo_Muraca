using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Threading.Tasks;
using BE;
using DAO;

namespace BLL
{
    public class BLLProducto
    {
        DALProducto dal = new DALProducto();
        List<BEProducto> clonada;
        public List<BEProducto> ListarProductos()
        {
            return dal.ListarProductos();
        }

        public List<BEProducto> ListaClonada()
        {
            if(clonada == null)
            {
                clonada = ListarProductos().Select(p => new BEProducto
                {
                    nombre = p.nombre,
                    precio = p.precio,
                    descripcion = p.descripcion,
                    stock = p.stock,
                    categoria = p.categoria,
                    estado = p.estado,
                    idProducto = p.idProducto
                }).ToList();
            }
            return clonada;
        }
    }
}
