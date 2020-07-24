using Jyz.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jyz.Api.Controllers
{
    [Authorize(Policy = "Permission")]
    public class UserController : BaseController
    {
        private readonly IUserService userSvc;
        public UserController(IUserService userSvc)
        {
            this.userSvc = userSvc;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost, AllowAnonymous]
        public async Task<LoginResponse> Login(LoginRequest info)
        {
            return await userSvc.Login(info);
        }
        [HttpGet]
        public async Task<PageResDto<UserResponse>> Get([FromQuery]PageReqDto info)
        {
            return await userSvc.Get(info);
        }
    }
}
