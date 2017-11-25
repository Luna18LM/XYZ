using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Capaentidades;

namespace Capadatos
{
    public class datGuiarecepcion
    {
        #region Singleton
        private static readonly datGuiarecepcion _instancia = new datGuiarecepcion();

        public static datGuiarecepcion Instancia
        { get { return datGuiarecepcion._instancia; } }

        #endregion Singleton

        #region metodos

        public Int32 SubirGuiarecepcion(String cadXML)
        {
            SqlCommand cmd = null;
            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("InsertarGuiarecepcion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prstmrXML", cadXML);
                
                //creamos un parametro de retorno
                SqlParameter p = new SqlParameter("@retorno", DbType.Int32);
                p.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(p);

                cn.Open();
                cmd.ExecuteNonQuery();
                Int32 i = Convert.ToInt32(cmd.Parameters["@retorno"].Value);
                return i;
            }
            catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }
        }

        public List<Guiarecepcion> ReporteGuia() {
            SqlCommand cmd = null;
            List<Guiarecepcion> lista = new List<Guiarecepcion>();
            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("ReporteGuiaRecepcion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read()){
                    Guiarecepcion g = new Guiarecepcion();
                    g.idGuiaRec = Convert.ToInt16(dr["idGuiaRec"]);
                    g.FechaEntrada = Convert.ToDateTime(dr["FechaEntrada"]);
                    Usuario u = new Usuario();
                    u.idUsuario = Convert.ToInt16(dr["idUsuario"]);
                    u.Nombre = dr["Nombre"].ToString();
                    u.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
                    u.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
                    g.usuario = u;
                    lista.Add(g);
                }
            }
            catch (Exception e) { throw e; }
            return lista;
        }

        public List<Guiarecepcion> ListarProductoParametros(String Nombre, DateTime Fecha) {
            SqlCommand cmd = null;
            List<Guiarecepcion> lista = new List<Guiarecepcion>();
            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("ReporteRecepcionparametro", cn);
                cmd.Parameters.AddWithValue("@nombre", Nombre);
                cmd.Parameters.AddWithValue("@fechaentrada", Fecha);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Guiarecepcion g = new Guiarecepcion();
                    g.idGuiaRec = Convert.ToInt16(dr["idGuiaRec"]);
                    g.FechaEntrada = Convert.ToDateTime(dr["FechaEntrada"]);
                    Usuario u = new Usuario();
                    u.idUsuario = Convert.ToInt16(dr["idUsuario"]);
                    u.Nombre = dr["Nombre"].ToString();
                    u.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
                    u.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
                    g.usuario = u;
                    lista.Add(g);
                }
            }
            catch (Exception e) { throw e; }
            return lista;
        }
        #endregion metodos
    }
}
