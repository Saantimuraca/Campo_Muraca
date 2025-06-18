using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BLL
{
    public class BLLPedido
    {
        DALPedido dalPedido = new DALPedido();
        BLLProducto bllProducto = new BLLProducto();
        public void Agregar(BEPedido pPedido, Dictionary<int, int> d)
        {
            dalPedido.Agregar(pPedido);
            foreach(var par in d)
            {
                dalPedido.AgregarItemPedido(DevolverUltimoId(), par.Key, par.Value);
                int stock = bllProducto.ListarProductos().Find(x => x.idProducto == par.Key).stock;
                int cantidad = stock - par.Value;
                if(cantidad < 0) { cantidad = 0; }
                bllProducto.ModificarStock(par.Key, cantidad);
            }
        }

        public List<BEPedido> ListarPedidos()
        {
            return dalPedido.ListarPedido();
        }

        public int DevolverUltimoId()
        {
            return dalPedido.ListarPedido().Last().id;
        }

        public void CambiarEstado(string pEstado, int pId, string pMotivo = "")
        {
            dalPedido.CambiarEstado(pEstado, pId, pMotivo);
            if(pEstado == "Rechazado")
            {
                foreach (var par in dalPedido.DetallePedido(pId))
                {
                    int cantidad = bllProducto.ListarProductos().Find(x => x.idProducto == par.Key).stock + par.Value;
                    bllProducto.ModificarStock(par.Key, cantidad);
                }
            }
        }
    }
}
