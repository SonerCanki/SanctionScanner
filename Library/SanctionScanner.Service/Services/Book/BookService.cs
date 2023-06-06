using SanctionScanner.Service.UnitOfWork;
using B = SanctionScanner.Model.Entities;

namespace SanctionScanner.Service.Services.Book
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<B.Book> AddBook(B.Book book)
        {
            book.IsInLibrary = true;
            var result = await _unitOfWork.BookRepository.Add(book);
            await _unitOfWork.Save();
            return result;
        }

        public async Task<B.Book> BorrowBook(B.Book book)
        {
            book.BorrawingTime = DateTime.Now;
            book.IsInLibrary = false;
            var result = await _unitOfWork.BookRepository.Update(book);

            await _unitOfWork.Save();
            return result;
        }

        public async Task<B.Book> GetBook(Guid Id)
        {
            return await _unitOfWork.BookRepository.GetById(Id);
        }

        public async Task<List<B.Book>> ListBook()
        {
            return (await _unitOfWork.BookRepository.GetAll()).ToList();
        }

        public async Task<B.Book> TakeBook(B.Book book)
        {
            book.Borrower = null;
            book.BorrawingTime = null;
            book.ReturnTime = null;
            book.IsInLibrary = true;
            var result = await _unitOfWork.BookRepository.Update(book);

            await _unitOfWork.Save();

            return result;
        }
    }
}
