using API_Tecnywe.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using static API_Tecnywe.DTO.Order;
using Swashbuckle.AspNetCore.Annotations;

namespace API_Tecnywe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Operaciones relacionadas con Ordenes")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        [SwaggerOperation(Summary = "Obtener todos las ordenes")]
        [SwaggerResponse(200, "Lista de ordenes obtenida correctamente")]
        public async Task<ActionResult<List<OrderDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtener una orden por id")]
        [SwaggerResponse(200, "Pedido encontrado")]
        [SwaggerResponse(404, "Pedido no encontrado")]
        public async Task<ActionResult<OrderResponseDto>> GetById(string id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [Authorize]
        [HttpPost("create")]
        [SwaggerOperation(Summary = "Crear una orden")]
        [SwaggerResponse(201, "Orden creado correctamente")]
        [SwaggerResponse(400, "Datos inválidos o stock insuficiente")]
        public async Task<ActionResult<OrderResponseDto>> Create(CreateOrderDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
}
