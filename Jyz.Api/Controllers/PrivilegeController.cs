using Jyz.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Jyz.Api.Controllers
{
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
        [HttpGet, Authorize]
        public List<ModuleResponse> GetAuthorizeModules()
        {
            return _privilegeSvc.GetAuthorizeModules(UserContext.UserId);
        }
    }
}
