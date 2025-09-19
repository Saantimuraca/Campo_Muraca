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
        public void CrearOrden(BEOrdenCompra pOrdenCompra)
        {
            dal.CrearOrden(pOrdenCompra);
        }

        public int DevolverUltimoId()
        {
            return dal.DevolverUltimoId();  
        }
    }
}
