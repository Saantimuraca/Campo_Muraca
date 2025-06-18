using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace Servicios.Entidades
{
    public class EntidadFactura
    {
        public int nroFactura {  get; set; }

        public string tipo { get; set; }

        public DateTime fecha { get; set; }

        public decimal subtotal { get; set; }

        public decimal total { get; set; }

        public string metodoPago { get; set; }


        public EntidadFactura(int nroFactura, string tipo, DateTime fecha, decimal subtotal, decimal total, string metodoPago)
        {
            this.nroFactura = nroFactura;
            this.tipo = tipo;
            this.fecha = fecha;
            this.subtotal = subtotal;
            this.total = total;
            this.metodoPago = metodoPago;
        }
    }
}
