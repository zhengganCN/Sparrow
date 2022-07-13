using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.DataValidation
{
    /// <summary>
    /// 模型验证选项
    /// </summary>
    public class ModelValidOptions
    {
        internal static readonly Dictionary<string, Func<ModelValidErrorInfo[], IActionResult>> FormatErrorInfos = new Dictionary<string, Func<ModelValidErrorInfo[], IActionResult>>();

        /// <summary>
        /// 默认格式化函数Key
        /// </summary>
        internal const string DefaultFormatFuncKey = "PSoil7G35egZ";

        /// <summary>
        /// 添加默认格式化错误信息
        /// </summary>
        public static void AddDefaultFormatErrorInfo(Func<ModelValidErrorInfo[], IActionResult> func)
        {
            if (func is null)
            {
                throw new ArgumentNullException($"{nameof(func)}");
            }
            if (FormatErrorInfos.ContainsKey(DefaultFormatFuncKey))
            {
                throw new ArgumentException($"已存在key为{DefaultFormatFuncKey}的格式化函数");
            }
            FormatErrorInfos.Add(DefaultFormatFuncKey, func);
        }

        /// <summary>
        /// 添加格式化错误信息
        /// </summary>
        public static void AddFormatErrorInfo(string key, Func<ModelValidErrorInfo[], IActionResult> func)
        {
            if (func is null)
            {
                throw new ArgumentNullException($"{nameof(func)}");
            }
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"参数{nameof(key)}的值无效");
            }
            if (FormatErrorInfos.ContainsKey(key))
            {
                throw new ArgumentException($"已存在{nameof(key)}为{key}的格式化函数");
            }
            FormatErrorInfos.Add(key, func);
        }
    }
}
