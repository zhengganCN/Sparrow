using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sparrow.DataValidation.Attributes
{
    /// <summary>
    /// 字符串没有空格验证特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class NoSpaceAttribute : ValidationAttribute
    {
        /// <summary>
        /// 重写验证逻辑
        /// </summary>
        /// <param name="value">验证值</param>
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
                result = !@string.Contains(' ');
            }
            return result;
        }
    }
}
