using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Capaentidades;
using Capadatos;

namespace Capalogica
{
    public class logTalla
    {
        #region Singleton

        public static readonly logTalla _instancia = new logTalla();

        public static logTalla Instancia
        {
            get { return logTalla._instancia; }
        }

        #endregion Singleton

        #region Metodos

        public List<Talla> ListarTalla()
        {
            try
            {
                return datTalla.Instancia.ListarTalla();
            }
            catch (Exception e) { throw e; }
        }

        public Boolean InsertarTalla(Talla t)
        {
            try
            {
                return datTalla.Instancia.InsertarTalla(t);
            }
            catch (Exception e) { throw e; }
        }

        public Talla BuscarTalla(Int16 idTalla)
        {
            try
            {
                return datTalla.Instancia.BuscarTalla(idTalla);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EditarTalla(Talla t)
        {
            try
            {
                return datTalla.Instancia.EditarTalla(t);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EliminarTalla(Talla t)
        {
            try
            {
                return datTalla.Instancia.EliminarTalla(t);
            }
            catch (Exception e) { throw e; }
        }

        #endregion Metodos
    }
}
