using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;
using Servicios.Logica;

namespace BLL
{
    public class BLLCliente
    {
        DALCliente dalCliente = new DALCliente(); 
        ServicioMail mail = new ServicioMail();
        public void Agregar(BECliente pCliente)
        {
            dalCliente.Agregar(pCliente);
            string asunto = "¡Te hemos registrado como cliente en TecnoSoft!";
            string plantilla = "Hola {cliente},\r\n\r\nQueremos informarte que hemos registrado tus datos en nuestro sistema como nuevo cliente.\r\n\r\nA partir de ahora, vas a poder disfrutar de una atención más personalizada y recibir nuestras novedades, promociones y beneficios.\r\n\r\nDatos registrados:\r\n\r\n📛 Nombre: {nombre}\r\n\r\n📧 Email: {correo}\r\n\r\n📞 Teléfono: {telefono}\r\n\r\n🧾 Condición frente al IVA: {iva}\r\n\r\nSi alguno de estos datos es incorrecto, por favor comunicate con nosotros para actualizarlo.\r\n\r\n";
            string cuerpo = plantilla.Replace("{cliente}", pCliente.nombre).Replace("{nombre}", pCliente.nombre).Replace("{correo}", pCliente.mail).Replace("{telefono}", pCliente.telefono).Replace("{iva}", pCliente.condicionIVA);
            string mailOrigen = "Saantimuraca12@gmail.com";
            string contraseña = "sdrjuqddpkdzwsph";
            string[] vectorMail = pCliente.mail.Split('@');
            if (vectorMail[1].ToLower() == "gmail.com") { mail.EnviarCorreo(pCliente.mail, asunto, cuerpo, mailOrigen, contraseña); }
        }

        public void CambiarEstado(BECliente pCliente)
        {
            dalCliente.CambiarEstado(pCliente);
        }

        public void Modificar(BECliente pCliente)
        {
            dalCliente.Modificar(pCliente);
        }

        public List<BECliente> ListaClientes()
        {
            return dalCliente.ListaClientes();
        }

        public bool ExisteCliente(string dni)
        {
            return ListaClientes().Find(x => x.dni == dni) == null ? false : true;
        }
    }
}
