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
        Encriptador encriptador = new Encriptador();
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

        public BE_Usuario CrearUsuario(string pDniUsuario, string pNombreUsuario, string pMailUsuario, string pFechaNacimiento, string pTelefonoUsuario)
        {
            BE_Usuario nuevo_usuario = new BE_Usuario(pDniUsuario, pNombreUsuario, pMailUsuario.ToLower(), encriptador.GenerarHash($"{pDniUsuario}{pNombreUsuario.ToUpper()}S"), DateTime.Parse(pFechaNacimiento).Date, CalcularEdadUsuario(DateTime.Parse(pFechaNacimiento)), DateTime.Now, pTelefonoUsuario, true);
            var validador = new Validador_Usuario(ListaNombresUsuarios(), ListaDNIs());
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

        public List<string> ListaDNIs()
        {
            List<string> lista = new List<string>();   
            foreach(BE_Usuario usuario in ListaUsuarios())
            {
                lista.Add(usuario.Dni_Usuario);
            }
            return lista;
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
