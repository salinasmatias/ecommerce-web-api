using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess
{
    public interface IClienteRepository
    {
        Task<Cliente> AddCliente(Cliente cliente);
        Task<Cliente> GetClienteById(int id);
    }
}
