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

        public void ModificarStock(int id, int cantidad)
        {
            dal.ModificarStock(id, cantidad);
        }

        public void NotificarBajoStock(int id)
        {
            dal.CambiarEstadoStock(id, true);
        }
    }
}
