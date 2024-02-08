using Identity.Application.Contracts;
using Identity.Application.Contracts.Repositories;
using Identity.Application.Repositories;
using Identity.Application.Repository;
using Identity.EntityFrameworkCore.DbContexts;

namespace Identity.Application
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ICountryRepository _countryRepository;
        private IAccountRepository _accountRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public ICountryRepository CountryRepository
        {
            get { return _countryRepository = _countryRepository ?? new CountryRepository(_context); }
        }

        public IAccountRepository AccountRepository
        {
            get { return _accountRepository = _accountRepository ?? new AccountRepository(_context); }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            _context.Dispose();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task RollbackAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
