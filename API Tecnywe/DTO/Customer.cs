using System.ComponentModel.DataAnnotations;

namespace API_Tecnywe.DTO
{
    public class Customer
    {
        public class CreateCustomerDto
        {
            [Required]
            [StringLength(150)]
            public string FullName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public class CustomerDto
        {
            public string Id { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
        }
    }
}
