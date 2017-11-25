using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Capadatos;
using Capaentidades;
using Capalogica;

namespace Capaweb.Controllers
{
    public class ColorController : Controller
    {
        //
        // GET: /Color/

        [HttpGet]
        public ActionResult ListarColor()
        {
            List<Color> lista = logColor.ListarColor();
            return View(lista);
        }

        [HttpGet]
        public ActionResult NuevoColor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoColor(FormCollection frm)
        {
            try
            {
                if (frm["btnRegistrar"] != null)
                {
                    Color c = new Color();
                    c.Nombre = frm["txtNombre"].ToString();
                    c.Descripcion = frm["txtDescripcion"].ToString();
                    //Boolean inserta = logColor.Instancia.InsertarColor(c);
                    Boolean inserta = logColor.InsertarColor(c);
                    if (inserta != false)
                    {
                        return RedirectToAction("ListarColor");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarColor"); }
            }
            catch (Exception e) { throw e; }
        }

        [HttpGet]
        public ActionResult EditarColor(String id)
        {
            try
            {
                Color c = logColor.BuscarColor(Convert.ToInt16(id));
                return View(c);
            }
            catch (Exception e) { throw e; }
        }

        [HttpPost]
        public ActionResult EditarColor(FormCollection frm)
        {
            try
            {
                if (frm["btnActualizar"] != null)
                {
                    Color c = new Color();
                    c.Nombre = frm["txtNombre"].ToString();
                    c.Descripcion = frm["txtDescripcion"].ToString();
                    c.idColor = Convert.ToInt16(frm["txtIdColor"]);

                    Boolean edito = logColor.EditarColor(c);
                    if (edito != false)
                    {
                        return RedirectToAction("ListarColor", "Color");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarColor", "Color"); }
            }
            catch (Exception e) { throw e; }
        }

        [HttpGet]
        public ActionResult EliminarColor(String id)
        {
            try
            {
                Color c = logColor.BuscarColor(Convert.ToInt16(id));
                return View(c);
            }
            catch (Exception e) { throw e; }
        }

        [HttpPost]
        public ActionResult EliminarColor(FormCollection frm)
        {
            try
            {
                if (frm["btnEliminar"] != null)
                {
                    Color c = new Color();
                    c.estado = frm["txtEstado"].ToString();
                    c.idColor = Convert.ToInt32(frm["txtidColor"]);

                    Boolean elimino = logColor.EliminarColor(c);
                    if (elimino != false)
                    {
                        return RedirectToAction("ListarColor", "Color");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarColor", "Color"); }
            }
            catch (Exception e) { throw e; }
        }

    }
}
