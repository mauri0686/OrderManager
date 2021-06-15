
using OrderManager.Core.QueryFilters;
using System;

namespace OrderManager.Service
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(OrderQueryFilter filter, string actionUrl);
    }
}