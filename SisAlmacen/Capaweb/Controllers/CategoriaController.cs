using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Capalogica;
using Capaentidades;
using Capadatos;

namespace Capaweb.Controllers
{
    public class CategoriaController : Controller
    {
        //
        // GET: /Categoria/

        [HttpGet]
        public ActionResult ListarCategoria()
        {
            List<Categoria> lista = logCategoria.Instancia.ListarCategoria();
            return View(lista);
        }

        [HttpGet]
        public ActionResult NuevaCatetogia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevaCatetogia(FormCollection frm)
        {
            try
            {
                if (frm["btnRegistrar"] != null)
                {

                    Categoria c = new Categoria();
                    c.Nombre = frm["txtNombre"].ToString();
                    c.Descripcion = frm["txtDescripcion"].ToString();

                    Boolean inserta = logCategoria.Instancia.InsertarCategoria(c);
                    if (inserta != false)
                    {
                        return RedirectToAction("ListarCategoria");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarCategoria"); }
            }
            catch (Exception e) { throw e; }
        }

        [HttpGet]
        public ActionResult EditarCategoria(String id)
        {
            try
            {
                Categoria c = logCategoria.Instancia.BuscarCategoria(Convert.ToInt16(id));
                return View(c);
            }
            catch (Exception e) { throw e; }
        }

        [HttpPost]
        public ActionResult EditarCategoria(FormCollection frm)
        {
            try
            {
                if (frm["btnActualizar"] != null)
                {
                    Categoria c = new Categoria();
                    c.Nombre = frm["txtNombre"].ToString();
                    c.Descripcion = frm["txtDescripcion"].ToString();
                    c.idCategoria = Convert.ToInt16(frm["txtIdCategoria"]);

                    Boolean edito = logCategoria.Instancia.EditarCategoria(c);

                    if (edito != false)
                    {
                        return RedirectToAction("ListarCategoria", "Categoria");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarCategoria", "Categoria"); }
            }
            catch (Exception e) { throw e; }
        }

        [HttpGet]
        public ActionResult EliminarCategoria(String id) {
            try
            {
                Categoria c = logCategoria.Instancia.BuscarCategoria(Convert.ToInt16(id));
                return View(c);
            }
            catch (Exception e) { throw e; }
        }

        [HttpPost]
        public ActionResult EliminarCategoria(FormCollection frm)
        {
            try
            {
                if (frm["btnEliminar"] != null)
                {
                    Categoria c = new Categoria();
                    c.estado = frm["txtEstado"].ToString();
                    c.idCategoria = Convert.ToInt32(frm["txtidCategoria"]);

                    Boolean elimino = logCategoria.Instancia.EliminarCategoria(c);
                    if (elimino != false)
                    {
                        return RedirectToAction("ListarCategoria", "Categoria");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarCategoria", "Categoria"); }
            }
            catch (Exception e) { throw e; }
        }

    }
}
