using SanctionScanner.Core.Repository;
using SanctionScanner.Model.Context;
using SanctionScanner.Model.Entities;

namespace SanctionScanner.Service.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Book> BookRepository { get; }
        Task<int> Save();
    }
}
