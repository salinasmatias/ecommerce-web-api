using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess
{
    public interface IVentaRepository
    {
        Task<List<Venta>> GetVentasByProduct(string codigoProducto);
    }
}
