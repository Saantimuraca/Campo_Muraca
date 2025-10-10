using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAO
{
    public class DALPago
    {
        public void SolicitarPago(BE.BEPago pPago)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Pago").NewRow();
            dr["id"] = 0;
            dr["estado"] = pPago.estado;
            dr["monto"] = pPago.monto;
            dr["fecha"] = pPago.fecha;
            Gestor_Datos.INSTANCIA.DevolverTabla("Pago").Rows.Add(dr);
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("Pago");
        }   

        public bool ExistePago(int pMes)
        {
            foreach(DataRowView row in Gestor_Datos.INSTANCIA.DevolverTabla("Pago").DefaultView)
            {
                if(Convert.ToDateTime(row["fecha"]).Month == pMes && row["estado"].ToString() != "Rechazado")
                {
                    return true;
                }   
            }
            return false;
        }

        public List<BE.BEPago> ListarPagos()
        {
            List<BE.BEPago> pagos = new List<BE.BEPago>();
            foreach (DataRowView row in Gestor_Datos.INSTANCIA.DevolverTabla("Pago").DefaultView)
            {
                BE.BEPago pago = new BE.BEPago(row["estado"].ToString(), Convert.ToDateTime(row["fecha"]), Convert.ToDecimal(row["monto"]), Convert.ToInt32(row["id"]));
                if(row["fechaPago"] != DBNull.Value) { pago.fechaPago = Convert.ToDateTime(row["fechaPago"]); }
                if (row["metodoPago"] != DBNull.Value) { pago.metodoPago = row["metodoPago"].ToString(); }
                pagos.Add(pago);
            }
            return pagos;
        }

        public void CambiarEstado(string pEstado, int pIdPago)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Pago").Select($"id = {pIdPago}")[0];
            dr["estado"] = pEstado;
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("Pago");
        }
    }
}
