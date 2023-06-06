using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SanctionScanner.Common.DTOs.Book;
using SanctionScanner.UI.APIs;
using SanctionScanner.UI.Models.Book;

namespace SanctionScanner.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookApi _bookApi;
        private readonly IMapper _mapper;

        public HomeController(
            IBookApi bookApi,
            IMapper mapper)
        {
            _bookApi = bookApi;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var list = new List<ListBookViewModel>();
            var listResult = await _bookApi.GetAll();

            if (listResult.IsSuccessStatusCode && listResult.Content.IsSuccess && listResult.Content.ResultData.Any())
            {
                list = _mapper.Map<List<ListBookViewModel>>(listResult.Content.ResultData);
            }
            return View(list);
        }

        public async Task<IActionResult> Add(AddBookViewModel item)
        {
            var insertResult = await _bookApi.AddBook(_mapper.Map<AddBookRequest>(item));

            if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                return RedirectToAction("Index");
            else
                TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> BorrowBook(Guid Id, BorrowBookViewModel item)
        {
            var insertResult = await _bookApi.BorrowBook(Id,_mapper.Map<BorrowBookRequest>(item));

            if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                return RedirectToAction("Index");
            else
                TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> TakeBook(Guid Id)
        {
            var insertResult = await _bookApi.TakeBook(Id);

            if (insertResult.IsSuccessStatusCode && insertResult.Content.IsSuccess && insertResult.Content.ResultData != null)
                return RedirectToAction("Index");
            else
                TempData["Message"] = "Kayıt işlemi sırasında bir hata oluştu!...Lütfen tüm alanları kontrol edip tekrar deneyiniz...";

            return RedirectToAction("Index");
        }
    }
}
