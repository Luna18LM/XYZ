using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Capadatos;
using Capaentidades;

namespace Capalogica
{
    public class logGuiarecepcion
    {
        #region Singleton
        private static readonly logGuiarecepcion _instancia = new logGuiarecepcion();

        public static logGuiarecepcion Instancia {
            get { return logGuiarecepcion._instancia; }
        }

        #endregion Singleton

        #region Metodos
        public String formarCadXMLPrincipal(Guiarecepcion g)
        {
            return ("<Guia " + "idUsuario='" + g.usuario.idUsuario + "'>");
        }

        public Int32 InsertarGuiarecepcion(Guiarecepcion g){
            try {

                //String cadXML = "";
                //cadXML += "<Guia ";
                //cadXML += "idUsuario='" + g.usuario.idUsuario + "'>";

                String cadXML = "";
                cadXML += "<Guia ";
                cadXML += "idUsuario='" + g.usuario.idUsuario + "'>";

                List<DetGuiaRec> detalle = g.Detalle;
                foreach (DetGuiaRec d in detalle) {
                    cadXML += "<Detalle ";
                    cadXML += "idProducto='" + d.producto.idProducto + "' ";
                    cadXML += "Cantidad ='" + d.Cantidad + "' ";
                    cadXML += "Precio ='" + d.Precio + "' ";
                    cadXML += "observacion='" + d.Observacion + "'/>";
                }
                cadXML += "</Guia>";
                cadXML = "<root>" + cadXML + "</root>";
                return datGuiarecepcion.Instancia.SubirGuiarecepcion(cadXML);
                //eso se refiere que como se usa en vrios se debe hacer un objeto que se llene
            }
            catch (Exception e) { throw e; }
        }

        public List<Guiarecepcion> ReporteGuiaRecepcion() {
            try {
                return datGuiarecepcion.Instancia.ReporteGuia();
            }
            catch (Exception e) { throw e; }
        }

        public List<Guiarecepcion> ListarProductoParametros(String Nombre,DateTime Fecha)
        {
            try
            {
                return datGuiarecepcion.Instancia.ListarProductoParametros(Nombre, Fecha);
            }
            catch (Exception e) { throw e; }
        }
        #endregion Metodos

    }
}
