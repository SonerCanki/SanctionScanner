using SanctionScanner.Core.Repository;
using SanctionScanner.Model.Context;
using SanctionScanner.Model.Entities;
using SanctionScanner.Service.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanctionScanner.Service.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        private IRepository<Book> _bookRepository { get; set; }

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public IRepository<Book> BookRepository => _bookRepository ?? new Repository<Book>(_dataContext);


        public async Task<int> Save() => await _dataContext.SaveChangesAsync();


        public void Dispose()
        {
            
            _dataContext.Dispose();
        }
    }
}
