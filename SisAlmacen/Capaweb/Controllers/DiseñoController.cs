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
    public class DiseñoController : Controller
    {
        //
        // GET: /Diseño/

        [HttpGet]
        public ActionResult ListarDiseño()
        {
            List<Diseño> lista = logDiseño.Instancia.ListarDiseño();
            return View(lista);
        }

        [HttpGet]
        public ActionResult NuevoDiseño()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoDiseño(FormCollection frm)
        {
            try
            {
                if (frm["btnRegistrar"] != null)
                {
                    Diseño d = new Diseño();
                    d.Nombre = frm["txtNombre"].ToString();
                    d.Descripcion = frm["txtDescripcion"].ToString();

                    Boolean inserto = logDiseño.Instancia.InsertarDiseño(d);

                    if (inserto != false)
                    {
                        return RedirectToAction("ListarDiseño");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarDiseño"); }
            }
            catch (Exception e) { throw e; }
        }

        [HttpGet]
        public ActionResult EditarDiseño(String id)
        {
            try
            {
                Diseño d = logDiseño.Instancia.BuscarDiseño(Convert.ToInt16(id));
                return View(d);
            }
            catch (Exception e) { throw e; }
        }

        [HttpPost]
        public ActionResult EditarDiseño(FormCollection frm)
        {
            try
            {
                if (frm["btnActualizar"] != null)
                {
                    Diseño d = new Diseño();
                    d.Nombre = frm["txtNombre"].ToString();
                    d.Descripcion = frm["txtDescripcion"].ToString();
                    d.idDiseño = Convert.ToInt16(frm["txtidDiseño"]);

                    Boolean edita = logDiseño.Instancia.EditarDiseño(d);

                    if (edita)
                    {
                        return RedirectToAction("ListarDiseño", "Diseño");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarDiseño", "Diseño"); }
            }
            catch (Exception e) { throw e; }
        }

        [HttpGet]
        public ActionResult EliminarDiseño(String id)
        {
            try
            {
                Diseño d = logDiseño.Instancia.BuscarDiseño(Convert.ToInt16(id));
                return View(d);
            }
            catch (Exception e) { throw e; }
        }

        [HttpPost]
        public ActionResult EliminarDiseño(FormCollection frm)
        {
            try
            {
                if (frm["btnEliminar"] != null)
                {
                    Diseño d = new Diseño();
                    d.estado = frm["txtEstado"].ToString();
                    d.idDiseño = Convert.ToInt32(frm["txtidDiseño"]);

                    Boolean elimino = logDiseño.Instancia.EliminarDiseño(d);
                    if (elimino != false)
                    {
                        return RedirectToAction("ListarDiseño", "Diseño");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarDiseño", "Diseño"); }
            }
            catch (Exception e) { throw e; }
        }

    }
}
