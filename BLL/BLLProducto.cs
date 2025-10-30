using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
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
            if(cantidad == 0) { NotificarBajoStock(id); }

            dal.AgregarDvh(dal.DevolverRow(id), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(dal.DevolverRow(id)));
            DatosDV.INSTANCIA.CalcularDvvTabla("Producto");
        }

        public void CambiarEstadoStock(int id, bool estado)
        {
            dal.CambiarEstadoStock(id, estado);
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

        public void AgregarHistoria(BEProducto pProducto)
        {
            dal.AgregarHistoria(pProducto);
            /*dal.AgregarDvhHistoria(dal.DevolverRowHistoria(dal.DevolverUltimoIdHistoria()), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(dal.DevolverRowHistoria(dal.DevolverUltimoIdHistoria())));
            DatosDV.INSTANCIA.CalcularDvvTabla("HistoriaProducto");*/
        }

        public List<BEHistoriaProducto> ListaHistorias()
        {
            return dal.ListaHistorias();
        }

        public bool RollBack(BEProducto pProducto)
        {
            try
            {
                dal.RollBack(pProducto);
                dal.AgregarDvh(dal.DevolverRow(pProducto.idProducto), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(dal.DevolverRow(pProducto.idProducto)));
                DatosDV.INSTANCIA.CalcularDvvTabla("Producto");
                return true;
            }
            catch { return false; }
        }

        public List<BEProducto> ListaProductosAprobados()
        {
            return dal.ListaProductosAprobados();
        }
    }
}
