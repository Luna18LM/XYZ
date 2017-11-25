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
    public class ReporteSalidaController : Controller
    {
        //
        // GET: /ReporteSalida/

        public ActionResult ReporteGuiaSalida()
        {
            List<Guiaremision> lista = logGuiaremision.Instancia.listaRemision();
            return View(lista);
        }

        public ActionResult ReporteGuiaSalidaParametro(FormCollection frm)
        {
            String nombre = frm["txtNombre"].ToString();
            DateTime fecha = Convert.ToDateTime(frm["txthasta"]);
            try
            {
                List<Guiaremision> lista = logGuiaremision.Instancia.ListarGuiaSalidaParametros(nombre, fecha);
                return View(lista);
            }
            catch (Exception e) { throw e; }
        }
    }
}
