using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECliente
    {
        public string dni {  get; set; }

        public string mail { get; set; }

        public string nombre { get; set; }

        public string condicionIVA { get; set; }

        public bool isActivo { get; set; }

        public string telefono { get; set; }

        public BECliente(string pDni, string pMail, string pNombre, string pCondicionIVA, bool pIsActivo, string pTelefono)
        {
            dni = pDni;
            mail = pMail;
            nombre = pNombre;
            condicionIVA = pCondicionIVA;
            isActivo = pIsActivo;
            telefono = pTelefono;
        }

        public BECliente() { }
    }
}
