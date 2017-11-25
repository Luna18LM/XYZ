using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capaentidades
{
    public class Guiarecepcion
    {
        public int idGuiaRec { get; set; }
        public DateTime FechaEntrada { get; set; }
        public Usuario usuario { get; set; }
        public List<DetGuiaRec> Detalle { get; set; }
    }
}
