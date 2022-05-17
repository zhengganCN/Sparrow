using System;
using System.ComponentModel;
using System.Reflection;

namespace Sparrow.Extension.System
{
    /// <summary>
    /// 枚举扩展类
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            return value.GetDescription(default);
        }

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <param name="defaultDescription">默认描述</param>
        /// <returns></returns>
        public static string GetDescription(this Enum value, string defaultDescription)
        {
            if (value == null)
            {
                return string.Empty;
            }
            var field = value.GetType().GetField(value.ToString());
            if (field is null)
            {
                return defaultDescription;
            }
            var description = ((DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description;
            return !string.IsNullOrEmpty(description) ? description : field.Name;
        }
    }
}
