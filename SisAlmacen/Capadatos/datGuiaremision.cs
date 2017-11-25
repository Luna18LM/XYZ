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
    public class datGuiaremision
    {
        #region Singleton

        private static readonly datGuiaremision _instancia = new datGuiaremision();

        public static datGuiaremision Instancia
        {
            get { return datGuiaremision._instancia; }
        }

        #endregion singleton

        #region metodos

        public Int32 InsertarGuiaremision(String cadXML) {
            SqlCommand cmd = null;
            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("InsertarGuiaremision", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prstmrXML", cadXML);

                SqlParameter m = new SqlParameter("@retorno", DbType.Int32);
                m.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(m);

                cn.Open();
                cmd.ExecuteNonQuery();
                Int32 i = Convert.ToInt32(cmd.Parameters["@retorno"].Value);
                return i;
                    
            }
            catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }
        }

        public List<Guiaremision> ReporteGuiaSalida()
        {
            SqlCommand cmd = null;
            List<Guiaremision> lista = new List<Guiaremision>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("ReporteSalida", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Guiaremision g = new Guiaremision();
                    g.idGuiaRemi = Convert.ToInt16(dr["idGuiaRemi"]);
                    g.Codigo = dr["Codigo"].ToString();
                    g.FechaSalida = Convert.ToDateTime(dr["FechaSalida"]);
                    g.Total = Convert.ToDecimal(dr["Total"]);
                    g.IGV = Convert.ToDecimal(dr["IGV"]);
                    g.distribuidor = Convert.ToInt16(dr["idDistribuidor"]);
                    g.nomDistribuidor = dr["RazonSocial"].ToString();
                    g.Ruc = dr["Ruc"].ToString();
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

        public List<Guiaremision> ListarSalidaParametros(String Nombre, DateTime Fecha)
        {
            SqlCommand cmd = null;
            List<Guiaremision> lista = new List<Guiaremision>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("ReporteSalidaParametro", cn);
                cmd.Parameters.AddWithValue("@distribuidor", Nombre);
                cmd.Parameters.AddWithValue("@fecha", Fecha);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Guiaremision g = new Guiaremision();
                    g.idGuiaRemi = Convert.ToInt16(dr["idGuiaRemi"]);
                    g.Codigo = dr["Codigo"].ToString();
                    g.FechaSalida = Convert.ToDateTime(dr["FechaSalida"]);
                    g.Total = Convert.ToDecimal(dr["Total"]);
                    g.IGV = Convert.ToDecimal(dr["IGV"]);
                    g.distribuidor = Convert.ToInt16(dr["idDistribuidor"]);
                    g.nomDistribuidor = dr["RazonSocial"].ToString();
                    g.Ruc = dr["Ruc"].ToString();
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
