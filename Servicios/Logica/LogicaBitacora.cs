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
            /*dalBitacora.AgregarDvh(dalBitacora.DevolverRow(dalBitacora.DevolverUltimoId()), DatosDV.INSTANCIA.CalcularDVHRegistroBase64(dalBitacora.DevolverRow(dalBitacora.DevolverUltimoId())));
            DatosDV.INSTANCIA.CalcularDvvTabla("Bitacora");*/
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
            DateTime hasta = pHasta.Date.AddDays(1).AddSeconds(-1);
            DateTime desde = pDesde.Date;

            return dalBitacora.ListaBitacora()
                .Where(x => x.fechaHora >= desde && x.fechaHora <= hasta)
                .ToList();
        }

        public List<EntidadBitacora> ListaBitacoraCriticidad(int pCriticidad)
        {
            return dalBitacora.ListaBitacora().Where(x => x.criticidad == pCriticidad).ToList();
        }
    }
}
