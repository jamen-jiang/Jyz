using Jyz.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jyz.Api.Filter
{
    public class ApiResultFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var objectResult = context.Result as ObjectResult;
            ApiResponse response = new ApiResponse(objectResult.Value);
            context.Result = new ObjectResult(response);
            base.OnResultExecuting(context);
        }
    }
}
