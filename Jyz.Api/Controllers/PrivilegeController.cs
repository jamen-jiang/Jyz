using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jyz.Application.Interfaces;
using Jyz.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jyz.Api.Controllers
{
    [Authorize]
    public class PrivilegeController : BaseController
    {
        private readonly IPrivilegeService _privilegeSvc;
        public PrivilegeController(IPrivilegeService privilegeSvc)
        {
            _privilegeSvc = privilegeSvc;
        }
        /// <summary>
        /// 获取当前用户授权的菜单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<AuthorizeModuleDto> GetAuthorizeModules()
        {
            return _privilegeSvc.GetAuthorizeModules(UserId);
        }
    }
}
