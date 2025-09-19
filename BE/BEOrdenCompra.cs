using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEOrdenCompra
    {
        public int id {  get; set; }

        public string estado { get; set; }  

        public DateTime fecha { get; set; }

        public BEOrdenCompra(string estado, DateTime fecha, int id = 0)
        {
            this.id = id;
            this.estado = estado;
            this.fecha = fecha;
        }
    }
}
