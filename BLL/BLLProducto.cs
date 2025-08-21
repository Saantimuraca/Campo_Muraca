using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;
using Servicios.Datos;

namespace BLL
{
    public class BLLProducto
    {
        DALProducto dal = new DALProducto();
        public List<BEProducto> ListarProductos()
        {
            return dal.ListarProductos();
        }

        public void ModificarStock(int id, int cantidad)
        {
            dal.ModificarStock(id, cantidad);
            dal.AgregarDvh(dal.DevolverRow(id), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(dal.DevolverRow(id)));
            DatosDV.INSTANCIA.CalcularDvvTabla("Producto");
        }

        public void NotificarBajoStock(int id)
        {
            dal.CambiarEstadoStock(id, true);
            dal.AgregarDvh(dal.DevolverRow(id), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(dal.DevolverRow(id)));
            DatosDV.INSTANCIA.CalcularDvvTabla("Producto");
        }

        public List<BEProducto> ListarProductosIncremental(string consulta)
        {
            return dal.ListarProductosIncremental(consulta);
        }
    }
}
