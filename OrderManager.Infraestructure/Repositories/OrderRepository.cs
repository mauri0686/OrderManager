using OrderManager.Core.Entities;
using OrderManager.Core.Interfaces;
 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManager.Infraestructure
{
    public class OrderRepository : IOrderRepository
    {
        public Task<IEnumerable<Order>> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
