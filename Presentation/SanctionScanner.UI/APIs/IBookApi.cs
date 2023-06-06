using Refit;
using SanctionScanner.Common.DTOs.Book;
using SanctionScanner.Common.Models;

namespace SanctionScanner.UI.APIs
{
    [Headers("Content-Type: application/json")]
    public interface IBookApi
    {
        [Get("/book")]
        Task<ApiResponse<WebApiResponse<List<BookResponse>>>> GetAll();
        [Post("/book")]
        Task<ApiResponse<WebApiResponse<BookResponse>>> AddBook(AddBookRequest request);
        [Put("/book/{id}")]
        Task<ApiResponse<WebApiResponse<BookResponse>>> BorrowBook(Guid Id,BorrowBookRequest request);
        [Put("/book/take/{id}")]
        Task<ApiResponse<WebApiResponse<BookResponse>>> TakeBook(Guid Id);
    }
}
