using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Entidades
{
    public class EntidadBitacora
    {
        public int idBitacora {  get; set; }

        public DateTime fechaHora { get; set; }

        public EntidadUsuario usuario { get; set; }

        public string accion {  get; set; }

        public EntidadBitacora(EntidadUsuario pUsuario, string pAccion)
        {
            idBitacora = 0;
            fechaHora = DateTime.Now;
            usuario = pUsuario;
            accion = pAccion;
        }

        public EntidadBitacora(int pIdBitacora, DateTime pFechaHora, EntidadUsuario pUsuario, string pAccion)
        {
            idBitacora = pIdBitacora;
            fechaHora = pFechaHora;
            usuario = pUsuario;
            accion = pAccion;
        }
    }
}
