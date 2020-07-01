using Jyz.Application.Enums;
using Jyz.Application.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jyz.Api.Filter
{
    public class ValidateModelFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ApiResponse response = new ApiResponse();
                response.Status = (int)ApiStatusEnum.FAIL_APP;
                foreach (var item in context.ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        response.Message += error.ErrorMessage + "|";
                    }
                }
                context.Result = new ObjectResult(response);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
