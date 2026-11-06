using AuthAPI.DTOs;
using AuthAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;

        }

        [HttpPost("/Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequest)
        {

            var  res = await _authService.Login(loginRequest);
            return Ok(res);
        }
        [HttpPost("/refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] string refresToken)
        {

            var res = await _authService.RefreshTokenAsync(refresToken);
            
            return Ok(res);

        }
       

    }
}
