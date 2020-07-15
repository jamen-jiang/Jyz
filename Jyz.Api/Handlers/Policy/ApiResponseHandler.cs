using Jyz.Application.Enums;
using Jyz.Application.Response;
using Jyz.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Jyz.Api.Handlers.Policy
{
    public class ApiResponseHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public ApiResponseHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            throw new NotImplementedException();
        }
        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.ContentType = "application/json";
            Response.StatusCode = (int)HttpStatusCode.OK;
            ApiResponse response = new ApiResponse();
            if (Response.Headers["Token-Expired"] == "true")
                response.Status = (int)ApiStatusEnum.Fail_Token_Expired;
            else
                response.Status = (int)ApiStatusEnum.Fail_UnAuthorized;
            await Response.WriteAsync(response.ToJson());
        }

        protected override async Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            Response.ContentType = "application/json";
            Response.StatusCode = (int)HttpStatusCode.OK;
            ApiResponse response = new ApiResponse(ApiStatusEnum.Fail_Forbidden);
            await Response.WriteAsync(response.ToJson());
        }
    }
}
