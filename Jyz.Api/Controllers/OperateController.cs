using Jyz.Api.Attributes;
using Jyz.Api.Filter;
using Jyz.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Jyz.Api.Controllers
{
    [Privilege]
    public class OperateController : ApiControllerBase
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
        [HttpPost, DisableLog]
        public async Task<List<ModuleResponse>> GetModules()
        {
            return await _moduleSvc.Query();
        }
        /// <summary>
        /// 获取对应的功能列表
        /// </summary>
        /// <returns></returns>
        [HttpGet, DisableLog]
        public async Task<List<OperateResponse>> Query(Guid moduleId)
        {
            return await _operateSvc.Query(moduleId);
        }
        [HttpGet, DisableLog]
        public async Task<OperateResponse> Detail(Guid id)
        {
            return await _operateSvc.Detail(id);
        }
        [HttpPost]
        [Logger("添加功能")]
        public async Task Add(OperateRequest info)
        {
            await _operateSvc.Add(info);
        }
        [HttpPost]
        [Logger("修改功能")]
        public async Task Modify(OperateRequest info)
        {
            await _operateSvc.Modify(info);
        }
    }
}
