using Jyz.Api.Filter;
using Jyz.Application.Interfaces;
using Jyz.Application.ViewModels;
using Jyz.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Jyz.Api.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPrivilegeService PrivilegeSvc;
        public HomeController(IPrivilegeService privilegeSvc)
        {
            PrivilegeSvc = privilegeSvc;
        }
        [HttpPost, NoPrivilegeFilter]
        public ModuleVM Index()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value.ToGuid();
            return PrivilegeSvc.GetModuleList(userId);
        }
    }
}
