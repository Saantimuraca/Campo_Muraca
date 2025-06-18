using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Servicios.Entidades;

namespace Servicios.Datos
{
    public class DatosFactura
    {
        public int UltimoNroFactura()
        {
            if (Gestor_Datos.INSTANCIA.DevolverTabla("Factura").Rows.Count == 0) return 0;
            DataRow ultimaFila = Gestor_Datos.INSTANCIA.DevolverTabla("Factura").Rows[Gestor_Datos.INSTANCIA.DevolverTabla("Factura").Rows.Count - 1];
            int ultimoNro = int.Parse(ultimaFila[0].ToString());
            return ultimoNro;
        }

        public void GuardarFactura(EntidadFactura pFactura)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("Factura").NewRow();
            dr["nroFactura"] = pFactura.nroFactura;
            dr["tipo"] = pFactura.tipo;
            dr["fechaGeneracion"] = pFactura.fecha;
            dr["subtotal"] = pFactura.subtotal;
            dr["total"] = pFactura.total;
            dr["metodoPago"] = pFactura.metodoPago;
            Gestor_Datos.INSTANCIA.DevolverTabla("Factura").Rows.Add(dr);
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("Factura");
        }
    }
}
