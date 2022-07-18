using Microsoft.AspNetCore.Mvc;
using System;

namespace Sparrow.DataValidation
{
    /// <summary>
    /// 模型验证选项
    /// </summary>
    public class ModelValidOptions
    {
        /// <summary>
        /// 添加默认格式化错误信息
        /// </summary>
        public void AddDefaultFormatErrors(Func<ModelValidErrorInfo[], IActionResult> func)
        {
            if (func is null)
            {
                throw new ArgumentNullException($"{nameof(func)}");
            }
            if (ModelValidStaticValues.FormatErrors.ContainsKey(ModelValidStaticValues.DefaultFormatKey))
            {
                throw new ArgumentException($"已存在key为{ModelValidStaticValues.DefaultFormatKey}的格式化函数");
            }
            ModelValidStaticValues.FormatErrors.Add(ModelValidStaticValues.DefaultFormatKey, func);
        }

        /// <summary>
        /// 添加格式化错误信息
        /// </summary>
        public void AddFormatErrors(string key, Func<ModelValidErrorInfo[], IActionResult> func)
        {
            if (func is null)
            {
                throw new ArgumentNullException($"{nameof(func)}");
            }
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException($"参数{nameof(key)}的值无效");
            }
            if (ModelValidStaticValues.FormatErrors.ContainsKey(key))
            {
                throw new ArgumentException($"已存在{nameof(key)}为{key}的格式化函数");
            }
            ModelValidStaticValues.FormatErrors.Add(key, func);
        }
    }
}
