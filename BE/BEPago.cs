using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPago
    {
        public int id { get; set; }

        public string estado { get; set; }

        public DateTime fechaPago { get; set; }

        public DateTime fecha { get; set; }

        public string metodoPago { get; set; }

        public decimal monto { get; set; }

        public BEPago(string pEstado, DateTime pFecha, decimal pMonto, int pId = 0)
        {
            this.estado = pEstado;
            this.fecha = pFecha;
            this.monto = pMonto;
            this.id = pId;
        }
    }
}
