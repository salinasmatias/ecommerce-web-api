using Application.DataAccess;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrdenRepository : IOrdenRepository
    {
        private readonly AppDbContext _context;

        public OrdenRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<List<Orden>> GetTodaySales()
        {
            return await _context.Ordenes.Where(o => o.Fecha.Date == DateTime.Now.Date).ToListAsync();
        }
    }
}
