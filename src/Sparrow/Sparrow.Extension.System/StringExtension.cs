using System;

namespace Sparrow.Extension.System
{
    public static class StringExtension
    {
        /// <summary>
        /// 把字符串转换成可为空的时间格式
        /// </summary>
        /// <param name="value"></param>
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

    }
}
