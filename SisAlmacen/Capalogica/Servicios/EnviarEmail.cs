using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Capaentidades;
namespace Capalogica.Servicios
{
    public class EnviarEmail
    {
        public  static void enviarEmail(Correo c)
        {
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                mmsg.To.Add(c.Destinatario);
                mmsg.Subject = c.Asunto;
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                mmsg.Body = c.Contenido;
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.From = new System.Net.Mail.MailAddress(c.De);
            
                /*Cliente de correo*/
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
                cliente.Host = "smtp.gmail.com";
                cliente.Port = 587;
                cliente.UseDefaultCredentials = false;
                cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                cliente.Credentials = new System.Net.NetworkCredential(c.De, c.usuario.Contasena);

                cliente.EnableSsl = true;
     

            /*Envio Correo*/
            try
            {
                cliente.Send(mmsg);
      ;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
              
                throw ex;
            }
        }
    }
}
