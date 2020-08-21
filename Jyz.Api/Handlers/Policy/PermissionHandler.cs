using Jyz.Application;
using Jyz.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jyz.Api.Handlers.Policy
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        public IAuthenticationSchemeProvider Scheme { get; set; }
        private readonly IHttpContextAccessor _accessor;
        private readonly IPrivilegeService _privilegeSvc;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="scheme"></param>
        /// <param name="accessor"></param>
        /// <param name="privilegeSvc"></param>
        public PermissionHandler(IAuthenticationSchemeProvider scheme, IHttpContextAccessor accessor, IPrivilegeService privilegeSvc)
        {
            Scheme = scheme;
            _accessor = accessor;
            _privilegeSvc = privilegeSvc;
        }

        //授权处理
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var httpContext = _accessor.HttpContext;
            //获取授权方式
            var defaultAuthenticate = await Scheme.GetDefaultAuthenticateSchemeAsync();
            if (defaultAuthenticate != null)
            {
                //验证签发的用户信息
                var result = await httpContext.AuthenticateAsync(defaultAuthenticate.Name);
                if (result.Succeeded)
                {
                    httpContext.User = result.Principal;
                    Guid userId =httpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value.ToGuid();
                    if (userId != AppSetting.SystemConfig.Admin.ToGuid())
                    {
                        string controllerName =  httpContext.Request.RouteValues["controller"].ToString(); ;
                        string actionName = httpContext.Request.RouteValues["action"].ToString();
                        var list = await  _privilegeSvc.GetOperateUrlsByUserId(userId);
                        if (list.Count(x => x.Controller.Compare(controllerName) && x.Action.Compare(actionName)) <= 0)
                        {
                            throw new ApiException(ApiStatusEnum.Fail_UnAuthorized);
                        }
                    }
                    //判断是否过期
                    if (DateTime.Parse(httpContext.User.Claims.SingleOrDefault(s => s.Type == ClaimTypes.Expiration).Value) >= DateTime.UtcNow)
                    {
                        context.Succeed(requirement);
                    }
                    else
                    {
                        context.Fail();
                    }
                    return;
                }
            }
            context.Fail();
            return;
        }
    }
}
