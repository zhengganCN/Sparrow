using Sparrow.Extension.System.Enums;
using System;
using System.Reflection;

namespace Sparrow.Extension.System
{
    /// <summary>
    /// 时间类型扩展
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// 默认时间格式
        /// </summary>
        public const string DefaultFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 时间转字符串
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <param name="format">格式</param>
        /// <returns></returns>
        public static string ToString(this DateTime? dateTime, string format)
        {
            return dateTime?.ToString(format);
        }

        /// <summary>
        /// 获取年/月“周”数
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="type">“周”数量类型枚举</param>
        /// <returns></returns>
        public static int GetWeeks(this DateTime time, WeekNumberType type = WeekNumberType.Month)
        {
            DateTime? begin = null;//年/月的开始时间
            int end = 0;//年/月的天数
            switch (type)
            {
                case WeekNumberType.Month:
                    begin = DateTime.Parse($"{time.Year}-{time.Month:00}-01");
                    end = DateTime.DaysInMonth(begin.Value.Year, begin.Value.Month);
                    break;
                case WeekNumberType.Year:
                    begin = DateTime.Parse($"{time.Year}-01-01");
                    end = begin.Value.AddYears(1).AddDays(-1).DayOfYear;
                    break;
            }
            int weeks = 0;//年/月的周数
            for (int i = 0; i < end; i++)
            {
                if (begin.Value.AddDays(i).DayOfWeek == DayOfWeek.Monday)
                {
                    weeks++;
                }
            }
            return weeks;
        }

        /// <summary>
        /// 获取给定月份的周索引，从1开始
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns></returns>
        public static int GetWeekIndexInMonth(this DateTime time)
        {
            DateTime begin = DateTime.Parse($"{time.Year}-{time.Month:00}-01");//年/月的开始时间
            int end = DateTime.DaysInMonth(begin.Year, begin.Month);//月的天数
            var index = 0;//当前时间在年/月的周索引
            for (int i = 0; i < end; i++)
            {
                if (begin.AddDays(i).DayOfWeek == DayOfWeek.Monday)
                {
                    index++;
                }
            }
            return index;
        }

        /// <summary>
        /// 获取给定年的周索引，从1开始
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns></returns>
        public static int GetWeekIndexInYear(this DateTime time)
        {
            DateTime begin = DateTime.Parse($"{time.Year}-01-01");//年/月的开始时间
            int end = begin.AddYears(1).AddDays(-1).DayOfYear;//年的天数
            var index = 0;//当前时间在年/月的周索引
            for (int i = 0; i < end; i++)
            {
                if (begin.AddDays(i).DayOfWeek == DayOfWeek.Monday)
                {
                    index++;
                }
            }
            return index;
        }

        /// <summary>
        /// 获取给定月的周的起止日期，未匹配到则返回null
        /// </summary>
        /// <param name="time"></param>
        /// <param name="week">周，从1开始</param>
        /// <returns>
        /// 第一项：给定周的开始时间
        /// 第二项：给定周的结束时间
        /// </returns>
        public static Tuple<DateTime, DateTime> GetWeekTimeInMonth(this DateTime time, int week)
        {
            DateTime begin = DateTime.Parse($"{time.Year}-{time.Month:00}-01");//指定周的开始时间
            int end = DateTime.DaysInMonth(begin.Year, begin.Month);//月的天数
            int index = 0;
            for (int i = 0; i < end; i++)
            {
                if (begin.AddDays(i).DayOfWeek == DayOfWeek.Monday)
                {
                    index++;
                    if (week == index)
                    {
                        begin = begin.AddDays(i);
                        return new Tuple<DateTime, DateTime>(begin, begin.AddDays(6));
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 获取给定年的周的起止日期，未匹配到则返回null
        /// </summary>
        /// <param name="time"></param>
        /// <param name="week">周，从1开始</param>
        /// <returns>
        /// 第一项：给定周的开始时间
        /// 第二项：给定周的结束时间
        /// </returns>
        public static Tuple<DateTime, DateTime> GetWeekTimeInYear(this DateTime time, int week)
        {
            DateTime begin = DateTime.Parse($"{time.Year}-01-01");//指定周的开始时间
            int end = begin.AddYears(1).AddDays(-1).DayOfYear;//年的天数
            int index = 0;
            for (int i = 0; i < end; i++)
            {
                if (begin.AddDays(i).DayOfWeek == DayOfWeek.Monday)
                {
                    index++;
                    if (week == index)
                    {
                        begin = begin.AddDays(i);
                        return new Tuple<DateTime, DateTime>(begin, begin.AddDays(6));
                    }
                }
            }
            return null;
        }
    }
}
