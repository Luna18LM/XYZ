using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Capaentidades;
using Capadatos;

namespace Capalogica
{
    public class logColor
    {
        //#region Singleton

        //public static readonly logColor _instancia = new logColor();

        //public static logColor Instancia
        //{
        //    get { return logColor._instancia; }
        //}

        //#endregion Singleton

        #region Metodos

        public static List<Color> ListarColor()
        {
            try
            {
                return datColor.ListarColor();
            }
            catch (Exception e) { throw e; }
        }

        public static Boolean InsertarColor(Color c)
        {
            try
            {
                //return datColor.Instancia.InsertarColor(c);
                return datColor.InsertarColor(c);
            }
            catch (Exception e) { throw e; }
        }

        public static Color BuscarColor(Int16 idColor)
        {
            try
            {
                return datColor.BuscarColor(idColor);
            }
            catch (Exception e) { throw e; }
        }

        public static Boolean EditarColor(Color c)
        {
            try
            {
                return datColor.EditarColor(c);
            }
            catch (Exception e) { throw e; }
        }

        public static Boolean EliminarColor(Color c)
        {
            try
            {
                return datColor.EliminarColor(c);
            }
            catch (Exception e) { throw e; }
        }


        #endregion Metodos
    }
}
