using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;
using Org.BouncyCastle.Asn1.Mozilla;

namespace BLL
{
    public class BLLMovimientoCaja
    {
        DALMovimientoCaja dalMovimiento = new DALMovimientoCaja();
        BLLPago bllPago = new BLLPago();

        public void Agregar(BEMovimientoCaja pMovimiento)
        {
            dalMovimiento.Agregar(pMovimiento);
        }

        public List<BEMovimientoCaja> Movimientos()
        {
            return dalMovimiento.Movimientos();
        }

        public decimal CalcularTotalCaja()
        {
            decimal egresos = 0;
            decimal ingresos = 0;
            foreach(BEMovimientoCaja movimiento in Movimientos())
            {
                if(!movimiento.tipo)
                {
                    egresos = egresos + movimiento.importe;
                }
                else
                {
                    ingresos = ingresos + movimiento.importe;
                }
            }
            decimal total = ingresos - egresos;
            return total;
        }

        public void Modificar(BEMovimientoCaja pMovimiento)
        {
            dalMovimiento.Modificar(pMovimiento);
        }

        public Dictionary<string, decimal> Balance()
        {
            Dictionary<string, decimal> balance = new Dictionary<string, decimal>();
            balance.Add("Sueldos", bllPago.DevolverMontoPagosMes());
            decimal totalGastosOtro = 0;
            foreach(BEMovimientoCaja movimiento in Movimientos().FindAll(x => !x.tipo))
            {
                if (movimiento.descripcion != "Pago de sueldos" && movimiento.fecha.Month == bllPago.ObtenerPagoMasReciente().fecha.Month && movimiento.fecha.Year == bllPago.ObtenerPagoMasReciente().fecha.Year)
                {
                    totalGastosOtro = totalGastosOtro + movimiento.importe;
                }
            }
            balance.Add("Otros Gastos", totalGastosOtro);
            decimal totalIngresos = 0;
            foreach (BEMovimientoCaja movimiento in Movimientos().FindAll(x => x.tipo))
            {
                if (movimiento.fecha.Month == bllPago.ObtenerPagoMasReciente().fecha.Month && movimiento.fecha.Year == bllPago.ObtenerPagoMasReciente().fecha.Year)
                {
                    totalIngresos = totalIngresos + movimiento.importe;
                }
            }
            balance.Add("Ingresos", totalIngresos);
            return balance; 
        }
    }
}
