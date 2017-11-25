using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capadatos;
using Capaentidades;
using System.Data;
using System.Data.SqlClient;

namespace Capalogica
{
    public class logUsuario
    {
        #region Singleton
        private static readonly logUsuario _instancia = new logUsuario();

        public static logUsuario Instancia
        {
            get { return logUsuario._instancia; }
        }
        #endregion Singleton

        #region Metodos
        public Usuario VerificarAcceso(String usuario, String contasena)
        {
            try
            {
                return datUsuario.Instancia.VerificarUAcceso(usuario, contasena);
            }
            catch (Exception e) { throw e; }
        }

        public Usuario BuscarUsuario(Int16 idUsuario) {
            try {
                return datUsuario.Instancia.BuscarUsuario(idUsuario);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EditarUsuario(Usuario u) {
            try {
                return datUsuario.Instancia.EditarUsuario(u);
            }
            catch (Exception e) { throw e; }
        }

        public List<Usuario> listarUsuario() {
            try {
                return datUsuario.Instancia.listarUsuario();
            }
            catch (Exception e) { throw e; }
        }

        #endregion Metodos
    }
}
