using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capaentidades
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String dni { get; set; }
        public String eusuario { get; set; }
        public String Contasena { get; set; }
        public DateTime Fechanacimiento { get; set; }
        public String Direccion { get; set; }
        public String Email { get; set; }
        public String fotografia { get; set; }
    }
}
