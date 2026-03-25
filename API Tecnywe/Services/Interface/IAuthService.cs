using Microsoft.AspNetCore.Identity.Data;
using static API_Tecnywe.DTO.Auth.Auth;

namespace API_Tecnywe.Services.Interface
{
    public interface IAuthService
    {
        LoginResponseDto Login(LoginRequestDto dto);
    }
}
