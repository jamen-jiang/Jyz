using Jyz.Api.Attributes;
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
    /// <summary>
    /// 公用接口
    /// </summary>
    [AllowAnonymous, DisableLog]
    public class CommonController : ApiControllerBase
    {
        private readonly ICommonService _commonSvc;
        private readonly IModuleService _moduleSvc;
        private readonly IDepartmentService _departmentSvc;
        public CommonController(ICommonService commonSvc, IModuleService moduleSvc,IDepartmentService departmentSvc)
        {
            _commonSvc = commonSvc;
            _moduleSvc = moduleSvc;
            _departmentSvc = departmentSvc;
    }
        /// <summary>
        /// 获取功能类型列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ComboBoxResponse> GetOperateTypes()
        {
            return _commonSvc.GetComboBoxList<OperateTypeEnum>();
        }
        /// <summary>
        /// 获取模块类型列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ComboBoxResponse> GetModuleTypes()
        {
            return _commonSvc.GetComboBoxList<ModuleTypeEnum>();
        }
        /// <summary>
        /// 获取模块目录树
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ComboBoxTreeResponse>> GetModuleCatalogs()
        {
            return await _moduleSvc.GetModuleCatalogs();
        }
        /// <summary>
        /// 获取模块树
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ComboBoxTreeResponse>> GetModules()
        {
            return await _moduleSvc.GetModules();
        }
        /// <summary>
        /// 获取部门树
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ComboBoxTreeResponse>> GetDepartments()
        {
            return await _departmentSvc.GetDepartments();
        }
    }
}
