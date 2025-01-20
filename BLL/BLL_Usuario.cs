using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Usuario
    {
        private static BLL_Usuario instancia;

        public static BLL_Usuario INSTANCIA
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new BLL_Usuario();
                }
                return instancia;
            }
        }

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

        public BE_Usuario CrearUsuario(BE_Usuario pUsuario)
        {
            return null;
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
