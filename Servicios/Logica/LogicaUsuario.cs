using Microsoft.VisualBasic;
using Servicios;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Servicios.Datos;
using Servicios.Entidades;

namespace Servicios.Logica
{
    public class LogicaUsuario
    {
        
        DatosUsuario  ormUsuario = new DatosUsuario();
        Encriptador encriptador = new Encriptador();
        GestorPermisos gp = new GestorPermisos();
        Traductor traductor = Traductor.INSTANCIA;
        public void AgregarUsuario(EntidadUsuario pUsuario)
        {
            ormUsuario.AgregarUsuario(pUsuario);
        }

        public bool RolIsInUso(string pNombre)
        {
            foreach (EntidadUsuario usuario in ListaUsuarios())
            {
                if (usuario.Rol.DevolverNombrePermiso() == pNombre) { return true; }
            }
            return false;
        }

        public void ModificarUsuario(EntidadUsuario pUsuario)
        {
            ormUsuario.ModificarUsuario(pUsuario);
        }

        public bool Login(string pNombreUsuario, string pContraseñaIngresada)
        {
            EntidadUsuario usuario = ListaUsuarios().Find(x => x.Nombre_Usuario == pNombreUsuario);
            if (usuario.Estado_Usuario == false) throw new Exception("Usuario bloqueado!!!");
            GestorPermisos gp = new GestorPermisos();
            if (!gp.BuscarPermiso("LogIn", usuario.Rol)) throw new Exception("Este usuario no posee permisos para ingresar");
            if(VerificarContraseña(pContraseñaIngresada, usuario.Contraseña_Usuario))
            {
                Sesion sesion = Sesion.INSTANCIA;
                if (!usuario.Estado_Usuario) throw new Exception("Su usuario se encuentra bloqueado, contactese con el administrador para que lo desbloquee");
                sesion.IniciarSesion(usuario);
                ReestablecerIntentos(usuario);
                return true;
            }
            return false;
        }

        public void CambiarIdioma(EntidadUsuario pUsuario, string pNuevoIdioma)
        {
            pUsuario.Idioma = pNuevoIdioma;
            ormUsuario.CambiarIdioma(pUsuario);
            Sesion sesion = Sesion.INSTANCIA;
            sesion.ConfigurarIdioma(pNuevoIdioma);
        }

        public bool ExisteUsuario(string pNombreUsuario, int pTipo, string pDNI)
        {
            if(pTipo == 0)
            {
                return ListaNombresUsuarios().Find(x => x == pNombreUsuario) == null ? false : true;
            }
            else
            {
                if (ListaNombresUsuarios().Find(x => x == pNombreUsuario) != null)
                {
                   foreach(EntidadUsuario usuario in ListaUsuarios())
                   {
                        if(pNombreUsuario == usuario.Nombre_Usuario && pDNI != usuario.Dni_Usuario)
                        {
                            return true;
                        }
                   }
                    return false;
                }
                return false;
            }
        }

        public void AumentarIntentos(string pNombreUsuario)
        {
            EntidadUsuario usuario = ListaUsuarios().Find(x => x.Nombre_Usuario == pNombreUsuario);
            ormUsuario.AumentarIntentos(usuario);
            if(usuario.Intentos >= 3)
            {
                BloquearUsuario(usuario.Nombre_Usuario);
            }
        }

        public void BloquearUsuario(string pNombreUsuario)
        {
            EntidadUsuario usuario = ListaUsuarios().Find(x => x.Nombre_Usuario == pNombreUsuario);
            ormUsuario.DeshabilitarUsuario(usuario);
        }

        private bool VerificarContraseña(string pContraseñaIngresada, string pHashAlmacenado)
        {
            string hashIngresado = encriptador.GenerarHash(pContraseñaIngresada);
            return hashIngresado.Equals(pHashAlmacenado);
        }

        public void HabilitarUsuario(string pNombreUsuario)
        {
            EntidadUsuario usuario = ListaUsuarios().Find(x => x.Nombre_Usuario == pNombreUsuario);
            ormUsuario.HabilitarUsuario(usuario);
        }

        private bool DNIRepetido(string dni)
        {
            return ListaDNIs().Find(x => x == dni) == null ? false: true;
        }


        public EntidadUsuario CrearUsuario(string pDniUsuario, string pNombreUsuario, string pMailUsuario, string pFechaNacimiento, string pTelefonoUsuario, string pRol, string pIdioma, int pTipo)
        {
            if(pTipo == 0) { if (DNIRepetido(pDniUsuario)) throw new Exception(traductor.Traducir("Ya existe un usuario asociado al DNI ingresado!!!", "")); }
            if (ExisteUsuario(pNombreUsuario, pTipo, pDniUsuario)) throw new Exception(traductor.Traducir("Usuario existente!!!", ""));
            EntidadPermisoCompuesto rol = (EntidadPermisoCompuesto)gp.ObtenerPermisos("Roles").Find(x => x.DevolverNombrePermiso() == pRol);
            EntidadUsuario nuevo_usuario = new EntidadUsuario(pDniUsuario, pNombreUsuario, pMailUsuario.ToLower(), $"{pDniUsuario}{pNombreUsuario}", DateTime.Parse(pFechaNacimiento).Date, DateTime.Now, pTelefonoUsuario, true, rol, pIdioma, 0);
            nuevo_usuario.Contraseña_Usuario = encriptador.GenerarHash($"{pDniUsuario}{pNombreUsuario}");
            return nuevo_usuario;
        }

        public List<string> ListaDNIs()
        {
            List<string> lista = new List<string>();   
            foreach(EntidadUsuario usuario in ListaUsuarios())
            {
                lista.Add(usuario.Dni_Usuario);
            }
            return lista;
        }
        public List<string> ListaNombresUsuarios()
        {
            List<string> lista = new List<string>();
            foreach(EntidadUsuario usuario in ListaUsuarios())
            {
                lista.Add(usuario.Nombre_Usuario);
            }
            return lista;
        }

        public List<EntidadUsuario> ListaUsuarios()
        {
            return ormUsuario.ListaUsuarios();
        }

        public void ReestablecerIntentos(EntidadUsuario usuario)
        {
            ormUsuario.ReestablecerIntentos(usuario);
        }

        public void CerrarSesion(EntidadUsuario pUsuario)
        {
            Sesion sesion = Sesion.INSTANCIA;
            sesion.CerrarSesion();
        }

        public void CambiarContraseña(EntidadUsuario pUsuario, string pNuevaContraseña)
        {
            pUsuario.Contraseña_Usuario = encriptador.GenerarHash(pNuevaContraseña);
            ormUsuario.CambiarContraseña(pUsuario);
        }
    }
}
