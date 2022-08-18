using Microsoft.AspNetCore.Mvc;

namespace Sparrow.StandardResult.Web
{
    /// <summary>
    /// 错误处理
    /// </summary>
    public class ErrorController : ControllerBase
    {
        [HttpGet, Route(WebValues.ErrorTemplatePath)]
        public IActionResult Error()
        {
            var dto = new Dto();
            dto.ExceptionResult();
            return new JsonResult(dto.Format());
        }
    }
}
