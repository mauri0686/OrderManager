
using OrderManager.Core.QueryFilters;
using System;

namespace OrderManager.Service
{
    public interface IUriService
    {
        Uri GetOrderPaginationUri(OrderQueryFilter filter, string actionUrl);
    }
}