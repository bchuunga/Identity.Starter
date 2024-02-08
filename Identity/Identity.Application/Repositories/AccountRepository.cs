using Identity.Application.Contracts.Repositories;
using Identity.Domain.Models;
using Identity.EntityFrameworkCore.DbContexts;

namespace Identity.Application.Repositories
{
    public class AccountRepository : IdentityApplicationRepository<User>, IAccountRepository
    {
        public AccountRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
