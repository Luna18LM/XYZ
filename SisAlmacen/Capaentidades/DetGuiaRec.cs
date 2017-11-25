using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capaentidades
{
    public class DetGuiaRec
    {
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public String Observacion { get; set; }
        public Producto producto { get; set; }
    }
}
