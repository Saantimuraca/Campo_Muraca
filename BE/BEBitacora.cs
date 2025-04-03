using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEBitacora
    {
        public int idBitacora {  get; set; }

        public DateTime fechaHora { get; set; }

        public BE_Usuario usuario { get; set; }

        public string accion {  get; set; }

        public BEBitacora(BE_Usuario pUsuario, string pAccion)
        {
            idBitacora = 0;
            fechaHora = DateTime.Now;
            usuario = pUsuario;
            accion = pAccion;
        }

        public BEBitacora(int pIdBitacora, DateTime pFechaHora, BE_Usuario pUsuario, string pAccion)
        {
            idBitacora = pIdBitacora;
            fechaHora = pFechaHora;
            usuario = pUsuario;
            accion = pAccion;
        }
    }
}
