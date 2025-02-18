using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Servicios
{
    public class ServicioMail
    {
        public event EventHandler EmailEnviado;

        public void EnviarCorreo(string PDestinatario, string pAsunto, string pCuerpo, string pEmisor, string pContraseña)
        {
            //Configurar el cliente.
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(pEmisor, pContraseña);
            //Crear mensaje.
            MailMessage mensaje = new MailMessage
            {
                From = new MailAddress(pEmisor), 
                Subject = pAsunto,
                Body = pCuerpo,
            };
            mensaje.To.Add(PDestinatario);
            //Enviar correo.
            client.Send(mensaje);
            //Disparar evento.
            EmailEnviado?.Invoke(this, EventArgs.Empty);
        }
    }
}
