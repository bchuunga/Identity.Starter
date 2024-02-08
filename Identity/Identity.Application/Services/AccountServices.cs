using AutoMapper;
using Identity.Application.Contracts.Dtos;
using Identity.Application.Contracts.Enums;
using Identity.Application.Contracts.Repositories;
using Identity.Application.Contracts.Services;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Identity.Application.Identity;
using Identity.Domain;

namespace Identity.Application.Services
{
    public class AccountServices : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtProvider _jwtProvider;
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        public AccountServices(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IJwtProvider jwtProvider,
            IMapper mapper,
            IAccountRepository accountRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtProvider = jwtProvider;
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        public async Task<ResponseDto> Register(RegisterDto registerDto)
        {
            IdentityResult result;
            var user = await _userManager.FindByEmailAsync(registerDto.Email);
            if (user != null)
            {
                return new ResponseDto
                {
                    Status = Status.Error,
                    Message = "Invalid user data",
                    Data = "<li>User already exists</li>"
                };
            }

            user = _mapper.Map<User>(registerDto);
            user.UserName = registerDto.Email;

            result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                if (registerDto.FreeTrial)
                {
                    Claim trialClaim = new Claim(IdentityDomainAuthorizationPolicyConstants.Trial, DateTime.Now.ToString());
                    await _userManager.AddClaimAsync(user, trialClaim);
                }

                if (registerDto.Admin)
                {
                    Claim adminClaim = new Claim(IdentityDomainAuthorizationPolicyConstants.IsAdmin,
                        IdentityDomainAuthorizationPolicyConstants.Admin);
                    await _userManager.AddClaimAsync(user, adminClaim);
                }

                return new ResponseDto
                {
                    Status = Status.Success,
                    Message = "User created",
                    Data = user
                };
            }

            var errorResult = result.Errors.Select(e => $"<li>{e.Description}</li>");
            return new ResponseDto
            {
                Status = Status.Error,
                Message = "Invalid data",
                Data = string.Join("", errorResult)
            };
        }

        public async Task<ResponseDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return new ResponseDto
                {
                    Status = Status.Error,
                    Message = "Invalid username or password",
                    Data = loginDto
                };
            }

            if (!user.EmailConfirmed)
            {
                return new ResponseDto
                {
                    Status = Status.Error,
                    Message = "Please confirm your email before signing in",
                    Data = loginDto
                };
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return new ResponseDto
                {
                    Status = Status.Error,
                    Message = "Invalid username or password",
                    Data = loginDto
                };
            }

            var tokenDto = new TokenDto { Token = _jwtProvider.GenerateJwtToken(user) };
            return new ResponseDto
            {
                Status = Status.Success,
                Message = "Login Successful",
                Data = tokenDto
            };
        }
    }
}
