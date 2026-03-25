using System.ComponentModel.DataAnnotations;

namespace API_Tecnywe.DTO
{
    public class Product
    {
        public class CreateProductDto
        {
            [Required]
            [StringLength(100)]
            public string Name { get; set; }

            [Range(0.01, double.MaxValue)]
            public decimal Price { get; set; }

            [Range(0, int.MaxValue)]
            public int Stock { get; set; }
        }

        public class UpdateProductDto
        {
            [Required]
            public string Id { get; set; }
            [Required]
            [StringLength(100)]
            public string Name { get; set; }

            [Range(0.01, double.MaxValue)]
            public decimal Price { get; set; }

            [Range(0, int.MaxValue)]
            public int Stock { get; set; }
        }

        public class DeleteProductDto
        {
            [Required]
            public string Id { get; set; }
        }

        public class ProductDto
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
        }
    }
}
