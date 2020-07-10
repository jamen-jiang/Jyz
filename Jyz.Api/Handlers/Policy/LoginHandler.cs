using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jyz.Api.Handlers.Policy
{
    public class LoginHandler : AuthorizationHandler<LoginRequirement>
    {
        public IAuthenticationSchemeProvider Scheme { get; set; }
        private readonly IHttpContextAccessor _accessor;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="scheme"></param>
        /// <param name="accessor"></param>
        public LoginHandler(IAuthenticationSchemeProvider scheme, IHttpContextAccessor accessor)
        {
            Scheme = scheme;
            _accessor = accessor;
        }

        //授权处理
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, LoginRequirement requirement)
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
        }
    }
}
