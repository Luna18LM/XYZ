using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capaentidades
{
    public class Guiaremision
    {
        public int idGuiaRemi { get; set; }
        public String Codigo { get; set; }
        public DateTime FechaSalida { get; set; }
        public decimal Total { get; set; }
        public decimal IGV { get; set; }
        public Usuario usuario { get; set; }
        public int distribuidor { get; set; }
        public String nomDistribuidor { get; set; }
        public String Ruc { get; set; }
        public List<DetGuiaRem> detalle { get; set; }
    }
}
