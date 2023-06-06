using SanctionScanner.Model.Context;
using SanctionScanner.Service.Repository.Base;
using B = SanctionScanner.Model.Entities;


namespace SanctionScanner.Service.Repository.Book
{
    public class BookRepository : Repository<B.Book>, IBookRepository
    {
        private readonly DataContext _dataContext;
        public BookRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }

    }
}
