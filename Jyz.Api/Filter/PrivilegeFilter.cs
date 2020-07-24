﻿using Jyz.Application;
using Jyz.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Jyz.Api.Filter
{
    /// <summary>
    /// 权限过滤
    /// </summary>
    public class PrivilegeFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly IPrivilegeService _privilegeSvc;
        public PrivilegeFilter(IPrivilegeService privilegeSvc)
        {
            _privilegeSvc = privilegeSvc;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //允许匿名访问
            //if (context.HttpContext.User.Identity.IsAuthenticated ||
            //     context.Filters.Any(item => item is IAllowAnonymousFilter)||
            //      context.ActionDescriptor.EndpointMetadata.Any(item => item is AllowAnonymousAttribute))
            //    return;
            if (context.HttpContext.User.Identity.IsAuthenticated ||
                context.ActionDescriptor.EndpointMetadata.Any(item => item is NoPrivilegeFilter || item is AllowAnonymousAttribute))
                return;
            Guid userId = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value.ToGuid();
            if(userId != AppSetting.Project.Admin.ToGuid())
            {
                string controllerName = context.RouteData.Values["controller"].ToString(); ;
                string actionName = context.RouteData.Values["action"].ToString();
                List<PrivilegeResponse> list = _privilegeSvc.GetPrivilegeByUserId(userId);
                if (list.Count(x => x.Controller.Compare(controllerName) && x.Action.Compare(actionName)) <= 0)
                {
                    throw new ApiException(ApiStatusEnum.Fail_UnAuthorized);
                }
            }
        }
    }
    /// <summary>
    /// 不需要权限
    /// </summary>
    public class NoPrivilegeFilter : AuthorizeAttribute
    { 
    
    }
}
