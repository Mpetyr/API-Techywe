using API_Tecnywe.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using static API_Tecnywe.DTO.Product;

namespace API_Tecnywe.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(string id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost("create")]
        public async Task<ActionResult<ProductDto>> Create(CreateProductDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPost("update")]
        public async Task<ActionResult<ProductDto>> Update(UpdateProductDto dto)
        {
            return Ok(await _service.UpdateAsync(dto));
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(DeleteProductDto dto)
        {
            await _service.DeleteAsync(dto);
            return NoContent();
        }
    }
}
