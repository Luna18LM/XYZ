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
    public class ReporteRecepcionController : Controller
    {
        //
        // GET: /ReporteRecepcion/

        public ActionResult ReporteGuiaRecepcion()
        {
            List<Guiarecepcion> lista = logGuiarecepcion.Instancia.ReporteGuiaRecepcion();
            return View(lista);
        }


        public ActionResult ReporteGuiaParametro(FormCollection frm) {
            String nombre = frm["txtNombre"].ToString();
            DateTime fecha = Convert.ToDateTime(frm["txthasta"]);
            try {
                List<Guiarecepcion> lista = logGuiarecepcion.Instancia.ListarProductoParametros(nombre,fecha);
                return View(lista);
            }
            catch (Exception e) { throw e; }
        }
    }
}
