using Identity.Application.Contracts.Repositories;
using Identity.Domain.Models;
using Identity.EntityFrameworkCore.DbContexts;

namespace Identity.Application.Repository
{
    public class CountryRepository : IdentityApplicationRepository<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
