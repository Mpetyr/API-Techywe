using static API_Tecnywe.DTO.Order;

namespace API_Tecnywe.Services.Interface
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllAsync();
        Task<OrderResponseDto> GetByIdAsync(string id);
        Task<OrderResponseDto> CreateAsync(CreateOrderDto dto);
    }
}
