using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Entidades
{
    public class EntidadHistoriaUsuario
    {
        public int id {  get; set; }

        public string Dni_Usuario { get; set; }

        public string Nombre_Usuario { get; set; }

        public string Mail_Usuario { get; set; }

        public string Contraseña_Usuario { get; set; }

        public DateTime Fecha_Nacimiento_Usuario { get; set; }

        public DateTime Fecha_Creacion_Usuario { get; set; }

        public string Telefono_Usuario { get; set; }

        public bool Estado_Usuario { get; set; }

        public EntidadPermisoCompuesto Rol { get; set; }

        public string Idioma { get; set; }

        public DateTime fechaModificacion { get; set; }

        public EntidadHistoriaUsuario(int pid, string pDni, string pNombre, string  pMail, string pContraseña, DateTime pFechaNacimiento, DateTime pFechaCreacion, string pTelefono, bool pEstado, EntidadPermisoCompuesto pRol, string pIdioma, DateTime pFechaModificacion)
        {
            id = pid;
            Dni_Usuario = pDni;
            Nombre_Usuario = pNombre;
            Mail_Usuario = pMail;
            Contraseña_Usuario = pContraseña;
            Fecha_Nacimiento_Usuario = pFechaNacimiento;
            Fecha_Creacion_Usuario = pFechaCreacion;
            Telefono_Usuario = pTelefono;
            Estado_Usuario = pEstado;
            Rol = pRol;
            Idioma = pIdioma;
            fechaModificacion = pFechaModificacion;
        }
    }
}
