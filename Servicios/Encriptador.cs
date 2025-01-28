using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Encriptador
    {
        public string GenerarHash(string texto)
        {
            using(SHA256 sha256 = SHA256.Create())
            {
                //Convertir el texto a un array de bytes
                byte[] textoBytes = Encoding.UTF8.GetBytes(texto);
                //Generar el hash
                byte[] hashBytes = sha256.ComputeHash(textoBytes);
                //Convertir el hash a una cadena hexadecimal
                StringBuilder stringBuilder = new StringBuilder();
                foreach(byte b in hashBytes)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
    }
}
