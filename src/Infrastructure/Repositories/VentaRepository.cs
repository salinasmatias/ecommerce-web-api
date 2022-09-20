using Application.DataAccess;
using Domain.Entities;
using Domain.Models;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class VentaRepository : IVentaRepository
    {
        private readonly AppDbContext _context;

        public VentaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Venta>> GetVentasByProduct(string codigoProducto)
        {
            var carritos = await _context.Carritos.Include(Carrito => Carrito.Cliente)
                                            .Include(Carrito => Carrito.Orden)
                                            .Include(Carrito => Carrito.CarritoProductos)
                                            .ThenInclude(CarritoProducto => CarritoProducto.Producto)
                                            .Where(Carrito => Carrito.CarritoProductos.Any(CarritoProducto => CarritoProducto.Producto.Codigo == codigoProducto))
                                            .ToListAsync();

            var ventas = new List<Venta>();
            var productos = new List<Producto>();

            foreach(var carrito in carritos)
            {
                foreach(var carritoProducto in carrito.CarritoProductos)
                {
                    productos.Add(carritoProducto.Producto);
                }
                ventas.Add(new Venta
                {
                    Cliente = carrito.Cliente,
                    Productos = productos,
                    Fecha = carrito.Orden.Fecha,
                    Total = carrito.Orden.Total
                });

                productos = new List<Producto>();
            }

            return ventas;
        }
    }
}
