using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Servicios.Datos;
using Servicios.Entidades;

namespace Servicios.Logica
{
    public class LogicaBitacora
    {
        DALBitacora dalBitacora = new DALBitacora();
        public void RegistrarBitacora(EntidadBitacora pBitacora)
        {
            dalBitacora.RegistrarBitacora(pBitacora);
        }

        public List<EntidadBitacora> ListaBitacora()
        {
            return dalBitacora.ListaBitacora();
        }

        public EntidadBitacora CrearBitacora(EntidadUsuario pUsuario, string pAccion)
        {
            EntidadBitacora nuevaBitacora = new EntidadBitacora(pUsuario, pAccion);
            return nuevaBitacora;
        }
    }
}
