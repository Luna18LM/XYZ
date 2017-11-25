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
    public class logCategoria
    {
        #region Singleton

        public static readonly logCategoria _instancia = new logCategoria();

        public static logCategoria Instancia
        {
            get { return logCategoria._instancia; }
        }

        #endregion Singleton

        #region Metodos

        public List<Categoria> ListarCategoria()
        {
            try
            {
                return datCategoria.Instancia.ListarCategoria();
            }
            catch (Exception e) { throw e; }
        }

        public Boolean InsertarCategoria(Categoria c)
        {
            try
            {
                return datCategoria.Instancia.InsertarCategoria(c);
            }
            catch (Exception e) { throw e; }
        }

        public Categoria BuscarCategoria(Int16 idCategoria)
        {
            try
            {
                return datCategoria.Instancia.BuscarCategoria(idCategoria);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EditarCategoria(Categoria c)
        {
            try
            {
                return datCategoria.Instancia.EditarCategoria(c);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EliminarCategoria(Categoria c)
        {
            try {
                return datCategoria.Instancia.EliminarCategoria(c);
            }
            catch (Exception e) { throw e; }
        }

        #endregion Metodos
    }
}
