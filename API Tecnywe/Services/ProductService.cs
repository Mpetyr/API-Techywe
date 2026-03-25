using API_Tecnywe.Entities;
using API_Tecnywe.Exceptions;
using API_Tecnywe.Repositories.Interfaces;
using API_Tecnywe.Services.Interface;
using AutoMapper;
using static API_Tecnywe.DTO.Product;

namespace API_Tecnywe.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(string id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product is null)
                throw new NotFoundException($"no se encontró el producto con id {id}.");

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            product.Id = Guid.NewGuid().ToString();

            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateAsync(UpdateProductDto dto)
        {
            var product = await _repository.GetByIdAsync(dto.Id);

            if (product is null)
                throw new NotFoundException($"No se encontró el producto con id {dto.Id}.");

            _mapper.Map(dto, product);

            _repository.Update(product);
            await _repository.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task DeleteAsync(DeleteProductDto dto)
        {
            var product = await _repository.GetByIdAsync(dto.Id);

            if (product is null)
                throw new NotFoundException($"No se encontró el producto con id {dto.Id}.");

            _repository.Delete(product);
            await _repository.SaveChangesAsync();
        }
    }
}
