using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Presentation
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<Producto, ProductoDto>();
            CreateMap<Venta, VentaDtoForDisplay>();
        }
    }
}
