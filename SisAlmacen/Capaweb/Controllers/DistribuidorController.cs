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
    public class DistribuidorController : Controller
    {
        //
        // GET: /Distribuidor/

        [HttpGet]
        public ActionResult ListarDistribuidor()
        {
            List<Distribuidor> lista = logDistribuidor.Instancia.listarDistribuidor();
            return View(lista);
        }

        [HttpGet]
        public ActionResult NuevoDistribuidor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoDistribuidor(FormCollection frm)
        {
            try
            {
                if (frm["btnRegistrar"] != null)
                {
                    Distribuidor d = new Distribuidor();
                    d.RazonSocial = frm["txtRazonSocial"].ToString();
                    d.Ruc = frm["txtRuc"].ToString();
                    d.Direccion = frm["txtDireccion"].ToString();
                    d.Telefono = frm["txtTelefono"].ToString();
                    d.Email = frm["txtEmail"].ToString();

                    Boolean inserta = logDistribuidor.Instancia.InsertarDistribuidor(d);
                    if (inserta != false)
                    {
                        return RedirectToAction("ListarDistribuidor");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarDistribuidor"); }
            }
            catch (Exception e) { throw e; }
        }

        [HttpGet]
        public ActionResult EditarDistribuidor(String id)
        {
            try
            {
                Distribuidor d = logDistribuidor.Instancia.BuscarDistribuidor(Convert.ToInt16(id));
                return View(d);
            }
            catch (Exception e) { throw e; }
        }

        [HttpPost]
        public ActionResult EditarDistribuidor(FormCollection frm)
        {
            try
            {
                if (frm["btnActualizar"] != null)
                {
                    Distribuidor d = new Distribuidor();

                    d.RazonSocial = frm["txtRazonSocial"].ToString();
                    d.Ruc = frm["txtRuc"].ToString();
                    d.Direccion = frm["txtDireccion"].ToString();
                    d.Telefono = frm["txtTelefono"].ToString();
                    d.Email = frm["txtEmail"].ToString();
                    d.idDistribuidor = Convert.ToInt32(frm["txtIdDistribuidor"]);

                    Boolean edito = logDistribuidor.Instancia.EditarDistribuidor(d);
                    if (edito != false)
                    {
                        return RedirectToAction("ListarDistribuidor", "Distribuidor");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarDistribuidor", "Distribuidor"); }
            }
            catch (Exception e) { throw e; }
        }

        [HttpGet]
        public ActionResult EliminarDistribuidor(String id)
        {
            try
            {
                Distribuidor d = logDistribuidor.Instancia.BuscarDistribuidor(Convert.ToInt16(id));
                return View(d);
            }
            catch (Exception e) { throw e; }
        }

        [HttpPost]
        public ActionResult EliminarDistribuidor(FormCollection frm)
        {
            try
            {
                if (frm["btnEliminar"] != null)
                {
                    Distribuidor d = new Distribuidor();
                    d.Estado = frm["txtEstado"].ToString();
                    d.idDistribuidor = Convert.ToInt32(frm["txtIdDistribuidor"]);

                    Boolean elimino = logDistribuidor.Instancia.EliminarDistribuidor(d);
                    if (elimino != false)
                    {
                        return RedirectToAction("ListarDistribuidor", "Distribuidor");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarDistribuidor", "Distribuidor"); }
            }
            catch (Exception e) { throw e; }
        }

    }
}
