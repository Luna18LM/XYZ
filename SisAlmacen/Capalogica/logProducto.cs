using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capaentidades;
using Capadatos;

namespace Capalogica
{
    public class logProducto
    {
        #region Singleton

        public static readonly logProducto _instancia = new logProducto();

        public static logProducto Instancia
        {
            get { return logProducto._instancia; }
        }

        #endregion Singleton

        #region Metodos

        public List<Producto> ListarProducto()
        {
            try
            {
                return datProducto.Instancia.ListarProducto();
            }
            catch (Exception e) { throw e; }
        }

        public Boolean InsertarProducto(Producto p)
        {
            try
            {
                return datProducto.Instancia.InsertarProducto(p);
            }
            catch (Exception e) { throw e; }
        }

        public Producto BuscarProducto(Int16 idProducto)
        {
            try
            {
                return datProducto.Instancia.BuscarProducto(idProducto);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EditarProducto(Producto p)
        {
            try
            {
                return datProducto.Instancia.EditarProducto(p);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EliminarProducto(Producto p)
        {
            try
            {
                return datProducto.Instancia.EliminoProducto(p);
            }
            catch (Exception e) { throw e; }
        }

        public List<Producto> Listarproductonombre(String Nombre) {
            try {
                return datProducto.Instancia.ListarProductonombre(Nombre);
            }
            catch (Exception e) { throw e; }
        }

        public List<Producto> ReporteMinStockProducto() {
            try {
                return datProducto.Instancia.ReporteStockMinProducto();
            }
            catch (Exception e) { throw e; }
        }
        #endregion Metodos
    }
}
