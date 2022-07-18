using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Sparrow.DataValidation
{
    internal static class ModelValidStaticValues
    {
        internal static ModelValidOptions ValidOptions { get; set; } = new ModelValidOptions();
        internal static Dictionary<string, Func<ModelValidErrorInfo[], IActionResult>> FormatErrors = new Dictionary<string, Func<ModelValidErrorInfo[], IActionResult>>();

        /// <summary>
        /// 默认格式化函数Key
        /// </summary>
        internal const string DefaultFormatKey = "PSoil7G35egZ";
    }
}
