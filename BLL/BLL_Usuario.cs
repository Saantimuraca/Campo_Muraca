using BE;
using FluentValidation;
using Microsoft.VisualBasic;
using ORM;
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
        
        ORM_Usuario ormUsuario = new ORM_Usuario();
        public void AgregarUsuario(BE_Usuario pUsuario)
        {
            ormUsuario.AgregarUsuario(pUsuario);
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

        public BE_Usuario CrearUsuario(string pNombreUsuario, string pMailUsuario, string pContraseñaUsuario, string pFechaNacimiento, string pTelefonoUsuario)
        {
            BE_Usuario nuevo_usuario = new BE_Usuario(pNombreUsuario, pMailUsuario, pContraseñaUsuario, DateTime.Parse(pFechaNacimiento), CalcularEdadUsuario(DateTime.Parse(pFechaNacimiento)), pTelefonoUsuario, true);
            var validador = new Validador_Usuario(ListaNombresUsuarios());
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

        public int CalcularEdadUsuario(DateTime pFechaNacimientoUsuario)
        {
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - pFechaNacimientoUsuario.Year;

            // Ajustar la edad si la persona no ha cumplido años este año
            if (fechaActual < pFechaNacimientoUsuario.AddYears(edad))
            {
                edad--;
            }

            return edad;
        }

        public List<string> ListaNombresUsuarios()
        {
            List<string> lista = new List<string>();
            foreach(BE_Usuario usuario in ListaUsuarios())
            {
                lista.Add(usuario.Nombre_Usuario);
            }
            return lista;
        }

        public List<BE_Usuario> ListaUsuarios()
        {
            return ormUsuario.ListaUsuarios();
        }
    }
}
