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
    public class datTalla
    {
        #region Singleton

        public static readonly datTalla _instancia = new datTalla();

        public static datTalla Instancia
        {
            get { return datTalla._instancia; }
        }

        #endregion Singleton

        #region Metodos

        public List<Talla> ListarTalla()
        {
            SqlCommand cmd = null; ;
            List<Talla> lista = new List<Talla>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("ListarTalla", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Talla t = new Talla();
                    t.idTalla = Convert.ToInt16(dr["idTalla"]);
                    t.Nombre = dr["Nombre"].ToString();
                    t.Descripcion = dr["Descripcion"].ToString();
                    lista.Add(t);
                }
            }
            catch (Exception e) { throw e; }
            return lista;
        }

        public Boolean InsertarTalla(Talla t)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("InsertarTalla", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", t.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", t.Descripcion);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserto = true; }
            }
            catch (Exception e) { throw e; }
            return inserto;
        }

        public Talla BuscarTalla(Int16 idTalla)
        {
            SqlCommand cmd = null;
            Talla t = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("BuscarTalla", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTalla", idTalla);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    t = new Talla();
                    t.idTalla = Convert.ToInt16(dr["idTalla"]);
                    t.Nombre = dr["Nombre"].ToString();
                    t.Descripcion = dr["Descripcion"].ToString();
                }
            }
            catch (Exception e) { throw e; }
            return t;
        }

        public Boolean EditarTalla(Talla t)
        {
            SqlCommand cmd = null;
            Boolean edito = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("EditarTalla", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", t.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", t.Descripcion);
                cmd.Parameters.AddWithValue("@idTalla", t.idTalla);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { edito = true; }
            }
            catch (Exception e) { throw e; }
            return edito;
        }

        public Boolean EliminarTalla(Talla t)
        {
            SqlCommand cmd = null;
            Boolean elimino = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("EliminarTalla", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@estado", t.estado);
                cmd.Parameters.AddWithValue("@idTalla", t.idTalla);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { elimino = true; }
            }
            catch (Exception e) { throw e; }
            return elimino;
        }

        #endregion Metodos
    }
}
