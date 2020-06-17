using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jyz.Api.Filter
{
    public class ApiResultFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var objectResult = context.Result as ObjectResult;
            context.Result = new ObjectResult(objectResult.Value);
            base.OnResultExecuting(context);
        }
    }
}
