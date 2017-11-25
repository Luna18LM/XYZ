using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using Capaentidades;
using Capalogica;
using Capadatos;
namespace Capaweb.Controllers
{
    public class GuiaSalidaController : Controller
    {
        //
        // GET: /GuiaSalida/

        private void Crearguiaremision()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idProducto", Type.GetType("System.Int32"));
            dt.Columns.Add("Nombre", Type.GetType("System.String"));
            dt.Columns.Add("Precio", Type.GetType("System.Decimal"));
            dt.Columns.Add("Stock", Type.GetType("System.Int32"));
            dt.Columns.Add("Cantidad", Type.GetType("System.Int32"));
            dt.Columns.Add("Importe", Type.GetType("System.Decimal"));
            Session["remision"] = dt;
        }

        private void CrearDistribuidor()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idDistribuidor", Type.GetType("System.Int32"));
            dt.Columns.Add("RazonSocial", Type.GetType("System.String"));
            dt.Columns.Add("RUC", Type.GetType("System.String"));
            Session["distribuidor"] = dt;
        }

        public ActionResult GuiaSalida(String mensaje)
        {
            if (Session["remision"] == null) { Crearguiaremision(); }
            DataTable dt = (DataTable)Session["remision"];
            decimal Total = 0;
            Total = calcularImporteTotal(dt);
            ViewBag.Subtotal = calcularSubTotal(Total).ToString("N2");
            ViewBag.Igv = (Convert.ToDouble(calcularIGV(Total))).ToString("N2");
            ViewBag.Total = Total;
            ViewBag.Cantidad = Convert.ToInt32(dt.Rows.Count);
            ViewBag.mensaje = mensaje;
            return View();
        }

        public ActionResult ListarProductos()
        {
            List<Producto> lista = logProducto.Instancia.ListarProducto();
            return View(lista);
        }

        public ActionResult ListarDistribuidor()
        {
            List<Distribuidor> lista = logDistribuidor.Instancia.listarDistribuidor();
            return View(lista);
        }

        public ActionResult SeleccionaDistribuidor(FormCollection frm)
        {
            Session.Remove("distribuidor");
            if (Session["distribuidor"] == null) { CrearDistribuidor(); }
            DataTable dt = (DataTable)Session["distribuidor"];
            Boolean Existe = false;
            foreach (DataRow f in dt.Rows)
            {
                if (Convert.ToInt16(frm["txtIdDistribuidor"]) == Convert.ToInt16(f["idDistribuidor"]))
                {
                    Existe = true;
                    break;
                }
            }
            if (!Existe)
            {
                DataRow r = dt.NewRow();
                r["idDistribuidor"] = Convert.ToInt16(frm["txtIdDistribuidor"]);
                r["RazonSocial"] = frm["txtRazonSocial"].ToString();
                r["RUC"] = frm["txtRuc"].ToString();
                dt.Rows.Add(r);
                return RedirectToAction("GuiaSalida");
            }
            else { return RedirectToAction("GuiaSalida"); }
        }



        public ActionResult AgregarSalida(FormCollection frm)
        {
            try
            {
                if (Convert.ToInt16(frm["txtStock"]) < Convert.ToInt16(frm["txtCant"]))
                {
                    ViewBag.mensajito = "Lo sentimos! la cantidad debe ser menor o igual al stock";
                    List<Producto> lista = logProducto.Instancia.ListarProducto();
                    return View("ListarProductos", lista);
                }
                else
                {
                    if (Session["remision"] == null) { Crearguiaremision(); }
                    DataTable dt = (DataTable)Session["remision"];
                    Boolean Existe = false;
                    foreach (DataRow f in dt.Rows)
                    {
                        Decimal It = Convert.ToDecimal(frm["txtCant"]);
                        Decimal pr = Convert.ToDecimal(frm["txtPrecio"]);
                        if (Convert.ToInt16(frm["txtidProducto"]) == Convert.ToInt16(f["idProducto"]))
                        {
                            Existe = true;
                            f["Cantidad"] = It + Convert.ToInt16(f["Cantidad"]);
                            f["Importe"] = Convert.ToInt16(f["Cantidad"]) * pr;
                            dt.AcceptChanges();
                            break;
                        }
                    }
                    Session["remision"] = dt;
                    if (!Existe)
                    {
                        DataRow r = dt.NewRow();
                        r["idProducto"] = Convert.ToInt16(frm["txtidProducto"]);
                        r["Nombre"] = frm["txtNombre"].ToString();
                        r["Precio"] = Convert.ToDecimal(frm["txtPrecio"]);
                        r["Stock"] = Convert.ToInt16(frm["txtStock"]);
                        r["Cantidad"] = Convert.ToInt16(frm["txtCant"]);
                        r["Importe"] = Convert.ToInt16(frm["txtCant"]) * Convert.ToDecimal(frm["txtPrecio"]);
                        dt.Rows.Add(r);
                        return RedirectToAction("GuiaSalida");
                    }
                    else { return RedirectToAction("GuiaSalida"); }
                }
            }
            catch (Exception e) { throw e; }
        }

        public ActionResult ModificarCantidad(FormCollection frm)
        {
            DataTable dt = (DataTable)Session["remision"];
            foreach (DataRow f in dt.Rows)
            {

                Decimal pr = Convert.ToDecimal(frm["txtPrecio"]);
                Decimal can = Convert.ToDecimal(frm["txtcant"]);
                Int16 id = Convert.ToInt16(frm["txtIdProd"]);
                if (Convert.ToInt16(frm["txtIdProd"]) == Convert.ToInt16(f["idProducto"]))
                {
                    if (Convert.ToInt16(frm["txtcant"]) > Convert.ToInt16(f["Stock"]))
                    {
                        return RedirectToAction("GuiaSalida", new { mensaje = "Lo sentimos! Cantidad debe ser menor o igual al stock"});
                    }
                    else
                    {
                        f["Cantidad"] = can;
                        f["Importe"] = can * pr;
                        dt.AcceptChanges();
                        break;
                    }
                }
            }
            Session["remision"] = dt;
            return RedirectToAction("GuiaSalida");
        }

        public ActionResult QuitarProducto(String id)
        {
            DataTable dt = (DataTable)Session["remision"];
            foreach (DataRow f in dt.Rows)
            {
                if (Convert.ToInt16(id) == Convert.ToInt16(f["idProducto"]))
                {
                    f.Delete();
                    dt.AcceptChanges();
                    break;
                }
            }
            Session["remision"] = dt;
            ViewBag.mensajito = "El producto ha sido Eliminado de la guia";
            return RedirectToAction("GuiaSalida");
        }

        public ActionResult RegistrarGuiarSalida()
        {
            int cod = 0;
            try
            {
                DataTable dt = (DataTable)Session["remision"];
                DataTable dtc = (DataTable)Session["distribuidor"];

                Int16 idDistribuidor = 0;
                foreach (DataRow d in dtc.Rows)
                {
                    idDistribuidor = Convert.ToInt16(d["idDistribuidor"]);
                }
                Guiaremision guia = new Guiaremision();
                guia.Total = calcularImporteTotal(dt);
                foreach (DataRow r in dt.Rows)
                {
                    guia.Codigo = "00"+Convert.ToString(cod++);
                    guia.IGV = Math.Round(calcularIGV(guia.Total));
                    guia.usuario = (Usuario)Session["usuario"];
                    guia.distribuidor = idDistribuidor;
                }
                List<DetGuiaRem> det = new List<DetGuiaRem>();
                foreach (DataRow d in dt.Rows)
                {
                    DetGuiaRem de = new DetGuiaRem();
                    de.Cantidad = Convert.ToInt16(d["Cantidad"]);
                    de.Precio = Convert.ToDecimal(d["Precio"]);
                    de.Subtotal = Convert.ToDecimal(d["Importe"]);
                    Producto pr = new Producto();
                    pr.idProducto = Convert.ToInt16(d["idProducto"]);
                    de.producto = pr;
                    det.Add(de);
                }
                guia.detalle = det;
                Int32 remision = logGuiaremision.Instancia.InsertarGuiaremision(guia);
                Session["remision"] = null;
                Session["distribuidor"] = null;
                return RedirectToAction("GuiaSalida", new { mensaje = "Se registro sastifactoriamente la guia de salida"});
            }
            catch (Exception e) { throw e; }

        }

        public Decimal calcularIGV(Decimal Total)
        {
            Decimal rpta = 0;
            rpta = Math.Abs((Total / Convert.ToDecimal(1.18))-Total);
            return rpta;
        }

        public Decimal calcularSubTotal(Decimal Total)
        {
            Decimal rpta = 0;
            rpta = Total - (Total - Total / Convert.ToDecimal(1.18));
            return rpta;
        }

        public Decimal calcularImporteTotal(DataTable dt)
        {
            Decimal rpta = 0;
            foreach (DataRow f in dt.Rows)
            {
                rpta += Convert.ToDecimal(f["Importe"]);
            }
            return rpta;
        }



    }
}
