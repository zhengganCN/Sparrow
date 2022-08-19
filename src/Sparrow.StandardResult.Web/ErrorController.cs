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
            Dto dto = string.IsNullOrWhiteSpace(WebValues.StardandKey) ?
                new Dto() : new Dto(WebValues.StardandKey);
            dto.ExceptionResult();
            return Ok(dto.Serialize());
        }
    }
}
