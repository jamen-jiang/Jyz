using Jyz.Api.Attributes;
using Jyz.Api.Filter;
using Jyz.Application;
using Jyz.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jyz.Api.Controllers
{
    public class PrivilegeController : ApiControllerBase
    {
        private readonly IPrivilegeService _privilegeSvc;
        private readonly IModuleOperateService _moduleOperateSvc;
        public PrivilegeController(IPrivilegeService privilegeSvc, IModuleOperateService moduleOperateSvc)
        {
            _privilegeSvc = privilegeSvc;
            _moduleOperateSvc = moduleOperateSvc;
        }
        /// <summary>
        /// 获取当前用户授权的菜单操作列表
        /// </summary>
        /// <returns></returns>
        [HttpGet,NoPrivilege]
        [Logger("获取当前用户授权的菜单列表")]
        public async Task<List<ModuleOperateResponse>> GetAuthorizeModuleOperates()
        {
            return await _moduleOperateSvc.GetAuthorizeModuleOperates(CurrentUser.UserId);
        }
    }
}
