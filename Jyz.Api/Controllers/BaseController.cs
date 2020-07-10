using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jyz.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize(Policy = "NeedToken")]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
        }
    }
}
