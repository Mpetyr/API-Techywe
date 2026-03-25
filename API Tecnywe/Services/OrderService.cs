using API_Tecnywe.Entities;
using API_Tecnywe.Exceptions;
using API_Tecnywe.Repositories.Interfaces;
using API_Tecnywe.Services.Interface;
using AutoMapper;
using static API_Tecnywe.DTO.Order;

namespace API_Tecnywe.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderService(
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderResponseDto> GetByIdAsync(string id)
        {
            var order = await _orderRepository.GetByIdWithDetailsAsync(id);

            if (order is null)
                throw new NotFoundException($"No se encontró la orden con id {id}.");

            return _mapper.Map<OrderResponseDto>(order);
        }

        public async Task<OrderResponseDto> CreateAsync(CreateOrderDto dto)
        {
            var customer = await _customerRepository.GetByIdAsync(dto.CustomerId);

            if (customer is null)
                throw new NotFoundException($"No se encontró el cliente con id {dto.CustomerId}.");

            var order = new Order
            {
                Id = Guid.NewGuid().ToString(),
                CustomerId = dto.CustomerId,
                CreationDate = DateTime.UtcNow,
                OrderDetails = new List<OrderDetail>()
            };

            decimal total = 0;

            foreach (var item in dto.OrderDetails)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);

                if (product is null)
                    throw new NotFoundException($"No se encontró el producto con id {item.ProductId}.");

                if (product.Stock < item.Quantity)
                    throw new BadRequestException($"Stock insuficiente para el producto {product.Name}.");

                var subtotal = product.Price * item.Quantity;

                var detail = new OrderDetail
                {
                    Id = Guid.NewGuid().ToString(),
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price,
                    Subtotal = subtotal
                };

                order.OrderDetails.Add(detail);
                total += subtotal;

                product.Stock -= item.Quantity;
                _productRepository.Update(product);
            }

            order.Total = total;

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();

            var savedOrder = await _orderRepository.GetByIdWithDetailsAsync(order.Id);

            return _mapper.Map<OrderResponseDto>(savedOrder);
        }
    }
}
