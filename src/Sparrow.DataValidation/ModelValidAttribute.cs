using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Sparrow.DataValidation
{
    /// <summary>
    /// 模型验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ModelValidAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 格式化函数Key;ModelValidOptions中设置的格式化函数key
        /// </summary>
        public string FormatFuncKey { get; set; }
        
        /// <summary>
        /// 验证逻辑
        /// </summary>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = new BadRequestObjectResult(context.ModelState);
                var json = JsonSerializer.Serialize(errors.Value);
                var errorDic = JsonSerializer.Deserialize<Dictionary<string, string[]>>(json);
                var list = new List<ModelValidErrorInfo>();
                foreach (var pair in errorDic)
                {
                    list.Add(new ModelValidErrorInfo
                    {
                        Name = pair.Key,
                        Errors = pair.Value
                    });
                }
                Func<ModelValidErrorInfo[], IActionResult> func;
                var pairs = ModelValidOptions.FormatErrorInfos;
                if (pairs.TryGetValue(ModelValidOptions.DefaultFormatFuncKey, out func))
                {
                    context.Result = func.Invoke(list.ToArray());
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(FormatFuncKey))
                    {
                        context.Result = new JsonResult(list);
                    }
                    else
                    {
                        if (pairs.TryGetValue(FormatFuncKey, out func))
                        {
                            context.Result = func.Invoke(list.ToArray());
                        }
                        else
                        {
                            context.Result = new JsonResult(list);
                        }
                    }
                }
            }
        }
    }
}
