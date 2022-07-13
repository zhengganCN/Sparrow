using System;
using System.ComponentModel.DataAnnotations;

namespace Sparrow.DataValidation.Attributes
{
    /// <summary>
    /// 字符串转换成指定数据类型验证特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal class StringConvertAttribute : ValidationAttribute
    {
        private StringConvertType ConvertType { get; set; }
        public StringConvertAttribute(StringConvertType type)
        {
            ConvertType = type;
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
            var result = false;
            if (value is string @string)
            {
                switch (ConvertType)
                {
                    case StringConvertType.Int:
                        result = int.TryParse(@string, out _);
                        break;
                    case StringConvertType.Lnog:
                        result = long.TryParse(@string, out _);
                        break;
                    case StringConvertType.Float:
                        result = float.TryParse(@string, out _);
                        break;
                    case StringConvertType.Double:
                        result = double.TryParse(@string, out _);
                        break;
                }
            }
            return result;
        }
    }
}
