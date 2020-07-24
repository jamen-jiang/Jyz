using Jyz.Domain;
using Jyz.Infrastructure;
using Jyz.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jyz.Application
{
    public static class UserContext
    {
        public static HttpContext HttpContext
        {
            get
            {
                return GetService<IHttpContextAccessor>().HttpContext;
            }
        }
        public static User User
        {
            get 
            {
                return new JyzContext().Set<User>().FindById(UserId);
            }
        }
        public static Guid UserId
        {
            get
            {
                return HttpContext.User.FindFirstValue(JwtRegisteredClaimNames.Jti).ToGuid();
            }
        }
        public static string UserName
        {
            get
            {
                return HttpContext.User.FindFirstValue(ClaimTypes.Name)?.ToString();
            }
        }
        private static T GetService<T>() where T : class
        {
            return AppSetting.Provider.GetRequiredService<T>();
        }
    }
}
