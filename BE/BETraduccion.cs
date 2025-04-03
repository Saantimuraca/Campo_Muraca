using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BETraduccion
    {
        public string textoTraducir {  get; set; }

        public string idioma {  get; set; }

        public string textoTraducido { get; set; }

        public BETraduccion(string textoTraducir, string idioma, string textoTraducido)
        {
            this.textoTraducir = textoTraducir;
            this.idioma = idioma;
            this.textoTraducido = textoTraducido;
        }
    }
}
