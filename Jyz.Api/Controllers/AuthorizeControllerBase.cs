using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jyz.Api.Controllers
{
    [Authorize(Policy = "Permission")]
    public class AuthorizeControllerBase : ControllerBase
    {
        public AuthorizeControllerBase()
        {
        }
    }
}
