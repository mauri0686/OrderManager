using AutoMapper;
using OrderManager.Core.DTOs;
using OrderManager.Core.Entities;

namespace OrderManager.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
             
        }
    }
}
