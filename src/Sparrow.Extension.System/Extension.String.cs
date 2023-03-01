using System;

namespace Sparrow.Extension.System
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 把字符串转换成可为空的时间格式
        /// </summary>
        /// <param name="value">时间格式字符串</param>
        /// <returns></returns>
        public static DateTime? ToDateTimeNullable(this string value)
        {
            DateTime? result = null;
            if (DateTime.TryParse(value, out DateTime dateTime))
            {
                result = dateTime;
            }
            return result;
        }

        /// <summary>
        /// 字符串是否能转换成时间
        /// </summary>
        /// <param name="vlue">时间格式字符串</param>
        /// <returns></returns>
        public static bool IsDateTime(this string vlue)
        {
            return DateTime.TryParse(vlue, out DateTime _);
        }

    }
}
