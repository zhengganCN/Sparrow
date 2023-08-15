using Sparrow.Monitor.Enums;
using System;
using System.Runtime.Caching;

namespace Sparrow.Monitor.Flow
{
    /// <summary>
    /// 访问频率计数缓存
    /// </summary>
    public class AccessFrequencyCachae
    {
        private static readonly ObjectCache Cache = MemoryCache.Default;
        private static readonly object CacheLock = new object();

        /// <summary>
        /// 为路径增加一次访问次数，并返回当前访问次数
        /// </summary>
        /// <param name="method">请求方式</param>
        /// <param name="path">路径</param>
        /// <param name="unitCount">频率单位数量</param>
        /// <param name="unit">频率单位</param>
        /// <returns></returns>
        public static long Access(string method, string path, uint unitCount, AccessFrequencyUnit unit)
        {
            lock (CacheLock)
            {
                var now = DateTime.Now;
                var time = GetTime(unitCount, unit, now);
                var key = GetKey(method, path, time);
                var timespan = GetTimeSpan(unitCount, unit);
                var expire = DateTime.Parse(time).Add(timespan);
                var count = (long?)Cache.Get(key);
                if (count == null)
                {
                    count = 1;
                }
                else
                {
                    count++;
                }
                Cache.Set(key, count, expire);
                return count.Value;
            }
        }

        /// <summary>
        /// 获取间隔周期
        /// </summary>
        /// <returns></returns>
        private static TimeSpan GetTimeSpan(uint unitCount, AccessFrequencyUnit unit)
        {
            TimeSpan timespan = TimeSpan.Zero;
            switch (unit)
            {
                case AccessFrequencyUnit.Seconds:
                    timespan = TimeSpan.FromSeconds(unitCount);
                    break;
                case AccessFrequencyUnit.Minite:
                    timespan = TimeSpan.FromMinutes(unitCount);
                    break;
                case AccessFrequencyUnit.Hour:
                    timespan = TimeSpan.FromHours(unitCount);
                    break;
                case AccessFrequencyUnit.Day:
                    timespan = TimeSpan.FromDays(unitCount);
                    break;
            }
            return timespan;
        }

        /// <summary>
        /// 获取key
        /// </summary>
        /// <returns></returns>
        private static string GetKey(string method, string path, string time)
        {
            return $"{method}:{path}:{time}";
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <returns></returns>
        private static string GetTime(uint unitCount, AccessFrequencyUnit unit, DateTime now)
        {
            string time = default;
            switch (unit)
            {
                case AccessFrequencyUnit.Seconds:
                    var seconds = (int)now.TimeOfDay.TotalSeconds;
                    var leaveSeconds = seconds % unitCount;
                    time = now.AddSeconds(-leaveSeconds).ToString($"yyyy-MM-dd HH:mm:ss");
                    break;
                case AccessFrequencyUnit.Minite:
                    var minutes = (int)now.TimeOfDay.TotalMinutes;
                    var leaveMinutes = minutes % unitCount;
                    time = now.AddMinutes(-leaveMinutes).ToString("yyyy-MM-dd HH:mm:00");
                    break;
                case AccessFrequencyUnit.Hour:
                    var hours = (int)now.TimeOfDay.TotalHours;
                    var leaveHours = hours % unitCount;
                    time = now.AddHours(-leaveHours).ToString("yyyy-MM-dd HH:00:00");
                    break;
                case AccessFrequencyUnit.Day:
                    time = now.ToString("yyyy-MM-dd 00:00:00");
                    break;
            }
            return time;
        }

    }
}
