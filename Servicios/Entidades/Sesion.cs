using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.Entidades;
using Servicios.Datos;
using Servicios.Logica;

namespace Servicios
{
    public class Sesion
    {
        private static Sesion instancia;
        private static readonly object _lock = new object();
        public static Sesion INSTANCIA
        {
            get
            {
                if (instancia == null)
                {
                    lock (_lock)
                    {
                        if(instancia == null)
                        {
                            instancia = new Sesion();
                        }
                    }
                }
                return instancia;
            }
        }
        private string usuarioSesion = "";
        private string idiomaSesion = "Español";
        private string rolsesion = "";
        private EntidadPermisoCompuesto PermisosSesion;

        LogicaPermisoCompuesto PermisoCompuesto = new LogicaPermisoCompuesto();
        DatosUsuario DALUsuario = new DatosUsuario();

        public void IniciarSesion(EntidadUsuario usuario)
        {
            usuarioSesion = usuario.Nombre_Usuario;
            idiomaSesion = usuario.Idioma;
            rolsesion = usuario.Rol.DevolverNombrePermiso();
            GestorPermisos gp = new GestorPermisos();
            PermisosSesion = (EntidadPermisoCompuesto)gp.ObtenerPermisos("Roles").Find(x => x.DevolverNombrePermiso() == rolsesion);
        }

        public EntidadUsuario ObtenerUsuarioActual()
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
