using Identity.Application.Contracts.Repositories;

namespace Identity.Application.Contracts;

public interface IUnitOfWork
{
    ICountryRepository CountryRepository { get; }
    IAccountRepository AccountRepository { get; }

    void Commit();
    void Rollback();
    Task CommitAsync();
    Task RollbackAsync();
}