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
        private string usuarioSesion = "";
        private string idiomaSesion = "Español";
        private string rolsesion = "";
        private BEPermisoCompuesto PermisosSesion;

        BLLPermisoCompuesto bllPermisoCompuesto = new BLLPermisoCompuesto();


        public void AgregarPermisoCompuesto(string pNombre, List<string> pListaPermisos, bool pIsRol)
        {

        }

        public void IniciarSesion(BE_Usuario usuario)
        {
            usuarioSesion = usuario.Nombre_Usuario;
            idiomaSesion = usuario.Idioma;
            rolsesion = usuario.Rol.DevolverNombrePermiso();
            GestorPermisos gp = new GestorPermisos();
            PermisosSesion = (BEPermisoCompuesto)gp.ObtenerPermisos("Roles").Find(x => x.DevolverNombrePermiso() == rolsesion);
        }

        public BE_Usuario ObtenerUsuarioActual()
        {
            BLL_Usuario bllUsuario = new BLL_Usuario();
            return bllUsuario.ListaUsuarios().Find(x => x.Nombre_Usuario == usuarioSesion);
        }

        public bool SesionTienePermiso(string pPermiso)
        {
            return bllPermisoCompuesto.VerificarPermisoIncluido(PermisosSesion, pPermiso);
        }
    }
}
