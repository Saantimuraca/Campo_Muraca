using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Servicios.Entidades;
using Servicios.Datos;

namespace Servicios.Logica
{
    public class LogicaTraduccion
    {
        DALTraductor dalTraductor = new DALTraductor();
        public List<EntidadTraduccion> ListaTraduccion()
        {
            return dalTraductor.ListaTraducciones();
        }

        public List<EntidadTraduccion> ListaIncremental(string consulta, string idioma)
        {
            return dalTraductor.ListaIncremental(consulta, idioma);
        }

        public void ModificarTraduccion(EntidadTraduccion pTraduccion)
        {
            dalTraductor.ModificarTraduccion(pTraduccion);
        }

        public void AgregarTraduccion(EntidadTraduccion traduccion)
        {
            dalTraductor.AgregarTraduccion(traduccion);
        }

        public void EliminarTraduccion(EntidadTraduccion pTraduccion)
        {
            dalTraductor.EliminarTraduccion(pTraduccion);
        }

        public void ModificarIdiomaTraduccion(EntidadIdioma pIdioma, EntidadIdioma pIdiomaViejo)
        {
            foreach(EntidadTraduccion traduccion in ListaTraduccion())
            {
                if(traduccion.idioma == pIdiomaViejo.idioma)
                {
                    dalTraductor.ModificarIdiomaTraduccion(traduccion, pIdiomaViejo, pIdioma);
                }
            }
        }
    }
}
