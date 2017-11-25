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
    public class datColor
    {
        //#region Singleton

        //public static readonly datColor _instancia = new datColor();

        //public static datColor Instancia
        //{
        //    get { return datColor._instancia; }
        //}

        //#endregion Singleton

        #region Metodos

        public static List<Color> ListarColor()
        {
            SqlCommand cmd = null; ;
            List<Color> lista = new List<Color>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("ListarColor", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Color c = new Color();
                    c.idColor = Convert.ToInt16(dr["idColor"]);
                    c.Nombre = dr["Nombre"].ToString();
                    c.Descripcion = dr["Descripcion"].ToString();
                    lista.Add(c);
                }
            }
            catch (Exception e) { throw e; }
            return lista;
        }

        public static Boolean InsertarColor(Color c)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("InsertarColor", cn);
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

        public static Color BuscarColor(Int16 idColor)
        {
            SqlCommand cmd = null;
            Color c = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("BuscarColor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idColor", idColor);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    c = new Color();
                    c.idColor = Convert.ToInt16(dr["idColor"]);
                    c.Nombre = dr["Nombre"].ToString();
                    c.Descripcion = dr["Descripcion"].ToString();
                }
            }
            catch (Exception e) { throw e; }
            return c;
        }

        public static Boolean EditarColor(Color c)
        {
            SqlCommand cmd = null;
            Boolean edito = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("EditarColor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", c.Descripcion);
                cmd.Parameters.AddWithValue("@idColor", c.idColor);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { edito = true; }
            }
            catch (Exception e) { throw e; }
            return edito;
        }

        public static Boolean EliminarColor(Color c)
        {
            SqlCommand cmd = null;
            Boolean elimino = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("EliminarColor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@estado", c.estado);
                cmd.Parameters.AddWithValue("@idColor", c.idColor);
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
