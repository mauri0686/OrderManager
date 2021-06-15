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
using OrderManager.Core.Entities;

namespace OrderManager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
 
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
          
        }
       
        /// <summary>
        /// Retrieve all Orders
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetOrders))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<OrderDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetOrders([FromQuery] OrderQueryFilter filters)
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
                HasPreviousPage = orders.HasPreviousPage               
            };

            var response = new ApiResponse<IEnumerable<OrderDto>>(ordersDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var Order = await _orderService.GetOrder(id);
            var OrderDto = _mapper.Map<OrderDto>(Order);
            var response = new ApiResponse<OrderDto>(OrderDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderDto OrderDto)
        {
            var Order = _mapper.Map<Order>(OrderDto);

            await _orderService.InsertOrder(Order);

            OrderDto = _mapper.Map<OrderDto>(Order);
            var response = new ApiResponse<OrderDto>(OrderDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, OrderDto OrderDto)
        {
            var Order = _mapper.Map<Order>(OrderDto);
            Order.Id = id;

            var result = await _orderService.UpdateOrder(Order);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.DeleteOrder(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
