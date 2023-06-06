using Microsoft.EntityFrameworkCore;
using SanctionScanner.Core.Entity;
using SanctionScanner.Core.Repository;
using SanctionScanner.Model.Context;
using System.Linq.Expressions;

namespace SanctionScanner.Service.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : CoreEntity
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        private DbSet<T> _entities;

        public DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }

        public async Task<T> Add(T item)
        {

            if (item == null)
                return null;

            await Entities.AddAsync(item);

            return item;
        }

        public async Task<T> Update(T item)
        {

            if (item == null)
                return null;

            Entities.Update(item);

            return item;
        }

        public async Task<T> GetById(Guid id, params Expression<Func<T, object>>[] includeParameters)
        {
            IQueryable<T> queryable = Entities.AsNoTracking();
            foreach (Expression<Func<T, object>> includeParameter in includeParameters)
            {
                queryable = queryable.Include(includeParameter);
            }
            return await queryable.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return Entities.AsNoTracking();
        }
    }
}
