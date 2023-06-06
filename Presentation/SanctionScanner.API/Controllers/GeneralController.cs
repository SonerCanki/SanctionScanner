using Microsoft.AspNetCore.Mvc;
using SanctionScanner.API.Controllers.Base;
using SanctionScanner.API.Helper;
using SanctionScanner.Common.Models;

namespace SanctionScanner.API.Controllers
{
    [Route("general")]
    public class GeneralController : BaseApiController<BookController>
    {
        private readonly IWebHostEnvironment _env;
        public GeneralController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public async Task<WebApiResponse<string>> UploadFile()
        {
            var files = HttpContext.Request.Form.Files.ToList();

            bool imageResult;
            var result = Upload.ImageUpload(files, _env, out imageResult);

            if (imageResult)
            {
                return new WebApiResponse<string>(true, result);
            }
            else
            {
                return new WebApiResponse<string>(false, result);
            }
        }
    }
}
