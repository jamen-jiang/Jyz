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
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userSvc;
        private readonly IPrivilegeService _privilegeSvc;
        private readonly IRoleService _roleSvc;
        private readonly ILogLoginService _logLoginSvc;
        public UserController(IUserService userSvc, IPrivilegeService privilegeSvc, IRoleService roleSvc,ILogLoginService logLoginSvc)
        {
            _userSvc = userSvc;
            _privilegeSvc = privilegeSvc;
            _roleSvc = roleSvc;
            _logLoginSvc = logLoginSvc;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpPost, AllowAnonymous, DisableLog]
        public async Task<LoginResponse> Login(LoginRequest info)
        {
            var res = await _userSvc.Login(info);
            LogLoginRequest model = new LogLoginRequest()
            {
                UserName = info.UserName
            };
            await _logLoginSvc.Add(model);
            return res;
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost, DisableLog]
        public async Task<PageResponse<UserResponse>> Query([FromBody]PageRequest<UserQuery> info)
        {
            return await _userSvc.Query(info);
        }
        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, DisableLog]
        public async Task<UserResponse> Detail(Guid id)
        {
            return await _userSvc.Detail(id);
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost, DisableLog]
        public async Task<PageResponse<RoleResponse>> GetRoles([FromBody] PageRequest info)
        {
            return await _roleSvc.Query(info);
        }
        /// <summary>
        /// 获取此用户Id的角色列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, DisableLog]
        public async Task<List<RoleResponse>> GetUserRoles(Guid id)
        {
            return await _roleSvc.GetUserRoles(id);
        }
        /// <summary>
        /// 获取模块列表及此用户Id的权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet, DisableLog]
        public async Task<ModuleAndPrivilegeResponse> GetModuleAndPrivilege(Guid userId)
        {
            return await _privilegeSvc.GetModuleAndPrivilege(MasterEnum.User,userId);
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [Logger("添加用户")]
        public async Task Add(UserAddRequest info)
        {
            await _userSvc.Add(info);
        }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [Logger("修改用户信息")]
        public async Task Modify(UserModifyRequest info)
        {
            await _userSvc.Modify(info);
        }
    }
}
