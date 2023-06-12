using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Sparrow.DataValidation.Attributes
{
    /// <summary>
    /// 允许的值验证特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class SparrowAllowValueAttribute : ValidationAttribute
    {
        private readonly object[] _values;
        /// <summary>
        /// 允许的值验证特性
        /// </summary>
        /// <param name="values">值</param>
        public SparrowAllowValueAttribute(params object[] values)
        {
            _values = values;
        }
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
            if (_values.Contains(value))
            {
                return true;
            }
            return false;
        }
    }
}
