using API_Tecnywe.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using static API_Tecnywe.DTO.Order;

namespace API_Tecnywe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponseDto>> GetById(string id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost("create")]
        public async Task<ActionResult<OrderResponseDto>> Create(CreateOrderDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
}
