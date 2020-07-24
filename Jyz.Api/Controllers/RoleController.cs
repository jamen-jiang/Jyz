using Jyz.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jyz.Api.Controllers
{
    [Authorize(Policy = "Permission")]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleSvc;
        private readonly IUserService _userSvc;
        private readonly IModuleService _moduleSvc;
        private readonly IPrivilegeService _privilegeSvc;
        public RoleController(IRoleService roleSvc, IUserService userSvc, IModuleService moduleSvc, IPrivilegeService privilegeSvc)
        {
            _roleSvc = roleSvc;
            _userSvc = userSvc;
            _moduleSvc = moduleSvc;
            _privilegeSvc = privilegeSvc;
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PageResDto<RoleResponse>> Get([FromQuery]PageReqDto info)
        {
            return await _roleSvc.Get(info);
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PageResDto<UserResponse>> GetUsers([FromQuery]PageReqDto info)
        {
            return await _userSvc.Get(info);
        }
        /// <summary>
        /// 根据角色Id获取用户列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<UserResponse>> GetRoleUsers(Guid roleId)
        {
            return await _userSvc.GetRoleUsers(roleId);
        }
        /// <summary>
        /// 获取模块树及权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ModuleAndPrivilegeResponse> GetModuleAndPrivilege(Guid roleId)
        {
            return await _privilegeSvc.GetModuleAndPrivilege(roleId);
        }
        /// <summary>
        /// 根据Id获取角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<RoleResponse> Detail(Guid id)
        {
            return await _roleSvc.Detail(id);
        }
        /// <summary>
        /// 角色信息修改
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Modify(RoleRequest info)
        {
            await _roleSvc.Save(info);
        }
    }
}
