using Identity.Application.Contracts.Dtos;

namespace Identity.Application.Contracts.Services;

public interface IAccountService
{
    Task<ResponseDto> Register(RegisterDto  registerDto);
    Task<ResponseDto> Login(LoginDto loginDto);
}