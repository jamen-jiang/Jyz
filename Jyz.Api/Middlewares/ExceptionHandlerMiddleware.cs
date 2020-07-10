﻿using Jyz.Application.Enums;
using Jyz.Application.Exception;
using Jyz.Application.Response;
using Jyz.Infrastructure.Extensions;
using Jyz.Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Jyz.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            if (ex == null) return;

            Logger.Error("请求处理异常" + ex.Message, ex);

            await WriteExceptionAsync(context, ex).ConfigureAwait(false);
        }

        private static async Task WriteExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json";
            ApiResponse response = new ApiResponse();
            if (ex is ApiException)
            {
                ApiException apiException = ex as ApiException;
                response.Status = apiException.Code;
                response.Message = apiException.Message;
            }
            else
            {
                response.Status = (int)ApiStatusEnum.FAIL_EXCEPTION;
                response.Message = "系统错误";
            }
            await context.Response.WriteAsync(response.ToJson()).ConfigureAwait(false);
        }
    }
}