using API_Tecnywe.Entities;

namespace API_Tecnywe.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(string id);
        Task<Order?> GetByIdWithDetailsAsync(string id);
        Task AddAsync(Order order);
        Task SaveChangesAsync();
    }
}
