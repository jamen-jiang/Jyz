using Jyz.Application;
using Jyz.Domain;
using Jyz.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Jyz.Api.Filter
{
    /// <summary>
    /// 权限过滤
    /// </summary>
    public class PrivilegeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //允许匿名访问
            //if (context.HttpContext.User.Identity.IsAuthenticated ||
            //     context.Filters.Any(item => item is IAllowAnonymousFilter)||
            //      context.ActionDescriptor.EndpointMetadata.Any(item => item is AllowAnonymousAttribute))
            //    return;
            if (context.HttpContext.User.Identity.IsAuthenticated ||
                context.ActionDescriptor.EndpointMetadata.Any(item => item is NoPrivilegeAttribute || item is AllowAnonymousAttribute))
                return;
            if(CurrentUser.UserId != AppSetting.Project.Admin.ToGuid())
            {
                string controllerName = context.RouteData.Values["controller"].ToString(); ;
                string actionName = context.RouteData.Values["action"].ToString();
                //获取权限接口
                var privilegeSvc = CurrentUser.GetService<IPrivilegeService>();
                List<PrivilegeResponse> list = privilegeSvc.GetPrivilegeByUserId(CurrentUser.UserId);
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
    public class NoPrivilegeAttribute : AuthorizeAttribute
    { 
    
    }
}
