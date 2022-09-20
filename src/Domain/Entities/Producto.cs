using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class Producto
    {
        public Producto()
        {
            CarritoProductos = new HashSet<CarritoProducto>();
        }

        public int ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public decimal Precio { get; set; }
        public string Imagen { get; set; } = null!;

        public virtual ICollection<CarritoProducto> CarritoProductos { get; set; }
    }
}
