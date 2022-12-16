using System;

namespace Sparrow.ConvertSystem
{
    public static partial class SparrowConvert
    {
        /// <summary>
        /// 内置类型数据转换
        /// </summary>
        /// <typeparam name="T">内置类型</typeparam>
        /// <param name="value">值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static T Parse<T>(this string value, T defaultValue)
        {
            var data = Parse<T>(value);
            if (data == null)
            {
                return defaultValue;
            }
            else
            {
                return data;
            }
        }

        /// <summary>
        /// 内置类型数据转换
        /// </summary>
        /// <typeparam name="T">内置类型</typeparam>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static T Parse<T>(this string value)
        {
            var type = typeof(T);
            if (typeof(bool) == type)
            {
                return CastOperation<T>(bool.Parse(value));
            }
            else if (typeof(bool?) == type)
            {
                if (bool.TryParse(value, out bool result))
                {
                    return CastOperation<T>(result);
                }
                else
                {
                    return GetDefaultValue<T>();
                }
            }
            if (typeof(byte) == type)
            {
                return CastOperation<T>(byte.Parse(value));
            }
            else if (typeof(byte?) == type)
            {
                if (byte.TryParse(value, out byte result))
                {
                    return CastOperation<T>(result);
                }
                else
                {
                    return GetDefaultValue<T>();
                }
            }
            if (typeof(sbyte) == type)
            {
                return CastOperation<T>(sbyte.Parse(value));
            }
            else if (typeof(sbyte?) == type)
            {
                if (sbyte.TryParse(value, out sbyte result))
                {
                    return CastOperation<T>(result);
                }
                else
                {
                    return GetDefaultValue<T>();
                }
            }
            if (typeof(char) == type)
            {
                return CastOperation<T>(char.Parse(value));
            }
            else if (typeof(char?) == type)
            {
                if (char.TryParse(value, out char result))
                {
                    return CastOperation<T>(result);
                }
                else
                {
                    return GetDefaultValue<T>();
                }
            }
            else if (typeof(decimal) == type)
            {
                return CastOperation<T>(decimal.Parse(value));
            }
            else if (typeof(decimal?) == type)
            {
                if (decimal.TryParse(value, out decimal result))
                {
                    return CastOperation<T>(result);
                }
                else
                {
                    return GetDefaultValue<T>();
                }
            }
            else if (typeof(double) == type)
            {
                return CastOperation<T>(double.Parse(value));
            }
            else if (typeof(double?) == type)
            {
                if (double.TryParse(value, out double result))
                {
                    return CastOperation<T>(result);
                }
                else
                {
                    return GetDefaultValue<T>();
                }
            }
            else if (typeof(float) == type)
            {
                return CastOperation<T>(float.Parse(value));
            }
            else if (typeof(float?) == type)
            {
                if (float.TryParse(value, out float result))
                {
                    return CastOperation<T>(result);
                }
                else
                {
                    return GetDefaultValue<T>();
                }
            }
            else if (typeof(int) == type)
            {
                return CastOperation<T>(int.Parse(value));
            }
            else if (typeof(int?) == type)
            {
                if (int.TryParse(value, out int result))
                {
                    return CastOperation<T>(result);
                }
                else
                {
                    return GetDefaultValue<T>();
                }
            }
            else if (typeof(uint) == type)
            {
                return CastOperation<T>(uint.Parse(value));
            }
            else if (typeof(uint?) == type)
            {
                if (uint.TryParse(value, out uint result))
                {
                    return CastOperation<T>(result);
                }
                else
                {
                    return GetDefaultValue<T>();
                }
            }
            else if (typeof(long) == type)
            {
                return CastOperation<T>(long.Parse(value));
            }
            else if (typeof(long?) == type)
            {
                if (long.TryParse(value, out long result))
                {
                    return CastOperation<T>(result);
                }
                else
                {
                    return GetDefaultValue<T>();
                }
            }
            else if (typeof(ulong) == type)
            {
                return CastOperation<T>(ulong.Parse(value));
            }
            else if (typeof(ulong?) == type)
            {
                if (ulong.TryParse(value, out ulong result))
                {
                    return CastOperation<T>(result);
                }
                else
                {
                    return GetDefaultValue<T>();
                }
            }
            else if (typeof(short) == type)
            {
                return CastOperation<T>(short.Parse(value));
            }
            else if (typeof(short?) == type)
            {
                if (short.TryParse(value, out short result))
                {
                    return CastOperation<T>(result);
                }
                else
                {
                    return GetDefaultValue<T>();
                }
            }
            else if (typeof(ushort) == type)
            {
                return CastOperation<T>(ushort.Parse(value));
            }
            else if (typeof(ushort?) == type)
            {
                if (ushort.TryParse(value, out ushort result))
                {
                    return CastOperation<T>(result);
                }
                else
                {
                    return GetDefaultValue<T>();
                }
            }
            else if (typeof(string) == type)
            {
                return CastOperation<T>(value);
            }
            else if (typeof(DateTime) == type)
            {
                return CastOperation<T>(DateTime.Parse(value));
            }
            else if (typeof(DateTime?) == type)
            {
                if (DateTime.TryParse(value, out DateTime result))
                {
                    return CastOperation<T>(result);
                }
                else
                {
                    return GetDefaultValue<T>();
                }
            }
            else if (typeof(TimeSpan) == type)
            {
                return CastOperation<T>(TimeSpan.Parse(value));
            }
            else if (typeof(TimeSpan?) == type)
            {
                if (TimeSpan.TryParse(value, out TimeSpan result))
                {
                    return CastOperation<T>(result);
                }
                else
                {
                    return GetDefaultValue<T>();
                }
            }
            else if (typeof(DateTimeOffset) == type)
            {
                return CastOperation<T>(DateTimeOffset.Parse(value));
            }
            else if (typeof(DateTimeOffset?) == type)
            {
                if (DateTimeOffset.TryParse(value, out DateTimeOffset result))
                {
                    return CastOperation<T>(result);
                }
                else
                {
                    return GetDefaultValue<T>();
                }
            }
            else if (typeof(Guid) == type)
            {
                return CastOperation<T>(Guid.Parse(value));
            }
            else if (typeof(Guid?) == type)
            {
                if (Guid.TryParse(value, out Guid result))
                {
                    return CastOperation<T>(result);
                }
                else
                {
                    return GetDefaultValue<T>();
                }
            }
            return CastOperation<T>(value); ;
        }

        private static T CastOperation<T>(object value)
        {
            return (T)value;
        }

        private static T GetDefaultValue<T>()
        {
            return default;
        }

    }
}
