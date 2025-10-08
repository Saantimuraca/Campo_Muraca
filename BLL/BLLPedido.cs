using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;
using Servicios.Datos;

namespace BLL
{
    public class BLLPedido
    {
        DALPedido dalPedido = new DALPedido();
        BLLProducto bllProducto = new BLLProducto();
        public void Agregar(BEPedido pPedido, Dictionary<int, int> d)
        {
            dalPedido.Agregar(pPedido);
            /*dalPedido.AgregarDvhPedido(dalPedido.DevolverRowPedido(DevolverUltimoId()), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(dalPedido.DevolverRowPedido(DevolverUltimoId())));
            DatosDV.INSTANCIA.CalcularDvvTabla("Pedido");*/
            foreach (var par in d)
            {
                dalPedido.AgregarItemPedido(DevolverUltimoId(), par.Key, par.Value);
                /*dalPedido.AgregarDvhItemPedido(dalPedido.DevolverRowItemPedido(DevolverUltimoId(), par.Key), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(dalPedido.DevolverRowItemPedido(DevolverUltimoId(), par.Key)));
                DatosDV.INSTANCIA.CalcularDvvTabla("ItemPedido");*/
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
            /*dalPedido.AgregarDvhPedido(dalPedido.DevolverRowPedido(DevolverUltimoId()), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(dalPedido.DevolverRowPedido(DevolverUltimoId())));
            DatosDV.INSTANCIA.CalcularDvvTabla("Pedido");*/
            if (pEstado == "Rechazado")
            {
                foreach (var par in dalPedido.DetallePedido(pId))
                {
                    int cantidad = bllProducto.ListarProductos().Find(x => x.idProducto == par.Key).stock + par.Value;
                    bllProducto.ModificarStock(par.Key, cantidad);
                }
            }
        }

        public List<BEPedido> PedidosVendedor(int pMes, string pDniVendedor)
        {
            return ListarPedidos().Where(x => x.dniVendedor == pDniVendedor).Where(x => x.fecha.Month == pMes).ToList();
        }
    }
}
