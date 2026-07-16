using MessManagementSystem.Data;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Models.DTO;
using MessManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MessManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<ResponseUserDto>> Register(RegisterUserDto request)
        {
            var user = await authService.RegisterUserAsync(request);
            if (user == null)
            {
                return BadRequest("User is Already Registered");
            }
            return Ok(user);

        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(LoginUserDto request)
        {
            var result = await authService.LoginUserAsync(request);
            if(result == null)
            {
                return BadRequest("Invalid Username or Password");
            }
            return Ok(result);

        }

 

    }
}
