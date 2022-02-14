using System;
using System.Collections.Generic;
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
            if (value == null)
            {
                return string.Empty;
            }
            var field = value.GetType().GetField(value.ToString());
            var description = ((DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description;
            return !string.IsNullOrEmpty(description) ? description : field.Name;
        }

        /// <summary>
        /// 获取枚举列表
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <returns></returns>
        public static List<EnumInfo> GetEnumList<T>() where T : Enum
        {
            var enumInfos = new List<EnumInfo>();
            var enumType = typeof(T);
            var fieldInfos = enumType.GetFields();
            foreach (var fieldInfo in fieldInfos)
            {
                var enumInfo = new EnumInfo();
                if (fieldInfo.FieldType != enumType)
                {
                    continue;
                }
                enumInfo.Key = fieldInfo.GetValue(enumType)?.ToString();
                enumInfo.Value = ((int)fieldInfo.GetValue(enumType)).ToString();
                var description = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
                if (description != null && !string.IsNullOrWhiteSpace(description.Description))
                {
                    enumInfo.Description = description.Description;
                }
                enumInfos.Add(enumInfo);
            }
            return enumInfos;
        }
    }
}
