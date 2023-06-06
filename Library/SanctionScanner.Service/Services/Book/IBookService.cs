using B = SanctionScanner.Model.Entities;

namespace SanctionScanner.Service.Services.Book
{
    public interface IBookService
    {
        Task<B.Book> AddBook(B.Book entity);
        Task<B.Book> BorrowBook(B.Book book);
        Task<B.Book> TakeBook(B.Book book);
        Task<B.Book> GetBook(Guid Id);
        Task<List<B.Book>> ListBook();
    }
}
