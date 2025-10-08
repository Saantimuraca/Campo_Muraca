using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BLL
{
    public class BLLSueldo
    {
        DALSueldo DALSueldo = new DALSueldo();

        public void Modificar(BE.BESueldo pSueldo)
        {
            DALSueldo.Modificar(pSueldo);
        }

        public BE.BESueldo ObtenerPorRol(string pRol)
        {
            return DALSueldo.ObtenerPorRol(pRol);
        }
    }
}
