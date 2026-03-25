using API_Tecnywe.Data;
using API_Tecnywe.Entities;
using API_Tecnywe.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Tecnywe.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(string id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order?> GetByIdWithDetailsAsync(string id)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
