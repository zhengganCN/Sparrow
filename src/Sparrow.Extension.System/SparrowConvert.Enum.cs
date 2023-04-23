using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Sparrow.Extension
{
    public static partial class SparrowConvert
    {
        /// <summary>
        /// 获取枚举列表
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <returns></returns>
        public static List<EnumInfo> GetEnumList<T>() where T : Enum
        {
            var infos = new List<EnumInfo>();
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
                infos.Add(enumInfo);
            }
            return infos;
        }
    }
}
