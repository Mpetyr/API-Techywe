using API_Tecnywe.Services.Interface;
using Microsoft.IdentityModel.Tokens;
using static API_Tecnywe.DTO.Auth.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Tecnywe.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LoginResponseDto Login(LoginRequestDto dto)
        {
            if (dto.Username != "admin" || dto.Password != "Admin123*")
                throw new UnauthorizedAccessException("Credenciales inválidas.");

            var key = _configuration["Jwt:Key"]!;
            var issuer = _configuration["Jwt:Issuer"]!;
            var audience = _configuration["Jwt:Audience"]!;
            var expiresInMinutes = int.Parse(_configuration["Jwt:ExpiresInMinutes"]!);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, dto.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresInMinutes),
                signingCredentials: credentials
            );

            return new LoginResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
