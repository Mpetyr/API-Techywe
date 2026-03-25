using static API_Tecnywe.DTO.Customer;

namespace API_Tecnywe.Services.Interface
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAllAsync();
        Task<CustomerDto> GetByIdAsync(string id);
        Task<CustomerDto> CreateAsync(CreateCustomerDto dto);
    }
}
