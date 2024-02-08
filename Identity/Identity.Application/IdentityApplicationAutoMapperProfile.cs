using AutoMapper;
using Identity.Application.Contracts.Dtos;
using Identity.Domain.Models;

namespace Identity.Application
{
    public class IdentityApplicationAutoMapperProfile : Profile
    {
        public IdentityApplicationAutoMapperProfile()
        {
            CreateMap<RegisterDto, User>();
        }
    }
}
