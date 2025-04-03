using BE;
using ORM;
using Servicios;
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

        PermisoCompuesto PermisoCompuesto = new PermisoCompuesto();
        DALUsuario DALUsuario = new DALUsuario();

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
            return DALUsuario.ListaUsuarios().Find(x => x.Nombre_Usuario == usuarioSesion);
        }

        public bool SesionTienePermiso(string pPermiso)
        {
            return PermisoCompuesto.VerificarPermisoIncluido(PermisosSesion, pPermiso);
        }

        public void CerrarSesion()
        {
            usuarioSesion = null;
        }

        public void ConfigurarIdioma(string pNuevaConfiguracion)
        {
            Traductor traductor = Traductor.INSTANCIA;
            idiomaSesion = pNuevaConfiguracion;
            traductor.Notificar();
        }

        public string ObtenerIdiomaSesion()
        {
            return idiomaSesion;
        }
    }
}
