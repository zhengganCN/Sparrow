using Microsoft.AspNetCore.Mvc;
using Sparrow.DataValidation;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System;
using System.Text.Json;

namespace Sparrow.StandardResult.Web
{
    public static class StardandResultWeb
    {
        public static IActionResult StardandResultModelStateResponse(ActionContext context)
        {
            return StardandResultModelStateResponse(context, default);
        }

        public static IActionResult StardandResultModelStateResponse(ActionContext context, string key)
        {
            Dto dto = string.IsNullOrWhiteSpace(key) ? new Dto() : new Dto(key);
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
