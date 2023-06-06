using Microsoft.AspNetCore.Mvc;

namespace SanctionScanner.API.Controllers.Base
{
    [ApiController]
    public class BaseApiController<T> : ControllerBase where T : BaseApiController<T>
    {
    }
}
