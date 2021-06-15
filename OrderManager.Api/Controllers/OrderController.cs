using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderManager.Api.Responses;
using OrderManager.Core.CustomEntities;
using OrderManager.Core.DTOs;
using OrderManager.Core.QueryFilters;
using OrderManager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OrderManager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public OrderController(IOrderService orderService, IMapper mapper, IUriService uriService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _uriService = uriService;
        }
       
        /// <summary>
        /// Retrieve all posts
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetOrdersAsync))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<OrderDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetOrdersAsync([FromQuery] OrderQueryFilter filters)
        {
            var orders = await _orderService.GetOrders(filters);
            var ordersDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);

            var metadata = new Metadata
            {
                TotalCount = orders.TotalCount,
                PageSize = orders.PageSize,
                CurrentPage = orders.CurrentPage,
                TotalPages = orders.TotalPages,
                HasNextPage = orders.HasNextPage,
                HasPreviousPage = orders.HasPreviousPage,
                NextPageUrl = _uriService.GetPostPaginationUri(filters, Url.RouteUrl(nameof(GetOrdersAsync))).ToString(),
                PreviousPageUrl = _uriService.GetPostPaginationUri(filters, Url.RouteUrl(nameof(GetOrdersAsync))).ToString()
            };

            var response = new ApiResponse<IEnumerable<OrderDto>>(ordersDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }
    }
}
