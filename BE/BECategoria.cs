using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECategoria
    {
        public int idCategoria {  get; set; }

        public string nombre { get; set; }

        public BECategoria(string pNombre, int pIdCategoria = 0)
        {
            idCategoria = pIdCategoria;
            nombre = pNombre;
        }
    }
}
