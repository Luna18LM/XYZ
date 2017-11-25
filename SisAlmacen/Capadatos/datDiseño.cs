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
    public class datDiseño
    {
        #region Singleton

        public static readonly datDiseño _instancia = new datDiseño();

        public static datDiseño Instancia
        {
            get { return datDiseño._instancia; }
        }

        #endregion Singleton

        #region Metodos

        public List<Diseño> ListarDiseño()
        {
            SqlCommand cmd = null; ;
            List<Diseño> lista = new List<Diseño>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("ListarDiseño", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Diseño d = new Diseño();
                    d.idDiseño = Convert.ToInt16(dr["idDiseño"]);
                    d.Nombre = dr["Nombre"].ToString();
                    d.Descripcion = dr["Descripcion"].ToString();
                    lista.Add(d);
                }
            }
            catch (Exception e) { throw e; }
            return lista;
        }

        public Boolean InsertarDiseño(Diseño d)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("InsertarDiseño", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", d.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", d.Descripcion);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserto = true; }
            }
            catch (Exception e) { throw e; }
            return inserto;
        }

        public Diseño BuscarDiseño(Int16 idDiseño)
        {
            SqlCommand cmd = null;
            Diseño d = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("BuscarDiseño", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDiseño", idDiseño);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    d = new Diseño();
                    d.idDiseño = Convert.ToInt16(dr["idDiseño"]);
                    d.Nombre = dr["Nombre"].ToString();
                    d.Descripcion = dr["Descripcion"].ToString();
                }
            }
            catch (Exception e) { throw e; }
            return d;
        }

        public Boolean EditarDiseño(Diseño d)
        {
            SqlCommand cmd = null;
            Boolean edito = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("EditarDiseño", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", d.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", d.Descripcion);
                cmd.Parameters.AddWithValue("@idDiseño", d.idDiseño);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { edito = true; }
            }
            catch (Exception e) { throw e; }
            return edito;
        }

        public Boolean EliminarDiseño(Diseño d)
        {
            SqlCommand cmd = null;
            Boolean elimino = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("EliminarDiseño", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@estado", d.estado);
                cmd.Parameters.AddWithValue("@idDiseño", d.idDiseño);
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
