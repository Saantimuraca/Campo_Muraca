using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Bitacora
    {
        DALBitacora dalBitacora = new DALBitacora();
        public void RegistrarBitacora(BEBitacora pBitacora)
        {
            dalBitacora.RegistrarBitacora(pBitacora);
        }

        public List<BEBitacora> ListaBitacora()
        {
            return dalBitacora.ListaBitacora();
        }

        public BEBitacora CrearBitacora(BE_Usuario pUsuario, string pAccion)
        {
            BEBitacora nuevaBitacora = new BEBitacora(pUsuario, pAccion);
            return nuevaBitacora;
        }
    }
}
