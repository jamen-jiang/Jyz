using Jyz.Api.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jyz.Api.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    [Authorize,ValidateModel,ApiResponse]
    public class ApiControllerBase : ControllerBase
    {

    }
}
