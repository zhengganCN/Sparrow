using Sparrow.Extension.System;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sparrow.DataValidation.Attributes
{
    /// <summary>
    /// 时间格式验证，验证的参数只能是字符串
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class DateTimeFormatAttribute : ValidationAttribute
    {
        /// <summary>
        /// 验证的时间类型
        /// </summary>
        public TimeFormat TimeFormat { get; set; } = TimeFormat.DateTime;
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
            if (value is string datatime)
            {
                if (string.IsNullOrEmpty(datatime))
                {
                    return false;
                }
                else
                {
                    return DateTimeValid(datatime);
                }
            }
            else
            {
                return false;
            }
        }

        private bool DateTimeValid(string value)
        {
            var result = false;
            switch (TimeFormat)
            {
                case TimeFormat.DateTime:
                case TimeFormat.Date:
                case TimeFormat.Time:
                    result = value.IsDateTime();
                    break;
                case TimeFormat.DateTimeNoSeparator:
                    if (ValidDateTimeStringLength(value, TimeFormat.DateTimeNoSeparator))
                    {
                        result = value.Insert(12, ":").Insert(10, ":").Insert(8, " ")
                            .Insert(6, "/").Insert(4, "/").IsDateTime();
                    }
                    break;
                case TimeFormat.DateNoSeparator:
                    if (ValidDateTimeStringLength(value, TimeFormat.DateNoSeparator))
                    {
                        result = value.Insert(6, "/").Insert(4, "/").IsDateTime();
                    }
                    break;
                case TimeFormat.TimeNoSeparator:
                    if (ValidDateTimeStringLength(value, TimeFormat.TimeNoSeparator))
                    {
                        result = value.Insert(4, ":").Insert(2, ":").IsDateTime();
                    }
                    break;
            }
            return result;
        }

        private bool ValidDateTimeStringLength(string value, TimeFormat format)
        {
            var result = false;
            switch (format)
            {
                case TimeFormat.DateTimeNoSeparator:
                    result = value.Length == 14;
                    break;
                case TimeFormat.DateNoSeparator:
                    result = value.Length == 8;
                    break;
                case TimeFormat.TimeNoSeparator:
                    result = value.Length == 6;
                    break;
            }
            return result;
        }


    }
}
