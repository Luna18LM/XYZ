using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capaentidades
{
    public class Producto
    {
        public int idProducto { get; set; }
        public String Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public String Serie { get; set; }
        public String Descripcion { get; set; }
        public String Imagen { get; set; }
        public String estado { get; set; }
        public Categoria categoria { get; set; }
        public Talla talla { get; set; }
        public Diseño diseño { get; set; }
        public Color color { get; set; }
    }
}
