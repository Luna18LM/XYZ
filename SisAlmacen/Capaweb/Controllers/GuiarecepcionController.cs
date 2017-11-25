using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Capaentidades;
using Capadatos;
using Capalogica;

namespace Capaweb.Controllers
{
    public class GuiarecepcionController : Controller
    {
        //
        // GET: /Guiarecepcion/
        private void CrearCarritosession()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idProducto", Type.GetType("System.Int16"));
            dt.Columns.Add("Nombre", Type.GetType("System.String"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            dt.Columns.Add("Precio", Type.GetType("System.Decimal"));
            dt.Columns.Add("stock", Type.GetType("System.Int16"));
            dt.Columns.Add("cantidad", Type.GetType("System.Int32"));
            dt.Columns.Add("observacion", Type.GetType("System.String"));
            Session["recepcion"] = dt;
        }

        public ActionResult Guiarecepcion()
        {
            if (Session["recepcion"] == null) { CrearCarritosession(); }
            DataTable dt = (DataTable)Session["recepcion"];
            return View();
        }

        public ActionResult ListarProducto()
        {
            List<Producto> lista = logProducto.Instancia.ListarProducto();
            return View(lista);
        }

        public ActionResult AgregarGuia(FormCollection frm)
        {
            try {
                if (Convert.ToInt16(frm["txtCant"]) < 0) {
                    ViewBag.mensajito = "Lo Sentimos la cantidad debe ser mayor a cero";
                    List<Producto> lista = logProducto.Instancia.ListarProducto();
                    return View("ListarProducto", lista);
                }
                else {
                    if (Session["recepcion"] == null) { CrearCarritosession(); }
                    DataTable dt = (DataTable)Session["recepcion"];
                    Boolean Existe = false;
                    foreach (DataRow f in dt.Rows) {
                        Int16 can = Convert.ToInt16(frm["txtCant"]);
                        if (Convert.ToInt16(frm["txtidProducto"]) == Convert.ToInt16(f["idProducto"])) {
                            Existe = true;
                            f["cantidad"] = can + Convert.ToInt16(f["cantidad"]);
                            dt.AcceptChanges();
                            break;
                        }
                    }
                    Session["recepcion"] = dt;

                    if (!Existe) {
                        DataRow r = dt.NewRow();
                        r["idProducto"] = Convert.ToInt16(frm["txtidProducto"]);
                        r["Nombre"] = frm["txtNombre"].ToString();
                        r["Descripcion"] = frm["txtDescripcion"].ToString();
                        r["Precio"] = Convert.ToDecimal(frm["txtPrecio"]);
                        r["stock"] = Convert.ToInt16(frm["txtStock"]);
                        r["cantidad"] = Convert.ToInt16(frm["txtCant"]);
                        r["observacion"] = frm["txtObservacion"].ToString();
                        dt.Rows.Add(r);
                        return RedirectToAction("Guiarecepcion");
                    }
                    else { return RedirectToAction("Guiarecepcion"); }
                }
            }
            catch (Exception e) { throw e; }
        }

       public ActionResult ModificarCantidad(FormCollection frm) {
            DataTable dt = (DataTable)Session["recepcion"];
            foreach (DataRow f in dt.Rows) {

                Decimal pr = Convert.ToDecimal(frm["txtPrecio"]);
                Decimal can = Convert.ToDecimal(frm["txtcant"]);
                Int16 id = Convert.ToInt16(frm["txtIdProd"]);
                if (Convert.ToInt16(frm["txtIdProd"]) == Convert.ToInt16(f["idProducto"])) {
                    if (Convert.ToInt16(frm["txtcant"]) == 0){
                        ViewBag.mensajito = "Lo sentimos! Cantidad debe ser mayor a 0";
                        return View("Guiarecepcion");
                    }
                    else {
                        f["cantidad"] = can;
                        dt.AcceptChanges();
                        break;
                    }
                }
            }
            Session["recepcion"] = dt;
            return RedirectToAction("Guiarecepcion");
        }

       public ActionResult AgregarObservacion(FormCollection frm) {
           DataTable dt = (DataTable)Session["recepcion"];
           foreach (DataRow f in dt.Rows) {
               String ob = frm["txtobservacion"].ToString();
               Int16 id = Convert.ToInt16(frm["txtIdProd"]);
               if (Convert.ToInt16(frm["txtIdProd"]) == Convert.ToInt16(f["idProducto"])){
                   f["observacion"] = ob;
                   dt.AcceptChanges();
                   break;
               }
           }
           Session["recepcion"] = dt;
           return RedirectToAction("Guiarecepcion");
       }

        public ActionResult QuitarProducto(String id) {
            DataTable dt = (DataTable)Session["recepcion"];
            foreach (DataRow f in dt.Rows){
                if (Convert.ToInt16(id) == Convert.ToInt16(f["idProducto"])){
                    f.Delete();
                    dt.AcceptChanges();
                    break;
                }
            }
            Session["recepcion"] = dt;
            ViewBag.mensajito = "El producto ha sido Eliminado de la guia";
            return RedirectToAction("Guiarecepcion");
        }
        
        public ActionResult Guardarguia()
        {
            Guiarecepcion g = new Guiarecepcion();
            g.usuario = (Usuario)Session["usuario"];

            List<DetGuiaRec> detalle = new List<DetGuiaRec>();
            DataTable dt = (DataTable)Session["recepcion"];
            foreach (DataRow r in dt.Rows) {
                DetGuiaRec d = new DetGuiaRec();
                d.Cantidad = Convert.ToInt16(r["cantidad"]);
                d.Observacion = r["observacion"].ToString();
                Producto pr = new Producto();
                pr.idProducto = Convert.ToInt16(r["idProducto"]);
                d.Precio = Convert.ToDecimal(r["Precio"]);
                d.producto = pr;
                detalle.Add(d);
            }
            g.Detalle = detalle;
            Int32 guia = logGuiarecepcion.Instancia.InsertarGuiarecepcion(g);
            Session["recepcion"] = null;
            return RedirectToAction("Guiarecepcion");
        }
        
    }
}
