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
    public class datUsuario
    {
        #region Singleton
        private static readonly datUsuario _instancia = new datUsuario();
        public static datUsuario Instancia
        {
            get { return datUsuario._instancia; }
        }
        #endregion Singleton


        #region Metodos
        public Usuario VerificarUAcceso(String usuario, String contasena)
        {
            SqlCommand cmd = null;
            Usuario u = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spVerificarAcceso", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrUsuario", usuario);
                cmd.Parameters.AddWithValue("@prmstrContasena", contasena);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    u = new Usuario();
                    u.idUsuario = Convert.ToInt16(dr["idUsuario"]);
                    u.Nombre = dr["Nombre"].ToString();
                    u.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
                    u.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
                    u.dni = dr["dni"].ToString();
                    u.eusuario = dr["Usuario"].ToString();
                    u.Contasena = dr["Contasena"].ToString();
                    u.Fechanacimiento = Convert.ToDateTime(dr["Fechanacimiento"]);
                    u.Direccion = dr["Direccion"].ToString();
                    u.Email = dr["Email"].ToString();
                    u.fotografia = dr["fotografia"].ToString();
                }
            }
            catch (Exception e) { throw e; }
            return u;
        }

        public Usuario BuscarUsuario(Int16 idUsuario) {
            SqlCommand cmd = null;
            Usuario u = null;

            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("BuscarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) {
                    u = new Usuario();
                    u.idUsuario = Convert.ToInt16(dr["idUsuario"]);
                    u.Nombre = dr["Nombre"].ToString();
                    u.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
                    u.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
                    u.dni = dr["dni"].ToString();
                    u.eusuario = dr["Usuario"].ToString();
                    u.Contasena = dr["Contasena"].ToString();
                    u.Fechanacimiento = Convert.ToDateTime(dr["Fechanacimiento"]);
                    u.Direccion = dr["Direccion"].ToString();
                    u.Email = dr["Email"].ToString();
                    u.fotografia = dr["fotografia"].ToString();
                }
            }
            catch (Exception e) { throw e; }
            return u;
        }

        public Boolean EditarUsuario(Usuario u) {
            SqlCommand cmd = null;
            Boolean edito = false;
            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("EditarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@ApellidoP", u.ApellidoPaterno);
                cmd.Parameters.AddWithValue("@ApellidoM", u.ApellidoMaterno);
                cmd.Parameters.AddWithValue("@Dni", u.dni);
                cmd.Parameters.AddWithValue("@Contasena", u.Contasena);
                cmd.Parameters.AddWithValue("@Fecha", u.Fechanacimiento);
                cmd.Parameters.AddWithValue("@Direccion", u.Direccion);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@idUsuario", u.idUsuario);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { edito = true; }
            }
            catch (Exception e) { throw e; }
            return edito;
        }

        public List<Usuario> listarUsuario() {
            SqlCommand cmd = null;
            List<Usuario> lista = new List<Usuario>();
            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("listaUsuario", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    Usuario u = new Usuario();
                    u.idUsuario = Convert.ToInt16(dr["idUsuario"]);
                    u.Nombre = dr["Nombre"].ToString();
                    u.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
                    u.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
                    u.dni = dr["dni"].ToString();
                    u.Fechanacimiento = Convert.ToDateTime(dr["Fechanacimiento"]);
                    u.Direccion = dr["Direccion"].ToString();
                    u.Email = dr["Email"].ToString();
                    lista.Add(u);
                }
            }
            catch (Exception e) { throw e; }
            return lista;
        }

        #endregion Metodos
    }
}
