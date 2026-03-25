using System.ComponentModel.DataAnnotations;

namespace API_Tecnywe.DTO.Auth
{
    public class Auth
    {
        public class LoginRequestDto
        {
            [Required]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }
        }

        public class LoginResponseDto
        {
            public string Token { get; set; }
        }
    }
}
