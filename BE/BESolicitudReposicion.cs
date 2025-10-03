using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BESolicitudReposicion
    {
        public int id {  get; set; }

        public BEProducto producto { get; set; }

        public DateTime fecha { get; set; }

        public string motivo { get; set; }

        public string estado { get; set; }

        public BEOrdenCompra ordenCompra { get; set; }

        public int cantidad { get; set; }

        public BESolicitudReposicion(BEProducto producto, DateTime fecha, string motivo, string estado, int cantidad = 0, int id = 0)
        {
            this.id = id;
            this.producto = producto;
            this.fecha = fecha;
            this.motivo = motivo;
            this.estado = estado;
            this.cantidad = cantidad;
        }
    }
}
