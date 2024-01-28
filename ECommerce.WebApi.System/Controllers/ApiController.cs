using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        public const string PathSeparator = "/";
        public const string Id = "{id}";
    }
}
