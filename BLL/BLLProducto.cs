using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public void Agregar(BEProducto pProducto)
        {
            dal.Agregar(pProducto);
            dal.AgregarDvh(dal.DevolverRow(dal.DevolverUltimoId()), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(dal.DevolverRow(dal.DevolverUltimoId())));
            DatosDV.INSTANCIA.CalcularDvvTabla("Producto");
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

        public void CambiarEstado(int pId)
        {
            dal.CambiarEstado(pId);
            dal.AgregarDvh(dal.DevolverRow(pId), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(dal.DevolverRow(pId)));
            DatosDV.INSTANCIA.CalcularDvvTabla("Producto");
        }

        public void Modificar(BEProducto pProducto)
        {
            dal.Modificar(pProducto);
            dal.AgregarDvh(dal.DevolverRow(pProducto.idProducto), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(dal.DevolverRow(pProducto.idProducto)));
            DatosDV.INSTANCIA.CalcularDvvTabla("Producto");
        }
    }
}
