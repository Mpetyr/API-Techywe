using API_Tecnywe.Entities;

namespace API_Tecnywe.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(string id);
        Task<Customer?> GetByEmailAsync(string email);
        Task AddAsync(Customer customer);
        Task SaveChangesAsync();
    }
}
