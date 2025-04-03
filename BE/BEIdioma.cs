using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEIdioma
    {
        public int idIdioma {  get; set; }

        public string idioma { get; set; }

        public BEIdioma(string pIdioma)
        {
            idIdioma = 0;
            idioma = pIdioma;
        }

        public BEIdioma(string pIdioma, int id)
        {
            idIdioma = id;
            idioma = pIdioma;
        }
    }
}
