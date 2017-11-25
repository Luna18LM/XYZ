using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Capadatos;
using Capaentidades;
using Capalogica;


namespace Capaweb.Controllers
{
    public class IntranetController : Controller
    {
        //
        // GET: /Intranet/
        [HttpGet]
        public ActionResult Login(String mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            try
            {
                Usuario u = logUsuario.Instancia.VerificarAcceso(frm["txtUsuario"].ToString(),
                                                                  frm["txtpassword"].ToString());
                if (u != null)
                {
                    Session["usuario"] = u;
                    return RedirectToAction("Principal", "Intranet");
                }
                else
                {
                    return RedirectToAction("Login", new { mensaje = "Usuario o contraseña no validos" });
                }
            }
            catch (Exception e) { throw e; }
        }

        [HttpGet]
        public ActionResult Principal()
        {
              return View(); 
        }

        [HttpGet]
        public ActionResult EditarUsuario(Int16 idUsuario){
            try {
                Usuario usu = logUsuario.Instancia.BuscarUsuario(idUsuario);
                return View(usu);
            }
            catch (Exception e) { throw e; }
        }

        [HttpPost]
        public ActionResult EditarUsuario(FormCollection frm)
        {
            
            try
            {
                if (frm["btnActualizar"] != null) {
                    Usuario u = new Usuario();
                    u.Nombre = frm["txtNombre"].ToString();
                    u.ApellidoPaterno = frm["txtApeP"].ToString();
                    u.ApellidoMaterno = frm["txtApeM"].ToString();
                    u.dni = frm["txtDni"].ToString();
                    u.Contasena = frm["txtContraseña"].ToString();
                    u.Fechanacimiento = Convert.ToDateTime(frm["txtFecha"]);
                    u.Direccion = frm["txtDireccion"].ToString();
                    u.Email = frm["txtEmail"].ToString();
                    u.idUsuario = Convert.ToInt16(frm["txtidUsuario"]);

                    Boolean edita = logUsuario.Instancia.EditarUsuario(u);

                    if (edita) {
                        return RedirectToAction("Principal", "Intranet");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("Principal", "Principal"); }
            }
            catch (Exception e) { throw e; }
        }

        public ActionResult CerrarSession() {
            Session.Remove("usuario");
            Session.Remove("recepcion");
            return RedirectToAction("Login", "Intranet");
        }
    }
}
