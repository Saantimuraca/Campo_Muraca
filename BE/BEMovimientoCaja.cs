using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEMovimientoCaja
    {
        public int id {  get; set; }

        public string descripcion {  get; set; }

        public DateTime fecha { get; set; }

        public decimal importe { get; set; }

        public string metodoPago { get; set; }

        public bool tipo {  get; set; }

        public BEMovimientoCaja(string descripcion, DateTime fecha, decimal importe, string metodoPago, bool tipo, int id = 0)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.fecha = fecha;
            this.importe = importe;
            this.metodoPago = metodoPago;
            this.tipo = tipo;
        }
    }
}
