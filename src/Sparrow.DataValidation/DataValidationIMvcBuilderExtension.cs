using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sparrow.DataValidation;
using Sparrow.StandardResult;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// IServiceCollection 扩展
    /// </summary>
    public static class DataValidationIMvcBuilderExtension
    {
        /// <summary>
        /// 添加SparrowDataValidation数据验证不通过时的响应结果
        /// </summary>
        /// <param name="builder">IMvcBuilder</param>
        /// <param name="key">指定<see cref="StandardDto"/>的标识</param>
        /// <returns></returns>
        public static IMvcBuilder AddDefaultSparrowDataValidationApiBehaviorOptions(this IMvcBuilder builder, string key = null)
        {
            builder.ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
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
                    return new ContentResult
                    {
                        ContentType = "application/json",
                        Content = dto.Serialize(),
                        StatusCode = StatusCodes.Status200OK
                    };
                };
            });
            return builder;
        }

        /// <summary>
        /// 添加SparrowDataValidation数据验证不通过时的响应结果
        /// </summary>
        /// <returns></returns>
        public static IMvcBuilder AddSparrowDataValidationApiBehaviorOptions(this IMvcBuilder builder, Action<ApiBehaviorOptions> setupAction)
        {
            builder.ConfigureApiBehaviorOptions(setupAction);
            return builder;
        }
    }
}
