using Microsoft.AspNetCore.Mvc;

namespace Sparrow.StandardResult.Web
{
    /// <summary>
    /// 错误处理
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        /// <summary>
        /// 错误处理
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route(WebValues.ErrorTemplatePath)]
        public IActionResult Error()
        {
            StandardDto dto = string.IsNullOrWhiteSpace(WebValues.StardandKey) ?
                new StandardDto() : new StandardDto(WebValues.StardandKey);
            dto.ExceptionResult();
            return Ok(dto.Serialize());
        }
    }
}
