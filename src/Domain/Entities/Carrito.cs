using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class Carrito
    {
        public Carrito()
        {
            CarritoProductos = new HashSet<CarritoProducto>();
        }

        public Guid CarritoId { get; set; }
        public int ClienteId { get; set; }
        public bool Estado { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;
        public virtual Orden? Orden { get; set; }
        public virtual ICollection<CarritoProducto> CarritoProductos { get; set; }
    }
}
