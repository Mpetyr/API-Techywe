using API_Tecnywe.Entities;

namespace API_Tecnywe.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(string id);
        Task AddAsync(Product product);
        void Update(Product product);
        void Delete(Product product);
        Task SaveChangesAsync();
    }
}
