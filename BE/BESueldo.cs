using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BESueldo
    {
        public string rol { get; set; }

        public decimal sueldo { get; set; }

        public int comision { get; set; }

        public DateTime fechaModificacion { get; set; }

        public BESueldo(string rol, decimal sueldo, int comision, DateTime fechaModificacion)
        {
            this.rol = rol;
            this.sueldo = sueldo;
            this.comision = comision;
            this.fechaModificacion = fechaModificacion;
        }
    }
}
