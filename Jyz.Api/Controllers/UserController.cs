using Jyz.Api.Filter;
using Jyz.Application.Dtos;
using Jyz.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jyz.Api.Controllers
{
    
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
        public async Task<LoginResDto> Login(LoginReqDto info)
        {
            return await userSvc.Login(info);
        }
    }
}
