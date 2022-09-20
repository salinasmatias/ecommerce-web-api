using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class Orden
    {
        public Guid OrdenId { get; set; }
        public Guid CarritoId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public virtual Carrito Carrito { get; set; } = null!;
    }
}
