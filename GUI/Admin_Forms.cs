using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class Admin_Forms
    {
        private Estado Gestor_Estados = new EstadoIniciarSesion();
        private static Admin_Forms instancia;
        public static Admin_Forms INSTANCIA
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new Admin_Forms();
                }
                return instancia;
            }
        }

        public void Definir_Estado(Estado estado)
        {
            Gestor_Estados?.Cerrar_Estado();
            Gestor_Estados = estado;
            Gestor_Estados.Ejecutar_Estado();
        }
    }
}
