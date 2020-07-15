using Jyz.Api.Handlers.Policy;
using Jyz.Application.Enums;
using Jyz.Application.Response;
using Jyz.Infrastructure.Configuration;
using Jyz.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Jyz.Api.Extensions
{
    public static class JwtSetup
    {
        public static void AddJwtSetup(this IServiceCollection services)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSetting.Jwt.Secret));
            // 令牌验证参数
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,//是否验证SecurityKey
                IssuerSigningKey = signingKey,
                ValidIssuer = AppSetting.Jwt.Issuer,//发行人
                ValidateIssuer = true,//是否验证Issuer
                ValidAudience = AppSetting.Jwt.Audience,//订阅人
                ValidateAudience = true,//是否验证Audience
                ValidateLifetime = true,//是否验证失效时间
                RequireExpirationTime = true,//是否要求过期
            };
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Permission", policy => policy.Requirements.Add(new PermissionRequirement()));
            }).AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = nameof(ApiResponseHandler);
                options.DefaultForbidScheme = nameof(ApiResponseHandler);
            }).AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = tokenValidationParameters;
                  options.Events = new JwtBearerEvents()
                  {
                      OnAuthenticationFailed = context =>
                        {
                            // token过期
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                  };
              }).AddScheme<AuthenticationSchemeOptions, ApiResponseHandler>(nameof(ApiResponseHandler), o => { });
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();
        }
    }
}
