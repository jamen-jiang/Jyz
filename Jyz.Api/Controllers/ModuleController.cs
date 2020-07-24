using Jyz.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jyz.Api.Controllers
{
    [Authorize(Policy = "Permission")]
    public class ModuleController : BaseController
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
        [HttpGet]
        public async Task<List<ModuleResponse>> Get()
        {
            return await _moduleSvc.Get(true);
        }
    }
}
