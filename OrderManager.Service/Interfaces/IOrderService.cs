
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
        Task<bool> InsertOrder(Order order);
        Task<bool> UpdateOrder(Order order);
        Task<bool> DeleteOrder(int id);
    }
}
