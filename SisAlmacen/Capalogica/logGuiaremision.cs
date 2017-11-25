using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capaentidades;
using Capadatos;
using System.Data.SqlClient;
using System.Data;

namespace Capalogica
{
    public class logGuiaremision
    {
        #region singleton
        private static readonly logGuiaremision _instancia = new logGuiaremision();
        public static logGuiaremision Instancia
        {
            get { return logGuiaremision._instancia; }
        }
        #endregion singleton

        #region metodos

        public Int32 InsertarGuiaremision(Guiaremision g)
        {
            try {
                String cadXML = "";
                cadXML += "<remision ";
                cadXML += "Codigo='" + g.Codigo + "' ";
                cadXML += "Total='" + g.Total + "' ";
                cadXML += "IGV='" + g.IGV + "' ";
                cadXML += "idUsuario='" + g.usuario.idUsuario + "' ";
                cadXML += "idDistribuidor='" + g.distribuidor + "'>";

                List<DetGuiaRem> detalle = g.detalle;
                foreach (var x in detalle)
                {
                    cadXML += "<detalle ";
                    cadXML += "idProducto='" + x.producto.idProducto + "' ";
                    cadXML += "precio='" + x.Precio + "' ";
                    cadXML += "Cantidad='" + x.Cantidad + "' ";
                    cadXML += "Subtotal='" + x.Subtotal + "'/>";
              
                }
                cadXML += "</remision>";
                cadXML = "<root>" + cadXML + "</root>";
                return datGuiaremision.Instancia.InsertarGuiaremision(cadXML);
            }

            catch (Exception e) { throw e; }
        }

        public List<Guiaremision> listaRemision() {
            try {
                return datGuiaremision.Instancia.ReporteGuiaSalida();
            }
            catch (Exception e) { throw e; }
        }
        public List<Guiaremision> ListarGuiaSalidaParametros(String Nombre, DateTime Fecha)
        {
            try
            {
                return datGuiaremision.Instancia.ListarSalidaParametros(Nombre, Fecha);
            }
            catch (Exception e) { throw e; }
        }

        #endregion metodos
    }
}
