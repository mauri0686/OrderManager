
using Microsoft.Extensions.Options;
using OrderManager.Core.CustomEntities;
using OrderManager.Core.Entities;
using OrderManager.Core.QueryFilters;
using OrderManager.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Service
{
    public class OrderService : IOrderService
    {
        #region Property
        private IRepository<Order> _repository;
        private readonly PaginationOptions _paginationOptions;
        #endregion

        #region Constructor
        public OrderService(IRepository<Order> repository, IOptions<PaginationOptions> options)
        {
            _repository = repository;
            _paginationOptions = options.Value;
        }
        #endregion     

        public async Task<Order> GetOrder(int id)
        {
            return await _repository.Get(id);
        }
        public async Task<PagedList<Order>> GetOrders(OrderQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var orders = _repository.GetAll();

            if (filters.UserId != null)
            {
                orders = orders.Where(x => x.UserId == filters.UserId);
            }

            if (filters.Date != null)
            {
                orders = orders.Where(x => x.Date.ToShortDateString() == filters.Date?.ToShortDateString());
            } 

            var pagedOrders = PagedList<Order>.Create(orders, filters.PageNumber, filters.PageSize);
            return await Task.FromResult(pagedOrders);
        }
        public async Task InsertOrder(Order Order)
        {
              await _repository.Insert(Order);
        }
        public async Task UpdateOrder(Order Order)
        {
              await _repository.Update(Order);
        }

        public async Task DeleteOrder(int id)
        {
            var Order = await GetOrder(id);
            await _repository.Remove(Order);
            await _repository.SaveChanges();
        }
    }
}
