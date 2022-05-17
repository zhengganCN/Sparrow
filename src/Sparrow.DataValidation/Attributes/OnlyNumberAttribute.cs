using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Sparrow.DataValidation.Attributes
{
    /// <summary>
    /// 字符串只能包含数字特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class OnlyNumberAttribute : ValidationAttribute
    {
        /// <summary>
        /// 重写验证逻辑
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value is null)
            {
                return true;
            }
            var result = false;
            if (value is string @string)
            {
                result = !Regex.IsMatch(@string, @"[^0-9]");
            }
            return result;
        }
    }
}
