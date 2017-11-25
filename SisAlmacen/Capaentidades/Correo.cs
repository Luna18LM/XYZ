using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capaentidades
{
    public class Correo
    {
        public int idCorreo { get; set; }        
        public int idUsuario { get; set; }
        public String De { get; set; }
        public String Destinatario { get; set; }
        public String Asunto { get; set; }
        public String Contenido { get; set; }
        public DateTime FechaEnvio { get; set; }
        public Usuario usuario { get; set; }

    }
}
