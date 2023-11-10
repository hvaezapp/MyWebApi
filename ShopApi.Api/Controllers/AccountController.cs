using Microsoft.AspNetCore.Mvc;
using ShopApi.Application.Contracts.Identity;
using ShopApi.Application.Models.Identity;

namespace ShopApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService authService;

        public AccountController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await authService.Login(request));
        }


        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegisterationRequest request)
        {
            return Ok(await authService.Register(request));
        }

    }
}
