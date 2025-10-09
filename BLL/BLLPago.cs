using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;
using Servicios.Entidades;
using Servicios.Logica;

namespace BLL
{
    public class BLLPago
    {
        LogicaUsuario lu = new LogicaUsuario();
        BLLSueldo BLLSueldo = new BLLSueldo();
        BLLPedido BLLPedido = new BLLPedido();
        DALPago dalPago = new DALPago();
        public void SolicitarPago(BEPago pPago)
        {
            dalPago.SolicitarPago(pPago);
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach(EntidadUsuario usuario in lu.ListaUsuarios())
            {
                if(usuario.Rol.DevolverNombrePermiso() != "Administrador")
                {
                    BESueldo sueldo = BLLSueldo.ObtenerPorRol(usuario.Rol.DevolverNombrePermiso());
                    decimal totalEmpleado = sueldo.sueldo;
                    if (usuario.Rol.DevolverNombrePermiso() == "Vendedor")
                    {
                        foreach(BEPedido pedido in BLLPedido.PedidosVendedor(DateTime.Now.Month, usuario.Dni_Usuario))
                        {
                            totalEmpleado += (pedido.total * sueldo.comision) / 100;
                        }
                    }
                    total += totalEmpleado;
                }
            }
            return total;
        }

        public bool ExistePago(int pMes)
        {
            return dalPago.ExistePago(pMes);
        }

        public List<BEPago> ListarPagos()
        {
            return dalPago.ListarPagos();
        }

        public Dictionary<string, decimal> DetallePago(int pIdPago)
        {
            Dictionary<string, decimal> dic = new Dictionary<string, decimal>();
            BEPago pago = ListarPagos().Find(x => x.id == pIdPago);
            foreach(EntidadUsuario usuario in lu.ListaUsuarios())
            {
                if(usuario.Rol.DevolverNombrePermiso() != "Administrador")
                {
                    BESueldo sueldo = BLLSueldo.ObtenerPorRol(usuario.Rol.DevolverNombrePermiso());
                    decimal totalEmpleado = sueldo.sueldo;
                    if (usuario.Rol.DevolverNombrePermiso() == "Vendedor")
                    {
                        foreach (BEPedido pedido in BLLPedido.PedidosVendedor(pago.fecha.Month, usuario.Dni_Usuario))
                        {
                            totalEmpleado += (pedido.total * sueldo.comision) / 100;
                        }
                    }
                    dic.Add($"{usuario.Rol.DevolverNombrePermiso()}: {usuario.Nombre_Usuario}", totalEmpleado);
                }
            }
            return dic;
        }
    }
}
