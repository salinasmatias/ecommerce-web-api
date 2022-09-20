using Application.DataAccess;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClienteDto> GetClienteById(int id)
        {
            var cliente = await _repository.GetClienteById(id);

            return _mapper.Map<ClienteDto>(cliente);
        }
    }
}
