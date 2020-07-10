﻿using Jyz.Application.Enums;
using Jyz.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Jyz.Api.Filter
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class ApiResultAndValidateModelFilterAttribute : ActionFilterAttribute , IActionFilter
    {
        /// <summary>
        /// 模型验证
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ApiResponse response = new ApiResponse();
                response.Status = (int)ApiStatusEnum.FAIL_APP;
                foreach (var item in context.ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        response.Message += error.ErrorMessage + "|";
                    }
                }
                context.Result = new ObjectResult(response);
            }
            base.OnActionExecuting(context);
        }
        /// <summary>
        /// 统一返回值
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var objectResult = context.Result as ObjectResult;
            ApiResponse response = new ApiResponse(objectResult.Value);
            context.Result = new ObjectResult(response);
            base.OnActionExecuted(context);
        }
    }
}