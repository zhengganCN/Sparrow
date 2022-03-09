using Microsoft.AspNetCore.Mvc.Filters;

namespace Sparrow.DataValidation
{
    /// <summary>
    /// 模型验证拦截器
    /// </summary>
    public sealed class ValidationModelFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 在函数执行前验证
        /// </summary>
        /// <param name="context">上下文</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //if (!context.ModelState.IsValid)
            //{
            //    var badRequestObjectResult = new BadRequestObjectResult(context.ModelState);
            //    var modelResult = new ModelResult().FailedResult(EnumModelError.ModelVaildFaild,
            //        JsonConvert.SerializeObject(badRequestObjectResult.Value));
            //    context.Result = new JsonResult(modelResult);
            //}
        }
    }
}
