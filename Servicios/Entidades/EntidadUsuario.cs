using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Entidades
{
    public class EntidadUsuario
    {
        public string Dni_Usuario {  get; set; }

        public string Nombre_Usuario { get; set; }

        public string Mail_Usuario {  get; set; }

        public string Contraseña_Usuario { get; set; }

        public DateTime Fecha_Nacimiento_Usuario { get; set; }

        public int Edad_Usuario {  get; set; }

        public DateTime Fecha_Creacion_Usuario {  get; set; }

        public string Telefono_Usuario { get; set; }

        public bool Estado_Usuario { get; set; }

        public EntidadPermisoCompuesto Rol {  get; set; }

        public string Idioma {  get; set; }

        public int Intentos {  get; set; }


        public EntidadUsuario(string pDniUsuario, string pNombreUsuario, string pMailUsuario, string pContraseñaUsuario, DateTime pFechaNacimientoUsuario, DateTime pFechaCreacionUsuario, string pTelefonoUsuario, bool pEstadoUsuario, EntidadPermisoCompuesto rol, string idioma, int intentos)
        {
            Dni_Usuario = pDniUsuario;
            Nombre_Usuario = pNombreUsuario;
            Mail_Usuario = pMailUsuario;
            Contraseña_Usuario = pContraseñaUsuario;
            Fecha_Nacimiento_Usuario = pFechaNacimientoUsuario;
            Fecha_Creacion_Usuario = pFechaCreacionUsuario;
            Telefono_Usuario = pTelefonoUsuario;
            Estado_Usuario = pEstadoUsuario;
            Rol = rol;
            Idioma = idioma;
            Intentos = intentos;
        }


        public EntidadUsuario(string pDniUsuario, string pNombreUsuario, string pMailUsuario, string pContraseñaUsuario, DateTime pFechaNacimientoUsuario, int pEdadUsuario, DateTime pFechaCreacionUsuario, string pTelefonoUsuario, bool pEstadoUsuario, EntidadPermisoCompuesto rol, string idioma, int intentos)
        {
            Dni_Usuario = pDniUsuario;
            Nombre_Usuario = pNombreUsuario;
            Mail_Usuario = pMailUsuario;
            Contraseña_Usuario = pContraseñaUsuario;
            Fecha_Nacimiento_Usuario = pFechaNacimientoUsuario;
            Edad_Usuario = pEdadUsuario;
            Fecha_Creacion_Usuario = pFechaCreacionUsuario;
            Telefono_Usuario = pTelefonoUsuario;
            Estado_Usuario = pEstadoUsuario;
            Rol = rol;
            Idioma = idioma;
            Intentos = intentos;
        }
    }
}
