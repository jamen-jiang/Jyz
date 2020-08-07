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
    public class LogLoginController : ApiControllerBase
    {
        private readonly ILogLoginService _logLoginScv;
        public LogLoginController(ILogLoginService logLoginSvc)
        {
            _logLoginScv = logLoginSvc;
        }
        /// <summary>
        /// 获取登录日志
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PageResponse<LogLoginResponse>> Query([FromBody]PageRequest info)
        {
            return await _logLoginScv.Query(info);
        }
    }
}
