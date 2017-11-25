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
    public class logDiseño
    {
        #region Singleton

        public static readonly logDiseño _instancia = new logDiseño();

        public static logDiseño Instancia
        {
            get { return logDiseño._instancia; }
        }

        #endregion Singleton

        #region Metodos

        public List<Diseño> ListarDiseño()
        {
            try
            {
                return datDiseño.Instancia.ListarDiseño();
            }
            catch (Exception e) { throw e; }
        }

        public Boolean InsertarDiseño(Diseño d)
        {
            try
            {
                return datDiseño.Instancia.InsertarDiseño(d);
            }
            catch (Exception e) { throw e; }
        }

        public Diseño BuscarDiseño(Int16 idDiseño)
        {
            try
            {
                return datDiseño.Instancia.BuscarDiseño(idDiseño);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EditarDiseño(Diseño d)
        {
            try
            {
                return datDiseño.Instancia.EditarDiseño(d);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EliminarDiseño(Diseño d)
        {
            try
            {
                return datDiseño.Instancia.EliminarDiseño(d);
            }
            catch (Exception e) { throw e; }
        }

        #endregion Metodos
    }
}
