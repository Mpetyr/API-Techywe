using API_Tecnywe.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using static API_Tecnywe.DTO.Customer;

namespace API_Tecnywe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetById(string id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost("create")]
        public async Task<ActionResult<CustomerDto>> Create(CreateCustomerDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
}
