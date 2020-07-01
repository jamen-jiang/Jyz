using Jyz.Application.Enums;
using Jyz.Application.Exception;
using Jyz.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Jyz.Api.Filter
{
    public class TokenFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //允许匿名访问
            if (context.HttpContext.User.Identity.IsAuthenticated ||
                 context.Filters.Any(item => item is IAllowAnonymousFilter))
                return;
            var request = context.HttpContext.Request;
            var token = request.Headers["Token"].ToString();
            if (token.IsNullOrEmpty())
                throw new ApiException(ApiStatusEnum.FAIL_TOKEN_UNVALID);
            //if (!JwtUtils.TryGetJwtDecode(token, out Payload payload))
            //    throw new ApiException(ApiStatusEnum.EXPIRED_TOKEN_UNVALID);
        }
    }
}
