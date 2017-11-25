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
    public class TallaController : Controller
    {
        //
        // GET: /Talla/

        [HttpGet]
        public ActionResult ListarTalla()
        {
            List<Talla> lista = logTalla.Instancia.ListarTalla();
            return View(lista);
        }

        [HttpGet]
        public ActionResult NuevaTalla()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevaTalla(FormCollection frm)
        {
            try
            {
                if (frm["btnRegistrar"] != null)
                {
                    Talla t = new Talla();
                    t.Nombre = frm["txtNombre"].ToString();
                    t.Descripcion = frm["txtDescripcion"].ToString();

                    Boolean inserta = logTalla.Instancia.InsertarTalla(t);
                    if (inserta != false)
                    {
                        return RedirectToAction("ListarTalla");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarTalla"); }
            }
            catch (Exception e) { throw e; }
        }

        [HttpGet]
        public ActionResult EditarTalla(String id)
        {
            try
            {
                Talla t = logTalla.Instancia.BuscarTalla(Convert.ToInt16(id));
                return View(t);
            }
            catch (Exception e) { throw e; }
        }

        [HttpPost]
        public ActionResult EditarTalla(FormCollection frm)
        {
            try
            {
                if (frm["btnActualizar"] != null)
                {
                    Talla t = new Talla();
                    t.Nombre = frm["txtNombre"].ToString();
                    t.Descripcion = frm["txtDescripcion"].ToString();
                    t.idTalla = Convert.ToInt16(frm["txtidDiseño"]);

                    Boolean edito = logTalla.Instancia.EditarTalla(t);

                    if (edito != false)
                    {
                        return RedirectToAction("ListarTalla");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarTalla"); }
            }
            catch (Exception e) { throw e; }
        }

        [HttpGet]
        public ActionResult EliminarTalla(String id)
        {
            try
            {
                Talla t = logTalla.Instancia.BuscarTalla(Convert.ToInt16(id));
                return View(t);
            }
            catch (Exception e) { throw e; }
        }

        [HttpPost]
        public ActionResult EliminarTalla(FormCollection frm)
        {
            try
            {
                if (frm["btnEliminar"] != null)
                {
                    Talla t = new Talla();
                    t.estado = frm["txtEstado"].ToString();
                    t.idTalla = Convert.ToInt32(frm["txtidTalla"]);

                    Boolean elimino = logTalla.Instancia.EliminarTalla(t);
                    if (elimino != false)
                    {
                        return RedirectToAction("ListarTalla", "Talla");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarTalla", "Talla"); }
            }
            catch (Exception e) { throw e; }
        }

    }
}
