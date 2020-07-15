using Jyz.Api.Filter;
using Jyz.Application.Dtos;
using Jyz.Application.Interfaces;
using Jyz.Application.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public async Task<LoginResDto> Login(LoginReqDto info)
        {
            return await userSvc.Login(info);
        }
        [HttpGet]
        public async Task<ApiResponse> Get(int pageIndex = 1,int pageSize = 10)
        {
            return await userSvc.Get(pageIndex, pageSize);
        }
    }
}
