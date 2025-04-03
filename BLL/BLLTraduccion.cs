using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;

namespace BLL
{
    public class BLLTraduccion
    {
        DALTraductor dalTraductor = new DALTraductor();
        public List<BETraduccion> ListaTraduccion()
        {
            return dalTraductor.ListaTraducciones();
        }

        public List<BETraduccion> ListaIncremental(string consulta, string idioma)
        {
            return dalTraductor.ListaIncremental(consulta, idioma);
        }

        public void ModificarTraduccion(BETraduccion pTraduccion)
        {
            dalTraductor.ModificarTraduccion(pTraduccion);
        }

        public void AgregarTraduccion(BETraduccion traduccion)
        {
            dalTraductor.AgregarTraduccion(traduccion);
        }

        public void EliminarTraduccion(BETraduccion pTraduccion)
        {
            dalTraductor.EliminarTraduccion(pTraduccion);
        }

        public void ModificarIdiomaTraduccion(BEIdioma pIdioma, BEIdioma pIdiomaViejo)
        {
            foreach(BETraduccion traduccion in ListaTraduccion())
            {
                if(traduccion.idioma == pIdiomaViejo.idioma)
                {
                    dalTraductor.ModificarIdiomaTraduccion(traduccion, pIdiomaViejo, pIdioma);
                }
            }
        }
    }
}
