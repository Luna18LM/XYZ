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
    public class logDistribuidor
    {
        #region Singleton

        public static readonly logDistribuidor _instancia = new logDistribuidor();

        public static logDistribuidor Instancia
        {
            get { return logDistribuidor._instancia; }
        }

        #endregion Singleton

        #region Metodo

        public List<Distribuidor> listarDistribuidor()
        {
            try
            {
                return datDistribuidor.Instancia.ListarDistribuidor();
            }
            catch (Exception e) { throw e; }
        }

        public Boolean InsertarDistribuidor(Distribuidor d)
        {
            try
            {
                return datDistribuidor.Instancia.InsertarDistribuidor(d);
            }
            catch (Exception e) { throw e; }
        }

        public Distribuidor BuscarDistribuidor(Int16 idDistribuidor)
        {
            try
            {
                return datDistribuidor.Instancia.BuscarDistribuidor(idDistribuidor);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EditarDistribuidor(Distribuidor d)
        {
            try
            {
                return datDistribuidor.Instancia.EditarDistribuidor(d);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EliminarDistribuidor(Distribuidor d)
        {
            try
            {
                return datDistribuidor.Instancia.EliminarDistribuidor(d);
            }
            catch (Exception e) { throw e; }
        }
        #endregion Metodo
    }
}
