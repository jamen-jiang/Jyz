using Jyz.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jyz.Api.Controllers
{
    [Authorize(Policy = "Permission")]
    public class OperateController : BaseController
    {
        private readonly IModuleService _moduleSvc;
        private readonly IOperateService _operateSvc;
        public OperateController(IModuleService moduleSvc, IOperateService operateSvc)
        {
            _moduleSvc = moduleSvc;
            _operateSvc = operateSvc;
        }
        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ModuleResponse>> GetModules()
        {
            return await _moduleSvc.Get();
        }
        /// <summary>
        /// 获取对应的功能列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<OperateResponse>> Get(Guid moduleId)
        {
            return await _operateSvc.Get(moduleId);
        }
        [HttpGet]
        public async Task<OperateResponse> Detail(Guid id)
        {
            return await _operateSvc.Detail(id);
        }
        [HttpPost]
        public async Task Add(OperateRequest info)
        {
            await _operateSvc.Add(info);
        }
        [HttpPost]
        public async Task Modify(OperateRequest info)
        {
            await _operateSvc.Modify(info);
        }
    }
}
