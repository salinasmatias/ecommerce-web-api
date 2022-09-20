using Application.DataAccess;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _repository;
        private readonly IMapper _mapper;

        public VentaService(IVentaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<VentaDtoForDisplay>> GetVentasByProduct(string codigoProducto)
        {
            var ventas = await _repository.GetVentasByProduct(codigoProducto);

            return _mapper.Map<List<VentaDtoForDisplay>>(ventas);
        }
    }
}
