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
    public class logCorreo
    {
        #region Singleton

        public static readonly logCorreo _instancia = new logCorreo();

        public static logCorreo Instancia
        {
            get { return logCorreo._instancia; }
        }

        #endregion Singleton

        #region Metodos

        public Boolean InsertarCorreo(Correo c) {
            try{
                return datCorreo.Instancia.InsertarCorreo(c);
            }
            catch (Exception e) { throw e; }
        }

        #endregion metodos

    }
}
