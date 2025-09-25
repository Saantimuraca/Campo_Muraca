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
    }
}
