using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capaentidades;

namespace Capadatos
{
    public class datCorreo
    {
        #region Singleton

        public static readonly datCorreo _instancia = new datCorreo();

        public static datCorreo Instancia
        {
            get { return datCorreo._instancia; }
        }

        #endregion Singleton

        #region metodos

        public Boolean InsertarCorreo(Correo c) {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("InsertarCorreo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", c.idUsuario);
                cmd.Parameters.AddWithValue("@De", c.De);
                cmd.Parameters.AddWithValue("@Destinatario", c.Destinatario);
                cmd.Parameters.AddWithValue("@Asunto", c.Asunto);
                cmd.Parameters.AddWithValue("@Contenido", c.Contenido);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserto = true; }
            }
            catch (Exception e) { throw e; }
            return inserto;
        }

        #endregion metodos
    }
}
