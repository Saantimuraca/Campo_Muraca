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
    public class DALMovimientoCaja
    {
        public void Agregar(BEMovimientoCaja pMovimiento)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("MovimientoCaja").NewRow();
            dr["id"] = 0;
            dr["descripcion"] = pMovimiento.descripcion;
            dr["fecha"] = pMovimiento.fecha;
            dr["importe"] = pMovimiento.importe;
            dr["metodoPago"] = pMovimiento.metodoPago;
            dr["tipo"] = pMovimiento.tipo;
            Gestor_Datos.INSTANCIA.DevolverTabla("MovimientoCaja").Rows.Add(dr);
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("MovimientoCaja");
        }

        public void Modificar(BEMovimientoCaja pMovimiento)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("MovimientoCaja").Rows.Find(pMovimiento.id);
            dr["descripcion"] = pMovimiento.descripcion;
            dr["fecha"] = pMovimiento.fecha;
            dr["importe"] = pMovimiento.importe;
            dr["metodoPago"] = pMovimiento.metodoPago;
            dr["tipo"] = pMovimiento.tipo;
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("MovimientoCaja");
        }

        public List<BEMovimientoCaja> Movimientos()
        {
            List<BEMovimientoCaja> lista = new List<BEMovimientoCaja>();
            foreach(DataRowView row in Gestor_Datos.INSTANCIA.DevolverTabla("MovimientoCaja").DefaultView)
            {
                BEMovimientoCaja movimiento = new BEMovimientoCaja(row["descripcion"].ToString(), DateTime.Parse(row["fecha"].ToString()), decimal.Parse(row["importe"].ToString()),
                    row["metodoPago"].ToString(), bool.Parse(row["tipo"].ToString()), int.Parse(row["id"].ToString()));
                lista.Add(movimiento);
            }
            return lista;
        }
    }
}
