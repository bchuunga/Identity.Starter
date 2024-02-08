using Identity.Application.Contracts.Dtos;
using Identity.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Identity.HttpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ResponseDto>> Register(RegisterDto registerDto)
        {
            var response = await _accountService.Register(registerDto);
            return response;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseDto>> Login(LoginDto loginDto)
        {
            var response = await _accountService.Login(loginDto);
            return response;
        }
    }
}
