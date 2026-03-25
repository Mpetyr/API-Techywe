using API_Tecnywe.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using static API_Tecnywe.DTO.Customer;
using Swashbuckle.AspNetCore.Annotations;

namespace API_Tecnywe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Operaciones relacionadas con clientes")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        [SwaggerOperation(Summary = "Obtener todos los clientes")]
        [SwaggerResponse(200, "Lista de clientes obtenida correctamente")]
        public async Task<ActionResult<List<CustomerDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtener un cliente por id")]
        [SwaggerResponse(200, "Cliente encontrado")]
        [SwaggerResponse(404, "Cliente no encontrado")]
        public async Task<ActionResult<CustomerDto>> GetById(string id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [Authorize]
        [HttpPost("create")]
        [SwaggerOperation(Summary = "Crear un cliente")]
        [SwaggerResponse(201, "Cliente creado correctamente")]
        [SwaggerResponse(400, "Datos inválidos")]
        public async Task<ActionResult<CustomerDto>> Create(CreateCustomerDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
}
