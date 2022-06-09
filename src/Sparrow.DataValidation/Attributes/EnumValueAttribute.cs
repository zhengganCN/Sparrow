using System;
using System.ComponentModel.DataAnnotations;

namespace Sparrow.DataValidation.Attributes
{
    /// <summary>
    /// 枚举值验证特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EnumValueAttribute : ValidationAttribute
    {
        private readonly Type @enum;
        /// <summary>
        /// 枚举值验证特性
        /// </summary>
        /// <param name="enum">枚举类型</param>
        public EnumValueAttribute(Type @enum)
        {
            this.@enum = @enum;
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
            return IsContainer(Convert.ToInt32(value));
        }

        private bool IsContainer(int data)
        {
            var enumValues = Enum.GetValues(@enum);
            foreach (var item in enumValues)
            {
                if ((int)item == data)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
