using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BLL
{
    public class BLLSolicitudReposicion
    {
        DALSolicitudReposicion dalSolicitud = new DALSolicitudReposicion();
        public bool ExisteSolicitud(int pIdProducto)
        {
            int cont = Solicitudes().Where(x => x.producto.idProducto == pIdProducto).Where(x => x.estado == "En revisión" || x.estado == "Pendiente").Count();
            if(cont > 0) { return true; }
            else { return false; }
        }

        public List<BESolicitudReposicion> Solicitudes()
        {
            return dalSolicitud.Solicitudes();
        }

        public void Agregar(BESolicitudReposicion pSolicitud)
        {
            dalSolicitud.AgregarSolicitud(pSolicitud);
        }

        public List<BESolicitudReposicion> SolicitudesEstado(string pEstado)
        {
            if(pEstado == "Todas") { return dalSolicitud.Solicitudes(); }
            return Solicitudes().Where(x => x.estado == pEstado).ToList();
        }

        public void Cancelar(int pIdSolicitud, string pMotivo)
        {
            dalSolicitud.CancelarSolicitud(pIdSolicitud, pMotivo);
        }

        public void Aprobar(int pIdSolicitud, int pCantidad)
        {
            dalSolicitud.AprobarSolicitud(pIdSolicitud, pCantidad);
        }

        public void AsignarOrdenCompra(int pIdSolicitud, int pIdOrdenCompra)
        {
            dalSolicitud.AsignarOrdenCompra(pIdSolicitud, pIdOrdenCompra);
        }

        public void MarcarComoRealizada(int pIdSolicitud)
        {
            dalSolicitud.MarcarComoRealizada(pIdSolicitud);
        }
    }
}
