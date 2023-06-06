using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SanctionScanner.API.Controllers.Base;
using SanctionScanner.Common.DTOs.Book;
using SanctionScanner.Common.Models;
using SanctionScanner.Model.Entities;
using SanctionScanner.Service.Repository.Book;
using SanctionScanner.Service.Services.Book;

namespace SanctionScanner.API.Controllers
{
    [Route("book")]
    public class BookController : BaseApiController<BookController>
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(
            IBookService bookService,
            IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<BookResponse>>> AddBook(AddBookRequest request)
        {
            var entity = _mapper.Map<Book>(request);
            var result = await _bookService.AddBook(entity);

            if (result != null)
            {
                var rm = _mapper.Map<BookResponse>(result);
                return new WebApiResponse<BookResponse>(true, "Success", rm);
            }
            return new WebApiResponse<BookResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<BookResponse>>> BorrowBook(Guid Id, BorrowBookRequest request)
        {
            var book = await _bookService.GetBook(Id);
            var entity = _mapper.Map(request, book);
            entity.Id = Id;
            var result = await _bookService.BorrowBook(entity);

            if (result != null)
            {
                var rm = _mapper.Map<BookResponse>(result);
                return new WebApiResponse<BookResponse>(true, "Success", rm);
            }
            return new WebApiResponse<BookResponse>(false, "Error");
        }

        [HttpPut("take/{id}")]
        public async Task<ActionResult<WebApiResponse<BookResponse>>> TakeBack(Guid Id)
        {
            var book = await _bookService.GetBook(Id);
            book.Id = Id;
            var result = await _bookService.TakeBook(book);

            if (result != null)
            {
                var rm = _mapper.Map<BookResponse>(result);
                return new WebApiResponse<BookResponse>(true, "Success", rm);
            }
            return new WebApiResponse<BookResponse>(false, "Error");
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<BookResponse>>>> List()
        {
            var result = await _bookService.ListBook();

            var entity = _mapper.Map<List<BookResponse>>(result);

            if (entity != null)
            {
                return new WebApiResponse<List<BookResponse>>(true, "Success", entity);
            }
            return new WebApiResponse<List<BookResponse>>(false, "Error");
        }
    }
}
