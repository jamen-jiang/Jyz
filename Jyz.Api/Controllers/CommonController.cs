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
        private readonly IOrganizationService _organizationSvc;
        private readonly IDictionaryService _dictionaryScv;
        public CommonController(ICommonService commonSvc, IModuleService moduleSvc,IOrganizationService organizationSvc, IDictionaryService dictionaryScv)
        {
            _commonSvc = commonSvc;
            _moduleSvc = moduleSvc;
            _organizationSvc = organizationSvc;
            _dictionaryScv = dictionaryScv;
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
        /// 获取组织机构类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public  List<ComboBoxResponse> GetOrganizationTypes()
        {
            return  _commonSvc.GetComboBoxList<OrganizationTypeEnum>();
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
        /// 获取组织架构树
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ComboBoxTreeResponse>> GetOrganizations()
        {
            return await _organizationSvc.GetOrganizations();
        }
        /// <summary>
        /// 获取字典类型列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ComboBoxResponse>> GetDictionaryCategorys()
        {
            return await _dictionaryScv.GetCategorys();
        }
    }
}
