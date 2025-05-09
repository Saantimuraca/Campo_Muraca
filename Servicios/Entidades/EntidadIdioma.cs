using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Entidades
{
    public class EntidadIdioma
    {
        public int idIdioma {  get; set; }

        public string idioma { get; set; }

        public bool isDisponible { get; set; }

        public EntidadIdioma(string pIdioma)
        {
            idIdioma = 0;
            idioma = pIdioma;
            isDisponible = false;
        }

        public EntidadIdioma(string pIdioma, int id, bool pisDisponible)
        {
            idIdioma = id;
            idioma = pIdioma;
            isDisponible= pisDisponible;
        }
    }
}
