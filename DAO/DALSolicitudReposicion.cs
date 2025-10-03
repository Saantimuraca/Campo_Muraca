using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace DAO
{
    public class DALSolicitudReposicion
    {
        DALProducto dalProducto = new DALProducto();
        DALOrdenCompra dalOrden = new DALOrdenCompra();
        public List<BESolicitudReposicion> Solicitudes()
        {
            List<BESolicitudReposicion> lista = new List<BESolicitudReposicion>();
            foreach(DataRowView row in Gestor_Datos.INSTANCIA.DevolverTabla("SolicitudReposicion").DefaultView)
            {
                BEProducto producto = dalProducto.ListarProductos().Find(x => x.idProducto == int.Parse(row["idProducto"].ToString()));
                BESolicitudReposicion solicitudReposicion = new BESolicitudReposicion(producto, DateTime.Parse(row["fecha"].ToString()), row["motivo"].ToString(), row["estado"].ToString(), int.Parse(row["cantidad"].ToString()),int.Parse(row["id"].ToString()));
                if(row["idOrdenCompra"] != DBNull.Value)
                {
                    solicitudReposicion.ordenCompra = dalOrden.Ordenes().Find(x => x.id == int.Parse(row["idOrdenCompra"].ToString()));
                }
                lista.Add(solicitudReposicion);
            }
            return lista;
        }

        public void AgregarSolicitud(BESolicitudReposicion pSolicitud)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("SolicitudReposicion").NewRow();
            dr["id"] = 0;
            dr["idProducto"] = pSolicitud.producto.idProducto;
            dr["fecha"] = pSolicitud.fecha;
            dr["motivo"] = pSolicitud.motivo;
            dr["estado"] = pSolicitud.estado;
            Gestor_Datos.INSTANCIA.DevolverTabla("SolicitudReposicion").Rows.Add(dr);
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("SolicitudReposicion");
        }

        public void CancelarSolicitud(int pIdSolicitud, string motivo)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("SolicitudReposicion").Rows.Find(pIdSolicitud);
            dr["motivo"] = motivo;
            dr["estado"] = "Rechazada";
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("SolicitudReposicion");
        }

        public void AprobarSolicitud(int pIdSolicitud, int pCantidad)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("SolicitudReposicion").Rows.Find(pIdSolicitud);
            dr["estado"] = "Aprobada";
            dr["cantidad"] = pCantidad;
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("SolicitudReposicion");
        }

        public void AsignarOrdenCompra(int pIdSolicitud, int pIdOrden)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("SolicitudReposicion").Rows.Find(pIdSolicitud);
            dr["idOrdenCompra"] = pIdOrden;
            dr["estado"] = "Pendiente";
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("SolicitudReposicion");
        }

        public void MarcarComoRealizada(int pIdSolicitud)
        {
            DataRow dr = Gestor_Datos.INSTANCIA.DevolverTabla("SolicitudReposicion").Rows.Find(pIdSolicitud);
            dr["estado"] = "Realizada";
            Gestor_Datos.INSTANCIA.ActualizarPorTabla("SolicitudReposicion");
        }
    }
}
