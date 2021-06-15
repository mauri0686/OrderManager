
using OrderManager.Core.CustomEntities;
using OrderManager.Core.Entities;
using OrderManager.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManager.Service
{
   public interface IOrderService
    {
        Task<PagedList<Order>> GetOrders(OrderQueryFilter filters);
        Task<Order> GetOrder(int id);
        Task InsertOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(int id);
    }
}
