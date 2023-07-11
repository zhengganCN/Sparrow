using System;

namespace Sparrow.Extension.System
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// 映射
        /// </summary>
        /// <typeparam name="T">源数据</typeparam>
        /// <typeparam name="R">输出对象</typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static R Map<T, R>(this T source, Func<T, R> func)
        {
            return func.Invoke(source);
        }
    }
}
