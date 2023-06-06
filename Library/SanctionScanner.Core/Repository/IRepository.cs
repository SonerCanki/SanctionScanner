using SanctionScanner.Core.Entity;
using System.Linq.Expressions;

namespace SanctionScanner.Core.Repository
{
    public interface IRepository<T> where T : CoreEntity
    {
        Task<T> Add(T item);
        Task<T> Update(T item);
        Task<T> GetById(Guid id, params Expression<Func<T, object>>[] includeParameters);
        Task<IQueryable<T>> GetAll();
    }
}
