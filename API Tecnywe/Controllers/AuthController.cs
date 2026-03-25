using API_Tecnywe.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static API_Tecnywe.DTO.Auth.Auth;

namespace API_Tecnywe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Autenticación")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [SwaggerOperation(Summary = "Iniciar sesión y obtener JWT")]
        [SwaggerResponse(200, "Token generado correctamente")]
        [SwaggerResponse(401, "Credenciales inválidas")]
        public ActionResult<LoginResponseDto> Login([FromBody] LoginRequestDto dto)
        {
            var result = _authService.Login(dto);
            return Ok(result);
        }
    }
}
