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
    [Privilege,DisableLog]
    public class OrganizationController : ApiControllerBase
    {
        private readonly IOrganizationService _organizationScv;
        private readonly IPrivilegeService _privilegeSvc;
        private readonly IRoleService _roleSvc;
        private readonly IModuleOperateService _moduleOperateSvc;
        public OrganizationController(IOrganizationService organizationScv, IPrivilegeService privilegeSvc, IRoleService roleSvc,IModuleOperateService moduleOperateSvc)
        {
            _organizationScv = organizationScv;
            _privilegeSvc = privilegeSvc;
            _roleSvc = roleSvc;
            _moduleOperateSvc = moduleOperateSvc;
        }
        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<OrganizationResponse>> Query([FromBody]OrganizationRequest info)
        {
            return await _organizationScv.Query(info);
        }
        /// <summary>
        /// 获取部门详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Logger("获取组织架构详情")]
        public async Task<OrganizationResponse> Detail(Guid id)
        {
            return await _organizationScv.Detail(id);
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
            return await _moduleOperateSvc.GetAuthorizeModuleOperateIds(MasterEnum.Organization,id);
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost, DisableLog]
        public async Task<PageResponse<RoleResponse>> GetRoles([FromBody] PageRequest<RoleRequest> info)
        {
            return await _roleSvc.Query(info);
        }
        /// <summary>
        /// 获取此部门Id的角色列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, DisableLog]
        public async Task<List<RoleResponse>> GetOrganizationRoles(Guid id)
        {
            return await _roleSvc.GetOrganizationRoles(id);
        }
        /// <summary>
        /// 添加组织机构
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [Logger("添加组织机构")]
        public async Task Add(OrganizationAddRequest info)
        {
            await _organizationScv.Add(info);
        }
        /// <summary>
        /// 修改组织机构
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [Logger("修改组织机构信息")]
        public async Task Modify(OrganizationModifyRequest info)
        {
            await _organizationScv.Modify(info);
        }
    }
}
