using Microsoft.AspNetCore.Mvc;
using Sparrow.DataValidation;
using System.Collections.Generic;
using System.Text.Json;

namespace Sparrow.StandardResult.Web
{
    /// <summary>
    /// 模型验证错误信息输出
    /// </summary>
    public static class StardandResultWeb
    {
        internal static StandardResultWebOptions StandardResultWebOptions { get; set; } = new StandardResultWebOptions();
        /// <summary>
        /// 模型验证错误信息处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IActionResult StardandResultModelStateResponse(ActionContext context)
        {
            return StardandResultModelStateResponse(context, default);
        }
        /// <summary>
        /// 模型验证错误信息处理
        /// </summary>
        /// <param name="context"></param>
        /// <param name="key"><see cref="StandardDto"/>构造函数中的key值</param>
        /// <returns></returns>
        public static IActionResult StardandResultModelStateResponse(ActionContext context, string key)
        {
            StandardDto dto = string.IsNullOrWhiteSpace(key) ? new StandardDto() : new StandardDto(key);
            var bad = new BadRequestObjectResult(context.ModelState);
            var json = JsonSerializer.Serialize(bad.Value);
            var errors = JsonSerializer.Deserialize<Dictionary<string, string[]>>(json);
            var list = new List<ModelValidErrorInfo>();
            foreach (var error in errors)
            {
                list.Add(new ModelValidErrorInfo
                {
                    Name = error.Key,
                    Errors = error.Value
                });
            }
            dto.ModelValidResult(list);
            return new ContentResult { Content = dto.Serialize() };
        }
    }
}
