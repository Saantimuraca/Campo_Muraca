using BLL;
using DAO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Servicios
{
    public class Traductor
    {
        DALTraductor dt = new DALTraductor();
        Dictionary<string, string> d;
        private static Traductor instancia;
        public static Traductor INSTANCIA
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Traductor();
                }
                return instancia;
            }
        }

        public Traductor()
        {
            try
            {
                Sesion sesion = Sesion.INSTANCIA;
                ActualizarIdioma(sesion.ObtenerIdiomaSesion());
            }
            catch { ActualizarIdioma("Español");}
        }

        public void ActualizarIdioma(string idioma)
        {
            d = dt.CargarTraduccion(idioma);
        }

        List<IObserver> listFormularios = new List<IObserver>();
        


        public void Notificar()
        {
            foreach(IObserver form in listFormularios)
            {
                form.ActualizarLenguaje();
            }
        }

        public void Suscribir(IObserver pNuevoOberserver)
        {
            this.listFormularios.Add(pNuevoOberserver);
        }


        public string Traducir(string textoTraducir, string pIdioma)
        {
            try
            {
                return d[textoTraducir].ToString();
            }
            catch { return  textoTraducir; }
        }
    }
}
