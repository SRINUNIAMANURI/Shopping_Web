using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Models;
using Shopping.Models.DTO_s;
using Shopping.Models.InputDto_s;
using Shopping.Repository;

namespace Shopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IOrderRepository orderRepository;

        public OrderController(IMapper mapper, IOrderRepository orderRepository)
        {
            this.mapper = mapper;
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await orderRepository.GetAll();

            var ordersDtos = mapper.Map<List<OrderDto>>(orders);

            return Ok(ordersDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await orderRepository.GetById(id);

            var ordersDto = mapper.Map<OrderDto>(order);

            return Ok(ordersDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] OrderCreateDto orderCreateDto)
        {
            var ordermodel = await orderRepository.AddOrder(orderCreateDto);

            var orderDto = mapper.Map<OrderDto>(ordermodel);

            return Ok(orderDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderUpdateDto orderUpdateDto)
        {
            var order= await orderRepository.UpdateOrder(orderUpdateDto);

            var orderDto = mapper.Map<OrderDto>(order);

            return Ok(orderDto);
        }
    }
}
