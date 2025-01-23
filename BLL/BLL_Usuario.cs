using BE;
using FluentValidation;
using Microsoft.VisualBasic;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Usuario
    {
        

        public void AgregarUsuario(BE_Usuario pUsuario)
        {

        }

        public void DeshabilitarUsuario(BE_Usuario pUsuario)
        {

        }

        public void HabilitarUsuario(BE_Usuario pUsuario)
        {

        }

        public void ModificarUsuario(BE_Usuario pUsuario)
        {

        }

        public BE_Usuario CrearUsuario(string pNombreUsuario, string pMailUsuario, string pFechaNacimiento, string pTelefonoUsuario)
        {
            BE_Usuario nuevo_usuario = new BE_Usuario(pNombreUsuario, pMailUsuario, DateTime.Parse(pFechaNacimiento), pTelefonoUsuario, true);
            var validador = new Validador_Usuario();
            var resultado = validador.Validate(nuevo_usuario);
            if (!resultado.IsValid)
            {
                StringBuilder mensajeErrores = new StringBuilder("Se encontraron los siguientes errores:\n");

                foreach (var error in resultado.Errors)
                {
                    mensajeErrores.AppendLine(error.ErrorMessage); // Agregar cada error al mensaje
                }
                // Lanzar una excepción con todos los errores concatenados
                throw new Exception(mensajeErrores.ToString());
            }
            return nuevo_usuario;
        }



        public List<BE_Usuario> ListaUsuarios()
        {
            return null;
        }

        public void Validar()
        {

        }
    }
}
