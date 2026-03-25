using static API_Tecnywe.DTO.Product;

namespace API_Tecnywe.Services.Interface
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(string id);
        Task<ProductDto> CreateAsync(CreateProductDto dto);
        Task<ProductDto> UpdateAsync(UpdateProductDto dto);
        Task DeleteAsync(DeleteProductDto dto);
    }
}
