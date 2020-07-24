using Jyz.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Jyz.Api.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

    }
}
