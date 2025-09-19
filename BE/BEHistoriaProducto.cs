using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEHistoriaProducto
    {
        public int id {  get; set; }

        public int idProducto { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public decimal precio { get; set; }

        public int stock { get; set; }

        public BECategoria categoria { get; set; }

        public bool estado { get; set; }

        public bool isBajoStock { get; set; }


        public DateTime fechaModificacion { get; set; }

        public BEHistoriaProducto(int pId, int pIdProducto, string pNombre, string pDescripcion, decimal pPrecio, int pStock, BECategoria pCategoria, bool pEstado, bool pIsBajoStock, DateTime pFechaModificacion)
        {
            id = pId;
            idProducto = pIdProducto;
            nombre = pNombre;
            descripcion = pDescripcion;
            precio = pPrecio;
            stock = pStock;
            categoria = pCategoria;
            estado = pEstado;
            isBajoStock = pIsBajoStock;
            fechaModificacion = pFechaModificacion;
        }
    }
}
