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

        public EntidadIdioma(string pIdioma)
        {
            idIdioma = 0;
            idioma = pIdioma;
        }

        public EntidadIdioma(string pIdioma, int id)
        {
            idIdioma = id;
            idioma = pIdioma;
        }
    }
}
