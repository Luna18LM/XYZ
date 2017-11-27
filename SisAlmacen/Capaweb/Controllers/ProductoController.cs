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
using System.IO;

namespace Capaweb.Controllers
{
    public class ProductoController : Controller
    {
        //

        // GET: /Producto/

        [HttpGet]
        public ActionResult ListarProducto()
        {
            List<Producto> lista = logProducto.Instancia.ListarProducto();
            return View(lista);
        }

        public ActionResult Listarproductonombre(FormCollection frm) {
            List<Producto> lista = logProducto.Instancia.Listarproductonombre(frm["txtNombre"].ToString());
            return View(lista);
        }

        [HttpGet]
        public ActionResult NuevoProducto()
        {
            List<Categoria> lstCategoria = logCategoria.Instancia.ListarCategoria();
            var lstcategoria = new SelectList(lstCategoria, "idCategoria", "Nombre");
            ViewBag.listaCategoria = lstcategoria;

            List<Talla> lstTalla = logTalla.Instancia.ListarTalla();
            var lsttalla = new SelectList(lstTalla, "idTalla", "Nombre");
            ViewBag.listaTalla = lsttalla;

            List<Diseño> lstDiseño = logDiseño.Instancia.ListarDiseño();
            var lstdiseño = new SelectList(lstDiseño, "idDiseño", "Nombre");
            ViewBag.listaDiseño = lstdiseño;

            List<Color> lstColor = logColor.ListarColor();
            var lstcolor = new SelectList(lstColor, "idColor", "Nombre");
            ViewBag.listaColor = lstcolor;

            return View();
        }

        [HttpPost]
        public ActionResult NuevoProducto(FormCollection frm,HttpPostedFileBase archivo)
        {
            int idCategoria = Convert.ToInt32(frm["categorias"].Equals("") ? "0" : frm["categorias"]);
            int idtalla = Convert.ToInt32(frm["tallas"].Equals("") ? "0" : frm["tallas"]);
            int idDiseño = Convert.ToInt32(frm["diseños"].Equals("") ? "0" : frm["diseños"]);
            int idColor = Convert.ToInt32(frm["colores"].Equals("") ? "0" : frm["colores"]);
            Producto p = new Producto();
            try
            {
                if (frm["btnRegistrar"] != null)
                {

                    p.Nombre = frm["txtNombre"].ToString();
                    p.Serie = frm["txtSerie"].ToString();
                    p.Precio = Convert.ToDecimal(frm["txtPrecio"]);
                    p.Stock = Convert.ToInt16(frm["txtStock"]);    
                    p.Descripcion = frm["txtDescripcion"].ToString();
                     if (archivo != null && archivo.ContentLength > 0) {
                         p.Imagen = Path.GetFileName(archivo.FileName);
                    }
                    Categoria c = new Categoria();
                    c.idCategoria = idCategoria;
                    p.categoria = c;
                    Talla t = new Talla();
                    t.idTalla = idtalla;
                    p.talla = t;
                    Diseño d = new Diseño();
                    d.idDiseño = idDiseño;
                    p.diseño = d;
                    Color co = new Color();
                    co.idColor = idColor;
                    p.color = co;

                    Boolean inserto = logProducto.Instancia.InsertarProducto(p);
                    if (inserto != false)
                    {
                        if (archivo != null && archivo.ContentLength > 0)
                        {
                            var namearchivo = Path.GetFileName(archivo.FileName);
                            var ruta = Path.Combine(Server.MapPath("~/Recursos/Imagenes/Productos"), namearchivo);
                            archivo.SaveAs(ruta);
                        }    
                        return RedirectToAction("ListarProducto");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarProducto"); }
            }
            catch (Exception e) { throw e; }
        }

        [HttpGet]
        public ActionResult EditarProducto(String id)
        {
            try
            {
                List<Categoria> lstCategoria = logCategoria.Instancia.ListarCategoria();
                var lstcategoria = new SelectList(lstCategoria, "idCategoria", "Nombre");
                ViewBag.listaCategoria = lstcategoria;

                List<Talla> lstTalla = logTalla.Instancia.ListarTalla();
                var lsttalla = new SelectList(lstTalla, "idTalla", "Nombre");
                ViewBag.listaTalla = lsttalla;

                List<Diseño> lstDiseño = logDiseño.Instancia.ListarDiseño();
                var lstdiseño = new SelectList(lstDiseño, "idDiseño", "Nombre");
                ViewBag.listaDiseño = lstdiseño;

                List<Color> lstColor = logColor.ListarColor();
                var lstcolor = new SelectList(lstColor, "idColor", "Nombre");
                ViewBag.listaColor = lstcolor;

                Producto p = logProducto.Instancia.BuscarProducto(Convert.ToInt16(id));

                return View(p);
            }
            catch (Exception e) { throw e; }
        }


        [HttpPost]
        public ActionResult EditarProducto(FormCollection frm, Producto p, HttpPostedFileBase archivo)
        {
            int idCategoria = p.categoria.idCategoria; //Convert.ToInt32(frm["categorias"].Equals("") ? "0" : frm["categorias"]);
            int idtalla = p.talla.idTalla;//Convert.ToInt32(frm["tallas"].Equals("") ? "0" : frm["tallas"]);
            int idDiseño = p.diseño.idDiseño;//Convert.ToInt32(frm["diseños"].Equals("") ? "0" : frm["diseños"]);
            int idColor = p.color.idColor;//Convert.ToInt32(frm["colores"].Equals("") ? "0" : frm["colores"]);
            try
            {
                if (frm["btnActualizar"] != null)
                {
                    p.Nombre = frm["txtNombre"].ToString();
                    p.Precio = Convert.ToDecimal(frm["txtPrecio"]);
                    p.Stock = Convert.ToInt16(frm["txtStock"]);
                    p.Serie = frm["txtSerie"].ToString();
                    p.Descripcion = frm["txtDescripcion"].ToString();
                    if (archivo != null && archivo.ContentLength > 0)
                    {
                        p.Imagen = Path.GetFileName(archivo.FileName);
                    }
                    p.idProducto = Convert.ToInt16(frm["txtidProducto"]);
                    Categoria c = new Categoria();
                    c.idCategoria = idCategoria;
                    p.categoria = c;
                    Talla t = new Talla();
                    t.idTalla = idtalla;
                    p.talla = t;
                    Diseño d = new Diseño();
                    d.idDiseño = idDiseño;
                    p.diseño = d;
                    Color co = new Color();
                    co.idColor = idColor;
                    p.color = co;

    

                    Boolean edito = logProducto.Instancia.EditarProducto(p);
                    if (edito != false)
                    {
                        if (archivo != null && archivo.ContentLength > 0)
                        {
                            var namearchivo = Path.GetFileName(archivo.FileName);
                            var ruta = Path.Combine(Server.MapPath("~/Recursos/Imagenes/Productos"), namearchivo);
                            archivo.SaveAs(ruta);
                        }



                        return RedirectToAction("ListarProducto");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarProducto"); }
            }
            catch (Exception e) { throw e; }
        }

        [HttpGet]
        public ActionResult EliminarProducto(String id)
        {
            try
            {
                Producto p = logProducto.Instancia.BuscarProducto(Convert.ToInt16(id));
                return View(p);
            }
            catch (Exception e) { throw e; }
        }

        [HttpPost]
        public ActionResult EliminarProducto(FormCollection frm)
        {
            try
            {
                if (frm["btnEliminar"] != null)
                {
                    Producto p = new Producto();
                    p.estado = frm["txtEstado"].ToString();
                    p.idProducto = Convert.ToInt32(frm["txtidProducto"]);

                    Boolean elimino = logProducto.Instancia.EliminarProducto(p);
                    if (elimino != false)
                    {
                        return RedirectToAction("ListarProducto", "Producto");
                    }
                    else { return View(); }
                }
                else { return RedirectToAction("ListarProducto", "Producto"); }
            }
            catch (Exception e) { throw e; }
        }

        [HttpGet]
        public ActionResult ReporteProductoMin() {
            try {
                List<Producto> listamin = logProducto.Instancia.ReporteMinStockProducto();
                return View(listamin);
            }
            catch (Exception e) { throw e; }
        }

        public ActionResult DetalleProducto(String id) {
            try {
                Producto p = logProducto.Instancia.BuscarProducto(Convert.ToInt16(id));
                return View(p);
            }
            catch (Exception e) { throw e; }
        }

    }
}
