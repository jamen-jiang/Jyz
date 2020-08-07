using Jyz.Api.Attributes;
using Jyz.Api.Filter;
using Jyz.Application;
using Jyz.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jyz.Api.Controllers
{
    [Privilege]
    public class RoleController : ApiControllerBase
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
        [HttpPost]
        [Logger("获取角色列表")]
        public async Task<PageResponse<RoleResponse>> Query([FromQuery]PageRequest info)
        {
            return await _roleSvc.Query(info);
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpGet]
        [Logger("获取用户列表")]
        public async Task<PageResponse<UserResponse>> GetUsers([FromQuery]PageRequest<UserQuery> info)
        {
            return await _userSvc.Query(info);
        }
        /// <summary>
        /// 获取此角色Id的用户列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        [Logger("获取此角色Id的用户列表")]
        public async Task<List<UserResponse>> GetRoleUsers(Guid roleId)
        {
            return await _userSvc.GetRoleUsers(roleId);
        }
        /// <summary>
        /// 获取模块列表及此角色Id的权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        [Logger("获取模块列表及此角色Id的权限")]
        public async Task<ModuleAndPrivilegeResponse> GetModuleAndPrivilege(Guid roleId)
        {
            return await _privilegeSvc.GetModuleAndPrivilege(MasterEnum.Role, roleId);
        }
        /// <summary>
        /// 获取角色详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Logger("获取角色详情")]
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
        [Logger("修改角色信息")]
        public async Task Modify(RoleRequest info)
        {
            await _roleSvc.Save(info);
        }
    }
}
