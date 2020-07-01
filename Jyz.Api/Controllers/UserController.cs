using Jyz.Application.Dtos;
using Jyz.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public async Task<string> Login(LoginInfo info)
        {
            string token =  await userSvc.Login(info);
            return token;
        }
    }
}
