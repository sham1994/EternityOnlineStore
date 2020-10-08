using AutoMapper;
using EternityStore.Business.OrderBusiness;
using EternityStore.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EternityStore.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        private readonly IMapper _mapper;

        public OrdersController(IOrderManager orderManager, IMapper mapper)
        {
           
            _orderManager = orderManager;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrders(int id)
        {
            var orders = await _orderManager.GetOrders(id);
            var ordersToReturn = _mapper.Map<IEnumerable<OrderForListDto>>(orders);
            return Ok(ordersToReturn);
        }

        [HttpPost("AddOrder")]
        public async Task<IActionResult> PostOrders(OrderForListDto orderForListDto)
        {
            var order = await _orderManager.AddOrder(orderForListDto).ConfigureAwait(false);

            return Ok(order);
        }
    }
}
