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
    public class datCategoria
    {
        #region Singleton

        public static readonly datCategoria _instancia = new datCategoria();

        public static datCategoria Instancia
        {
            get { return datCategoria._instancia; }
        }

        #endregion Singleton

        #region Metodos

        public List<Categoria> ListarCategoria()
        {
            SqlCommand cmd = null; ;
            List<Categoria> lista = new List<Categoria>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("ListarCategoria", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Categoria c = new Categoria();
                    c.idCategoria = Convert.ToInt16(dr["idCategoria"]);
                    c.Nombre = dr["Nombre"].ToString();
                    c.Descripcion = dr["Descripcion"].ToString();
                    lista.Add(c);
                }
            }
            catch (Exception e) { throw e; }
            return lista;
        }

        public Boolean InsertarCategoria(Categoria c)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("InsertarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", c.Descripcion);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserto = true; }
            }
            catch (Exception e) { throw e; }
            return inserto;
        }

        public Categoria BuscarCategoria(Int16 idCategoria)
        {
            SqlCommand cmd = null;
            Categoria c = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("BuscarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    c = new Categoria();
                    c.idCategoria = Convert.ToInt16(dr["idCategoria"]);
                    c.Nombre = dr["Nombre"].ToString();
                    c.Descripcion = dr["Descripcion"].ToString();
                }
            }
            catch (Exception e) { throw e; }
            return c;
        }

        public Boolean EditarCategoria(Categoria c)
        {
            SqlCommand cmd = null;
            Boolean edito = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("EditarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", c.Descripcion);
                cmd.Parameters.AddWithValue("@idCategoria", c.idCategoria);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { edito = true; }
            }
            catch (Exception e) { throw e; }
            return edito;
        }

        public Boolean EliminarCategoria(Categoria c)
        {
            SqlCommand cmd = null;
            Boolean elimino = false;
            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("EliminarCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@estado", c.estado);
                cmd.Parameters.AddWithValue("@idCategoria", c.idCategoria);
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
