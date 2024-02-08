using Identity.Domain.Models;

namespace Identity.Application.Identity
{
    public interface IJwtProvider
    {
        string GenerateJwtToken(User  user);
    }
}
