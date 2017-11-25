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
    public class RemisionController : Controller
    {
        //
        // GET: /Remision/

        public ActionResult GuiaRemision()
        {
            return View();
        }

        public ActionResult ListarProductos()
        {
            List<Producto> lista = logProducto.Instancia.ListarProducto();
            return View(lista);
        }

        public ActionResult ListarDistribuidor() {
            List<Distribuidor> lista = logDistribuidor.Instancia.listarDistribuidor();
            return View(lista);
        }
    }
}
