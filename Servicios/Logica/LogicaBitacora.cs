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
        DatosBitacora dalBitacora = new DatosBitacora();
        public void RegistrarBitacora(EntidadBitacora pBitacora)
        {
            dalBitacora.RegistrarBitacora(pBitacora);
        }

        public List<EntidadBitacora> ListaBitacora()
        {
            return dalBitacora.ListaBitacora();
        }

        public EntidadBitacora CrearBitacora(EntidadUsuario pUsuario, string pAccion, int pCriticidad)
        {
            EntidadBitacora nuevaBitacora = new EntidadBitacora(pUsuario, pAccion, pCriticidad);
            return nuevaBitacora;
        }

        public List<EntidadBitacora> ListaBitacoraFecha(DateTime pDesde, DateTime pHasta)
        {
            return dalBitacora.ListaBitacora().Where(x => x.fechaHora >= pDesde).Where(x => x.fechaHora <= pHasta).ToList();
        }

        public List<EntidadBitacora> ListaBitacoraCriticidad(int pCriticidad)
        {
            return dalBitacora.ListaBitacora().Where(x => x.criticidad == pCriticidad).ToList();
        }
    }
}
