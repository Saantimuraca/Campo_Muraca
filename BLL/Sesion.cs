using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Sesion
    {
        private static Sesion instancia;
        public static Sesion INSTANCIA
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Sesion();
                }
                return instancia;
            }
        }
        private string sessionUser = "";
        private BEPermisoCompuesto PermisosSesion;

        BLLPermisoCompuesto bllPermisoCompuesto = new BLLPermisoCompuesto();


        public void AgregarPermisoCompuesto(string pNombre, List<string> pListaPermisos, bool pIsRol)
        {

        }

        public bool SesionTienePermiso(string pPermiso)
        {
            return bllPermisoCompuesto.VerificarPermisoIncluido(PermisosSesion, pPermiso);
        }
    }
}
