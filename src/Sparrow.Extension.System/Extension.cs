using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// 比较两个数组中的值是否相等
        /// </summary>
        /// <typeparam name="T">元素类型</typeparam>
        /// <param name="souece">原数组</param>
        /// <param name="compare">待比较数组</param>
        /// <returns>ture:same false:different</returns>
        public static bool Compare<T>(this IEnumerable<T> souece, IEnumerable<T> compare) where T : IComparable
        {
            if (souece == null && compare == null)
            {
                return true;
            }
            if ((souece == null && compare != null) || (souece != null && compare == null))
            {
                return false;
            }
            if (souece.LongCount() != compare.LongCount())
            {
                return false;
            }
            for (int i = 0; i < souece.LongCount(); i++)
            {
                if (souece.ElementAt(i).CompareTo(compare.ElementAt(i)) != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
