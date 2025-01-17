﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Usuario
    {
        public int Id_Usuario {  get; set; }

        public string Nombre_Usuario { get; set; }

        public string Mail_Usuario {  get; set; }

        public DateTime Fecha_Nacimiento_Usuario { get; set; }

        public int Edad_Usuario {  get; set; }

        public DateTime Fecha_Creacion_Usuario {  get; set; }

        public string Telefono_Usuario { get; set; }

        public bool Estado_Usuario { get; set; }

        public BE_Usuario(string pNombreUsuario, string pMailUsuario, DateTime pFechaNacimientoUsuario, int pEdadUsuario, string pTelefonoUsuario, bool pEstadoUsuario)
        {
            Nombre_Usuario = pNombreUsuario;
            Mail_Usuario = pMailUsuario;
            Fecha_Nacimiento_Usuario = pFechaNacimientoUsuario;
            Edad_Usuario = pEdadUsuario;
            Fecha_Creacion_Usuario = DateTime.Now;
            Telefono_Usuario = pTelefonoUsuario;
            Estado_Usuario = pEstadoUsuario;
        }
    }
}
