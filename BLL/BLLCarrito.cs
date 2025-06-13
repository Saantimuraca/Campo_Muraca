using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;

namespace BLL
{
    public class BLLCarrito
    {
        public bool ProductoAgregado(int id)
        {
            return BECarrito.INSTANCIA.d.ContainsKey(id);
        }

        public void AgregarProductoCarrito(int id, int cantidad)
        {
            BECarrito.INSTANCIA.d.Add(id, cantidad);
        }

        public void EliminarProductoCarrito(int id)
        {
            BECarrito.INSTANCIA.d.Remove(id);
        }

        public void ModificarCantidadProducto(int id, int cantidad)
        {
            BECarrito.INSTANCIA.d[id] = cantidad;
        }

        public void VaciarCarrito()
        {
           BECarrito.INSTANCIA.d.Clear();
        }
    }
}
