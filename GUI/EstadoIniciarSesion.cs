using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class EstadoIniciarSesion : Estado
    {
        Login login;
        public override void Cerrar_Estado()
        {
            login?.Dispose();
        }

        public override void Ejecutar_Estado()
        {
            login = new Login();
            login.ShowDialog();
        }
    }
}
