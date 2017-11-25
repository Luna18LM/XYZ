using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Data;
using Capaentidades;
using Capadatos;
using Capalogica;
using Capalogica.Servicios;

namespace Capaweb.Controllers
{
    public class CorreoController : Controller
    {
        //
        // GET: /Correo/

        //public void enviarEmail(String de, String Destinatario, String asunto, String contenido, String password)
        //{

        //    System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
        //    mmsg.To.Add(Destinatario);
        //    mmsg.Subject = asunto;
        //    mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
        //    mmsg.Body = contenido;
        //    mmsg.BodyEncoding = System.Text.Encoding.UTF8;
        //    mmsg.From = new System.Net.Mail.MailAddress(de);

        //    /*Cliente de correo*/
        //    System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
        //    cliente.Host = "smtp.gmail.com";
        //    cliente.Port = 587;
        //    cliente.UseDefaultCredentials = false;
        //    cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    cliente.Credentials = new System.Net.NetworkCredential(de, password);

        //    cliente.EnableSsl = true;


        //    /*Envio Correo*/
        //    try
        //    {
        //        cliente.Send(mmsg);
        //    }
        //    catch (System.Net.Mail.SmtpException ex)
        //    {
        //        throw ex;
        //    }
        //}


        [HttpGet]
        public ActionResult EnviarCorreo()
        {
            return View();
        }
        
        public ActionResult IngresarCorreo(FormCollection frm){
           
            Int16 idUsuario = Convert.ToInt16(frm["txtidUsuario"]);
            String De = frm["txtDe"].ToString();
            String Destinatario = frm["txtDestinario"].ToString();
            String Asunto = frm["txtAsunto"].ToString();
            String Contenido = frm["txtContenido"].ToString();
            String password = frm["txtPassword"].ToString();
            try {
                if (frm["btnEnviar"] != null){
                    Correo c = new Correo();
                    c.idUsuario = idUsuario;
                    c.De = De;
                    c.Destinatario = Destinatario;
                    c.Asunto = Asunto;
                    c.Contenido = Contenido;
                    Usuario u = new Usuario();
                    u.Contasena = password;
                    c.usuario = u;
                    
                    Boolean inserta = logCorreo.Instancia.InsertarCorreo(c);
                    if (inserta != false) {
                       
                        EnviarEmail.enviarEmail(c);
                        return RedirectToAction("EnviarCorreo");
                    }
                    else { return View(); }

                }
                else { return RedirectToAction("EnviarCorreo"); }
            }
            catch (Exception e) { throw e; }
        }
    }
}
