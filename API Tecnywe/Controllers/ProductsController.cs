using API_Tecnywe.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using static API_Tecnywe.DTO.Product;
using Swashbuckle.AspNetCore.Annotations;

namespace API_Tecnywe.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    [SwaggerTag("Operaciones relacionadas con productos")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        [SwaggerOperation(Summary = "Obtener todos los productos")]
        [SwaggerResponse(200, "Lista de productos obtenida correctamente")]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtener un producto por id")]
        [SwaggerResponse(200, "Producto encontrado")]
        [SwaggerResponse(404, "Producto no encontrado")]
        public async Task<ActionResult<ProductDto>> GetById(string id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [Authorize]
        [HttpPost("create")]
        [SwaggerOperation(Summary = "Crear un producto")]
        [SwaggerResponse(201, "Producto creado correctamente")]
        [SwaggerResponse(400, "Datos inválidos")]
        public async Task<ActionResult<ProductDto>> Create(CreateProductDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [Authorize]
        [HttpPost("update")]
        [SwaggerOperation(Summary = "Actualizar un producto")]
        [SwaggerResponse(200, "Producto actualizado correctamente")]
        [SwaggerResponse(404, "Producto no encontrado")]
        public async Task<ActionResult<ProductDto>> Update(UpdateProductDto dto)
        {
            return Ok(await _service.UpdateAsync(dto));
        }

        [Authorize]
        [HttpPost("delete")]
        [SwaggerOperation(Summary = "Eliminar un producto")]
        [SwaggerResponse(204, "Producto eliminado correctamente")]
        [SwaggerResponse(404, "Producto no encontrado")]
        public async Task<IActionResult> Delete(DeleteProductDto dto)
        {
            await _service.DeleteAsync(dto);
            return NoContent();
        }
    }
}