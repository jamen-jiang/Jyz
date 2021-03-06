﻿using Jyz.Api.Attributes;
using Jyz.Application;
using Jyz.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Jyz.Api.Filter
{
    public class LogActionFilter : IAsyncActionFilter
    {
        private readonly ILogOperateService _logService;
        public LogActionFilter(ILogOperateService logService)
        {
            _logService = logService;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionDescriptor.EndpointMetadata.Any(m => m.GetType() == typeof(DisableLogAttribute)))
            {
                await next();
                return;
            }
            var sw = new Stopwatch();
            sw.Start();
            var actionResult = (await next()).Result;
            sw.Stop();
            LoggerAttribute loggerAttribute = context.ActionDescriptor.EndpointMetadata.OfType<LoggerAttribute>().FirstOrDefault();
            LogOperateRequest info = new LogOperateRequest()
            {
                UserName = CurrentUser.UserName,
                ApiName = loggerAttribute?.Remark?? context.ActionDescriptor.AttributeRouteInfo.Template,
                ApiUrl = context.ActionDescriptor.AttributeRouteInfo.Template,
                ApiMethod = context.HttpContext.Request.Method.ToLower(),
                ElapsedMilliseconds = sw.ElapsedMilliseconds,
                IsSuccess = actionResult != null,
            };
            await _logService.Add(info);
        }
    }
}
