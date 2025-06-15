using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPedido
    {
        public int id { get; set; }

        public BECliente cliente { get; set; }

        public string estado {  get; set; }

        public DateTime fecha { get; set; }

        public decimal total { get; set; }

        public string dniVendedor { get; set; }

        public string Motivo { get; set; }

        public BEPedido(BECliente pCliente, string pEstado, DateTime pFecha, decimal pTotal, string pDniVendedor, int pId = 0)
        {
            cliente = pCliente;
            estado = pEstado;
            fecha = pFecha;
            total = pTotal;
            dniVendedor = pDniVendedor;
            id = pId;
        }
    }
}
