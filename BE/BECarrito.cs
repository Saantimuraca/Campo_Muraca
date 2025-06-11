using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECarrito
    {
        private static BECarrito instancia;
        private static readonly object _lock = new object();
        public static BECarrito INSTANCIA
        {
            get
            {
                lock (_lock)
                {
                    if (instancia == null)
                    {
                        instancia = new BECarrito();
                    }
                }
                return instancia;
            }
        }
        public Dictionary<int, int> d = new Dictionary<int, int>();

        public decimal total {  get; set; }

        public void BorrarCarrito()
        {
            instancia = null;
        }

    }
}
