using Jyz.Infrastructure.Extensions;
using Jyz.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authorization;
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
        /// <summary>
        /// 当前用户Id
        /// </summary>
        public Guid UserId
        {
            get
            {
                return  HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value.ToGuid();
            }
        }
    }
}
