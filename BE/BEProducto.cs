using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEProducto
    {
        public int idProducto {  get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public decimal precio { get; set; }

        public int stock { get; set; }

        public BECategoria categoria { get; set; }

        public bool estado { get; set; }

        public bool isBajoStock { get; set; }

        public bool resposicionAprobada { get; set; }

        public BEProducto(string pNombre, string pDescripcion, decimal pPrecio, int pStock, BECategoria pCategoria, bool pestado, bool pResposicionAprobada, int pIdProducto = 0, bool pisBajoStock = false)
        {
            idProducto = pIdProducto;
            nombre = pNombre;
            descripcion = pDescripcion;
            precio = pPrecio;
            stock = pStock;
            categoria = pCategoria;
            estado = pestado;
            isBajoStock = pisBajoStock;
            resposicionAprobada = pResposicionAprobada;
        }

        public BEProducto() { }
    }
}
