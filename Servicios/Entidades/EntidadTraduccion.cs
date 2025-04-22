using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Entidades
{
    public class EntidadTraduccion
    {
        public string textoTraducir {  get; set; }

        public string idioma {  get; set; }

        public string textoTraducido { get; set; }

        public EntidadTraduccion(string textoTraducir, string idioma, string textoTraducido)
        {
            this.textoTraducir = textoTraducir;
            this.idioma = idioma;
            this.textoTraducido = textoTraducido;
        }
    }
}
