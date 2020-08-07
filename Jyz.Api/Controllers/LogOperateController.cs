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
    public class LogOperateController : ApiControllerBase
    {
        private readonly ILogOperateService _logOperateScv;
        public LogOperateController(ILogOperateService logOperateSvc)
        {
            _logOperateScv = logOperateSvc;
        }
        /// <summary>
        /// 获取操作日志
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PageResponse<LogOperateResponse>> Query([FromBody]PageRequest info)
        {
            return await _logOperateScv.Query(info);
        }
    }
}
