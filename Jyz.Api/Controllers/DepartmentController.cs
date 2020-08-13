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
    public class DepartmentController : ApiControllerBase
    {
        private readonly IDepartmentService _departmentScv;
        private readonly IPrivilegeService _privilegeSvc;
        private readonly IRoleService _roleSvc;
        private readonly IModuleOperateService _moduleOperateSvc;
        public DepartmentController(IDepartmentService departmentScv, IPrivilegeService privilegeSvc, IRoleService roleSvc,IModuleOperateService moduleOperateSvc)
        {
            _departmentScv = departmentScv;
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
        public async Task<List<DepartmentResponse>> Query([FromBody]DepartmentRequest info)
        {
            return await _departmentScv.Query(info);
        }
        /// <summary>
        /// 获取部门详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Logger("获取模块详情")]
        public async Task<DepartmentResponse> Detail(Guid id)
        {
            return await _departmentScv.Detail(id);
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
            return await _moduleOperateSvc.GetAuthorizeModuleOperateIds(MasterEnum.Department,id);
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
        public async Task<List<RoleResponse>> GetDepartmentRoles(Guid id)
        {
            return await _roleSvc.GetDepartmentRoles(id);
        }
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [Logger("添加部门")]
        public async Task Add(DepartmentAddRequest info)
        {
            await _departmentScv.Add(info);
        }
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [Logger("修改部门信息")]
        public async Task Modify(DepartmentModifyRequest info)
        {
            await _departmentScv.Modify(info);
        }
    }
}
