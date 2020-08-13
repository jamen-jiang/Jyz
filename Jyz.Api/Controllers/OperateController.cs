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
        public async Task<List<ModuleResponse>> GetModules(ModuleRequest info)
        {
            return await _moduleSvc.Query(info);
        }
        /// <summary>
        /// 获取对应的功能列表
        /// </summary>
        /// <returns></returns>
        [HttpPost, DisableLog]
        public async Task<PageResponse<OperateResponse>> Query(PageRequest<OperateRequest> info)
        {
            return await _operateSvc.Query(info);
        }
        [HttpGet, DisableLog]
        public async Task<OperateResponse> Detail(Guid id)
        {
            return await _operateSvc.Detail(id);
        }
        [HttpPost]
        [Logger("添加功能")]
        public async Task Add(OperateAddRequest info)
        {
            await _operateSvc.Add(info);
        }
        [HttpPost]
        [Logger("修改功能")]
        public async Task Modify(OperateModifyRequest info)
        {
            await _operateSvc.Modify(info);
        }
    }
}
