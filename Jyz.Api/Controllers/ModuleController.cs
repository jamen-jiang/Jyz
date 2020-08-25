using Jyz.Api.Attributes;
using Jyz.Api.Filter;
using Jyz.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jyz.Api.Controllers
{
    [Privilege]
    public class ModuleController : ApiControllerBase
    {
        private readonly IModuleService _moduleSvc;
        public ModuleController(IModuleService moduleSvc)
        {
             _moduleSvc = moduleSvc;
        }
        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Logger("获取模块列表")]
        public async Task<List<ModuleResponse>> Query(ModuleRequest info)
        {
            return await _moduleSvc.Query(info);
        }
        /// <summary>
        /// 获取模块详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Logger("获取模块详情")]
        public async Task<ModuleResponse> Detail(Guid id)
        {
            return await _moduleSvc.Detail(id);
        }
        /// <summary>
        /// 添加模块
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [Logger("添加模块")]
        public async Task Add(ModuleAddRequest info)
        {
            await _moduleSvc.Add(info);
        }
        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [Logger("修改模块")]
        public async Task Modify(ModuleModifyRequest info)
        {
            await _moduleSvc.Modify(info);
        }
    }
}
