using Jyz.Api.Attributes;
using Jyz.Api.Filter;
using Jyz.Application;
using Jyz.Domain.Enums;
using Jyz.Infrastructure;
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
        private readonly IOrganizationService _organizationScv;
        private readonly IPrivilegeService _privilegeSvc;
        private readonly IRoleService _roleSvc;
        private readonly ILogLoginService _logLoginSvc;
        private readonly IModuleOperateService _moduleOperateSvc;
        private readonly ICache _cache;
        public UserController(IUserService userSvc, IOrganizationService organizationScv, IPrivilegeService privilegeSvc, IRoleService roleSvc,ILogLoginService logLoginSvc, IModuleOperateService moduleOperateSvc, ICache cache)
        {
            _userSvc = userSvc;
            _organizationScv = organizationScv;
            _privilegeSvc = privilegeSvc;
            _roleSvc = roleSvc;
            _logLoginSvc = logLoginSvc;
            _moduleOperateSvc = moduleOperateSvc;
            _cache = cache;
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
        /// 登出
        /// </summary>
        [HttpGet]
        public void Logout()
        {
            _cache.Clear();
        }
        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<UserResponse> GetInformation()
        {
            return await _userSvc.Detail(CurrentUser.UserId);
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PageResponse<UserResponse>> Query([FromBody]PageRequest<UserRequest> info)
        {
            return await _userSvc.Query(info);
        }
        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<UserResponse> Detail(Guid id)
        {
            return await _userSvc.Detail(id);
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PageResponse<RoleResponse>> GetRoles([FromBody] PageRequest<RoleRequest> info)
        {
            return await _roleSvc.Query(info);
        }
        /// <summary>
        /// 获取此用户Id的角色列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<RoleResponse>> GetUserRoles(Guid id)
        {
            return await _roleSvc.GetUserRoles(id);
        }
        /// <summary>
        /// 获取模块操作列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ModuleOperateResponse>> GetModuleOperates()
        {
            return await _moduleOperateSvc.GetModuleOperates();
        }
        /// <summary>
        /// 获取授权的模块操作Id列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<AuthorizeModuleOperateIdsResponse> GetAuthorizeModuleOperateIds(Guid id)
        {
            return await _moduleOperateSvc.GetAuthorizeModuleOperateIds(MasterEnum.User, id);
        }
        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<OrganizationResponse>> GetOrganizations([FromBody] OrganizationRequest info)
        {
            return await _organizationScv.Query(info);
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
        /// <summary>
        /// 更新个人信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task ModifyProfile(ProfileRequest info)
        {
            await _userSvc.ModifyProfile(info);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task ChangePassWord(PassWordRequest info)
        {
            await _userSvc.ChangePassWord(info);
        }
    }
}
