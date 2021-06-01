using OrderManager.Core.Entities;
 
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
    }
}
