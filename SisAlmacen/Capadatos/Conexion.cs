using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capadatos
{
    public class Conexion
    {
        #region singleton
        private static readonly Conexion _instancia = new Conexion();
        public static Conexion Instancia
        {
            get { return Conexion._instancia; }
        }
        #endregion singleton

        #region metodos
        public SqlConnection conectar()
        {
            SqlConnection cn = new SqlConnection();
            //cn.ConnectionString = "Data source=localhost;Initial Catalog=SisAlmacen; Integrated Security=true";
            //                   "Integrated Security=true";

            //cn.ConnectionString = "Data source=sisalmacenbd.cmdjfoqsbg9m.us-east-2.rds.amazonaws.com,1433;" +
            //    "Initial Catalog=SisAlmacen; " +
            //    "user=erikamalpica; password=Admin123;";

            //cn.ConnectionString = "Data source=tcp:almacenevo.database.windows.net,1433;" +
            //    "Initial Catalog=sysAlmacenEVO; " +
            //    "ID=Administrador; Password=Erika123;";

            cn.ConnectionString = "Data Source=sisalmacendb.cmdjfoqsbg9m.us-east-2.rds.amazonaws.com,1433;Initial Catalog=SisAlmacen;User ID=erika;Password=Admin123";



            return cn;
        }
        #endregion metodos
    }
}
