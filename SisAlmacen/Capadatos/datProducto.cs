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
    public class datProducto
    {
        #region Singleton

        public static readonly datProducto _instancia = new datProducto();

        public static datProducto Instancia
        {
            get { return datProducto._instancia; }
        }

        #endregion Singleton

        #region Metodos

        public List<Producto> ListarProducto()
        {
            SqlCommand cmd = null;
            List<Producto> lista = new List<Producto>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("ListarProducto", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto p = new Producto();
                    p.idProducto = Convert.ToInt16(dr["idProducto"]);
                    p.Nombre = dr["Nombre"].ToString();
                    p.Precio = Convert.ToDecimal(dr["Precio"]);
                    p.Stock = Convert.ToInt16(dr["Stock"]);
                    p.Serie = dr["Serie"].ToString();
                    p.Descripcion = dr["Descripcion"].ToString();
                    p.Imagen = dr["Imagen"].ToString();
                    p.estado = dr["estado"].ToString();
                    Categoria c = new Categoria();
                    c.idCategoria = Convert.ToInt16(dr["idCategoria"]);
                    c.Nombre = dr["DNombre"].ToString();
                    c.Descripcion = dr["DCategoria"].ToString();
                    p.categoria = c;
                    Talla t = new Talla();
                    t.idTalla = Convert.ToInt16(dr["idTalla"]);
                    t.Nombre = dr["TNombre"].ToString();
                    t.Descripcion = dr["TDescripcion"].ToString();
                    p.talla = t;
                    Diseño d = new Diseño();
                    d.idDiseño = Convert.ToInt16(dr["idDiseño"]);
                    d.Nombre = dr["DINombre"].ToString();
                    d.Descripcion = dr["DIDescripcion"].ToString();
                    p.diseño = d;
                    Color co = new Color();
                    co.idColor = Convert.ToInt16(dr["idColor"]);
                    co.Nombre = dr["CONombre"].ToString();
                    co.Descripcion = dr["CODescripcion"].ToString();
                    p.color = co;
                    lista.Add(p);
                }
            }
            catch (Exception e) { throw e; }
            return lista;
        }

        public Boolean InsertarProducto(Producto p)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("InsertarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@Serie", p.Serie);
                cmd.Parameters.AddWithValue("@Precio", p.Precio);
                cmd.Parameters.AddWithValue("@Stock", p.Stock);
                cmd.Parameters.AddWithValue("@Descripcion", p.Descripcion);
                cmd.Parameters.AddWithValue("@Imagen", p.Imagen);
                cmd.Parameters.AddWithValue("@idCategoria", p.categoria.idCategoria);
                cmd.Parameters.AddWithValue("@idTalla", p.talla.idTalla);
                cmd.Parameters.AddWithValue("@idDiseño", p.diseño.idDiseño);
                cmd.Parameters.AddWithValue("@idColor", p.color.idColor);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserto = true; }
            }
            catch (Exception e) { throw e; }
            return inserto;
        }

        public Producto BuscarProducto(Int16 idProducto)
        {
            SqlCommand cmd = null;
            Producto p = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("BuscarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    p = new Producto();
                    p.idProducto = Convert.ToInt16(dr["idProducto"]);
                    p.Nombre = dr["Nombre"].ToString();
                    p.Precio = Convert.ToDecimal(dr["Precio"]);
                    p.Stock = Convert.ToInt16(dr["Stock"]);
                    p.Serie = dr["Serie"].ToString();
                    p.Descripcion = dr["Descripcion"].ToString();
                    p.Imagen = dr["Imagen"].ToString();
                    p.estado = dr["estado"].ToString();
                    Categoria c = new Categoria();
                    c.idCategoria = Convert.ToInt16(dr["idCategoria"]);
                    c.Nombre = dr["DNombre"].ToString();
                    c.Descripcion = dr["DCategoria"].ToString();
                    p.categoria = c;
                    Talla t = new Talla();
                    t.idTalla = Convert.ToInt16(dr["idTalla"]);
                    t.Nombre = dr["TNombre"].ToString();
                    t.Descripcion = dr["TDescripcion"].ToString();
                    p.talla = t;
                    Diseño d = new Diseño();
                    d.idDiseño = Convert.ToInt16(dr["idDiseño"]);
                    d.Nombre = dr["DINombre"].ToString();
                    d.Descripcion = dr["DIDescripcion"].ToString();
                    p.diseño = d;
                    Color co = new Color();
                    co.idColor = Convert.ToInt16(dr["idColor"]);
                    co.Nombre = dr["CONombre"].ToString();
                    co.Descripcion = dr["CODescripcion"].ToString();
                    p.color = co;
                }
            }
            catch (Exception e) { throw e; }
            return p;
        }

        public Boolean EditarProducto(Producto p)
        {
            SqlCommand cmd = null;
            Boolean edito = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("EditarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@Serie", p.Serie);
                cmd.Parameters.AddWithValue("@Precio", p.Precio);
                cmd.Parameters.AddWithValue("@Stock", p.Stock);
                cmd.Parameters.AddWithValue("@Descripcion", p.Descripcion);
                cmd.Parameters.AddWithValue("@Imagen", p.Imagen);
                cmd.Parameters.AddWithValue("@idCategoria", p.categoria.idCategoria);
                cmd.Parameters.AddWithValue("@idTalla", p.talla.idTalla);
                cmd.Parameters.AddWithValue("@idDiseño", p.diseño.idDiseño);
                cmd.Parameters.AddWithValue("@idColor", p.color.idColor);
                cmd.Parameters.AddWithValue("@idProducto", p.idProducto);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { edito = true; }
            }
            catch (Exception e) { throw e; }
            return edito;
        }

        public Boolean EliminoProducto(Producto p)
        {
            SqlCommand cmd = null;
            Boolean elimino = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("EliminarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@estado", p.estado);
                cmd.Parameters.AddWithValue("@idProducto", p.idProducto);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { elimino = true; }
            }
            catch (Exception e) { throw e; }
            return elimino;
        }

        public List<Producto> ListarProductonombre(String Nombre) {
            
            SqlCommand cmd = null;
            List<Producto> lista = new List<Producto>();
            
            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("listarproductopornombre", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    Producto p = new Producto();
                    p.idProducto = Convert.ToInt16(dr["idProducto"]);
                    p.Nombre = dr["Nombre"].ToString();
                    p.Precio = Convert.ToDecimal(dr["Precio"]);
                    p.Stock = Convert.ToInt16(dr["Stock"]);
                    p.Serie = dr["Serie"].ToString();
                    p.Descripcion = dr["Descripcion"].ToString();
                    p.Imagen = dr["Imagen"].ToString();
                    p.estado = dr["estado"].ToString();
                    Categoria c = new Categoria();
                    c.idCategoria = Convert.ToInt16(dr["idCategoria"]);
                    c.Nombre = dr["DNombre"].ToString();
                    c.Descripcion = dr["DCategoria"].ToString();
                    p.categoria = c;
                    Talla t = new Talla();
                    t.idTalla = Convert.ToInt16(dr["idTalla"]);
                    t.Nombre = dr["TNombre"].ToString();
                    t.Descripcion = dr["TDescripcion"].ToString();
                    p.talla = t;
                    Diseño d = new Diseño();
                    d.idDiseño = Convert.ToInt16(dr["idDiseño"]);
                    d.Nombre = dr["DINombre"].ToString();
                    d.Descripcion = dr["DIDescripcion"].ToString();
                    p.diseño = d;
                    Color co = new Color();
                    co.idColor = Convert.ToInt16(dr["idColor"]);
                    co.Nombre = dr["CONombre"].ToString();
                    co.Descripcion = dr["CODescripcion"].ToString();
                    p.color = co;
                    lista.Add(p);
                }
            }
            catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public List<Producto> ReporteStockMinProducto() {
            SqlCommand cmd = null;
            List<Producto> lista = new List<Producto>();
            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("ReporteStockminProducto", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto p = new Producto();
                    p.idProducto = Convert.ToInt16(dr["idProducto"]);
                    p.Nombre = dr["Nombre"].ToString();
                    p.Precio = Convert.ToDecimal(dr["Precio"]);
                    p.Stock = Convert.ToInt16(dr["Stock"]);
                    p.Serie = dr["Serie"].ToString();
                    p.Descripcion = dr["Descripcion"].ToString();
                    p.Imagen = dr["Imagen"].ToString();
                    p.estado = dr["estado"].ToString();
                    Categoria c = new Categoria();
                    c.idCategoria = Convert.ToInt16(dr["idCategoria"]);
                    c.Nombre = dr["DNombre"].ToString();
                    c.Descripcion = dr["DCategoria"].ToString();
                    p.categoria = c;
                    Talla t = new Talla();
                    t.idTalla = Convert.ToInt16(dr["idTalla"]);
                    t.Nombre = dr["TNombre"].ToString();
                    t.Descripcion = dr["TDescripcion"].ToString();
                    p.talla = t;
                    Diseño d = new Diseño();
                    d.idDiseño = Convert.ToInt16(dr["idDiseño"]);
                    d.Nombre = dr["DINombre"].ToString();
                    d.Descripcion = dr["DIDescripcion"].ToString();
                    p.diseño = d;
                    Color co = new Color();
                    co.idColor = Convert.ToInt16(dr["idColor"]);
                    co.Nombre = dr["CONombre"].ToString();
                    co.Descripcion = dr["CODescripcion"].ToString();
                    p.color = co;
                    lista.Add(p);
                }
            }
            catch (Exception e) { throw e; }
            return lista;
        }


        #endregion Metodos
    }
}
