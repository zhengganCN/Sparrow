using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sparrow.DataValidation;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 模型验证特性
    /// </summary>
    /// <remarks>
    /// 验证不通过则返回<see cref="StandardDto"/>结构
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class StandardModelResultAttribute : Attribute, IActionFilter
    {
        /// <summary>
        /// <see cref="StandardDto"/>构造函数中的key值
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 无
        /// </summary>
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        /// <summary>
        /// 验证模型并根据key返回格式化输出
        /// </summary>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                StandardDto dto = string.IsNullOrWhiteSpace(Key) ?
                    new StandardDto() : new StandardDto(Key);
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
                context.Result = new JsonResult(dto);
            }
        }
    }
}
