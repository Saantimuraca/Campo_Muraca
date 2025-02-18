using BE;
using FluentValidation;
using Microsoft.VisualBasic;
using ORM;
using Servicios;
using System;
using System.CodeDom;
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
        GestorPermisos gp = new GestorPermisos();
        public void AgregarUsuario(BE_Usuario pUsuario)
        {
            ormUsuario.AgregarUsuario(pUsuario);
        }

        public bool Login(string pNombreUsuario, string pContraseñaIngresada)
        {
            BE_Usuario usuario = ListaUsuarios().Find(x => x.Nombre_Usuario == pNombreUsuario);
            if(VerificarContraseña(pContraseñaIngresada, usuario.Contraseña_Usuario))
            {
                Sesion sesion = Sesion.INSTANCIA;
                if (!usuario.Estado_Usuario) throw new Exception("Su usuario se encuentra bloqueado, contactese con el administrador para que lo desbloquee!!!");
                sesion.IniciarSesion(usuario);
                ReestablecerIntentos(usuario);
                return true;
            }
            return false;
        }

        public bool ExisteUsuario(string pNombreUsuario)
        {
            return ListaNombresUsuarios().Find(x => x == pNombreUsuario) == null ? false:true;
        }

        public void AumentarIntentos(string pNombreUsuario)
        {
            BE_Usuario usuario = ListaUsuarios().Find(x => x.Nombre_Usuario == pNombreUsuario);
            ormUsuario.AumentarIntentos(usuario);
            if(usuario.Intentos >= 3)
            {
                BloquearUsuario(usuario.Nombre_Usuario);
            }
        }

        public void BloquearUsuario(string pNombreUsuario)
        {
            BE_Usuario usuario = ListaUsuarios().Find(x => x.Nombre_Usuario == pNombreUsuario);
            ormUsuario.DeshabilitarUsuario(usuario);
        }

        private bool VerificarContraseña(string pContraseñaIngresada, string pHashAlmacenado)
        {
            string hashIngresado = encriptador.GenerarHash(pContraseñaIngresada);
            return hashIngresado.Equals(pHashAlmacenado);
        }

        public void HabilitarUsuario(string pNombreUsuario)
        {
            BE_Usuario usuario = ListaUsuarios().Find(x => x.Nombre_Usuario == pNombreUsuario);
            ormUsuario.HabilitarUsuario(usuario);
        }

        public void ModificarUsuario(BE_Usuario pUsuario)
        {

        }

        public BE_Usuario CrearUsuario(string pDniUsuario, string pNombreUsuario, string pMailUsuario, string pFechaNacimiento, string pTelefonoUsuario, string pRol, string pIdioma)
        {
            BEPermisoCompuesto rol = (BEPermisoCompuesto)gp.ObtenerPermisos("Roles").Find(x => x.DevolverNombrePermiso() == pRol);
            BE_Usuario nuevo_usuario = new BE_Usuario(pDniUsuario, pNombreUsuario, pMailUsuario.ToLower(), $"{pDniUsuario}{pNombreUsuario.ToUpper()}s", DateTime.Parse(pFechaNacimiento).Date, CalcularEdadUsuario(DateTime.Parse(pFechaNacimiento)), DateTime.Now, pTelefonoUsuario, true, rol, pIdioma, 0);
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
            nuevo_usuario.Contraseña_Usuario = encriptador.GenerarHash($"{pDniUsuario}{pNombreUsuario}");
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

        public void ReestablecerIntentos(BE_Usuario usuario)
        {
            ormUsuario.ReestablecerIntentos(usuario);
        }
    }
}
