using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BLL
{
    public class BLLOrdenCompra
    {
        DALOrdenCompra dal = new DALOrdenCompra();
        BLLSolicitudReposicion bllSolicitud = new BLLSolicitudReposicion();
        public void CrearOrden(BEOrdenCompra pOrdenCompra)
        {
            dal.CrearOrden(pOrdenCompra);
        }

        public int DevolverUltimoId()
        {
            return dal.DevolverUltimoId();  
        }

        public List<BEOrdenCompra> Ordenes()
        {
            return dal.Ordenes();
        }

        public void Finalizar(int pidOrden)
        {
            dal.Finalizar(pidOrden);
            foreach (BESolicitudReposicion sol in bllSolicitud.Solicitudes().Where(x => x.ordenCompra != null && x.ordenCompra.id == pidOrden))
            {
                bllSolicitud.MarcarComoRealizada(sol.id);
            }
        }
    }
}
