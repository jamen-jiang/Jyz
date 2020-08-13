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
        private readonly IModuleOperateService _moduleOperateSvc;
        public RoleController(IRoleService roleSvc, IUserService userSvc, IModuleService moduleSvc, IPrivilegeService privilegeSvc, IModuleOperateService moduleOperateSvc)
        {
            _roleSvc = roleSvc;
            _userSvc = userSvc;
            _moduleSvc = moduleSvc;
            _privilegeSvc = privilegeSvc;
            _moduleOperateSvc = moduleOperateSvc;
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [Logger("获取角色列表")]
        public async Task<PageResponse<RoleResponse>> Query([FromBody]PageRequest<RoleRequest> info)
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
        public async Task<PageResponse<UserResponse>> GetUsers([FromQuery]PageRequest<UserRequest> info)
        {
            return await _userSvc.Query(info);
        }
        /// <summary>
        /// 获取此角色Id的用户列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Logger("获取此角色Id的用户列表")]
        public async Task<List<UserResponse>> GetRoleUsers(Guid id)
        {
            return await _userSvc.GetRoleUsers(id);
        }
        /// <summary>
        /// 获取模块操作列表
        /// </summary>
        /// <returns></returns>
        [HttpGet, DisableLog]
        public async Task<List<ModuleOperateResponse>> GetModuleOperates()
        {
            return await _moduleOperateSvc.GetModuleOperates();
        }
        /// <summary>
        /// 获取授权的模块操作Id列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, DisableLog]
        public async Task<AuthorizeModuleOperateIdsResponse> GetAuthorizeModuleOperateIds(Guid id)
        {
            return await _moduleOperateSvc.GetAuthorizeModuleOperateIds(MasterEnum.Role, id);
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
        public async Task Modify(RoleModifyRequest info)
        {
            await _roleSvc.Save(info);
        }
    }
}
