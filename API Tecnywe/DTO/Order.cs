using System.ComponentModel.DataAnnotations;

namespace API_Tecnywe.DTO
{
    public class Order
    {
        public class CreateOrderDetailDto
        {
            [Required]
            public string ProductId { get; set; }

            [Range(1, int.MaxValue)]
            public int Quantity { get; set; }
        }

        public class CreateOrderDto
        {
            [Required]
            public string CustomerId { get; set; }

            [Required]
            public List<CreateOrderDetailDto> OrderDetails { get; set; } = new();
        }

        public class OrderDetailDto
        {
            public string Id { get; set; }
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal Subtotal { get; set; }
        }

        public class OrderDto
        {
            public string Id { get; set; }
            public string CustomerId { get; set; }
            public decimal Total { get; set; }
            public DateTime CreationDate { get; set; }
        }

        public class OrderResponseDto
        {
            public string Id { get; set; }
            public string CustomerId { get; set; }
            public string CustomerName { get; set; }
            public decimal Total { get; set; }
            public DateTime CreationDate { get; set; }
            public List<OrderDetailDto> OrderDetails { get; set; } = new();
        }
    }
}
