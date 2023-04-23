using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparrow.Extension
{
    public static partial class SparrowConvert
    {
        /// <summary>
        /// 使用分隔字符把字符串列表转字符串
        /// </summary>
        /// <param name="list">字符串列表</param>
        /// <param name="split">分隔字符</param>
        /// <returns></returns>
        public static string ToString(this IEnumerable<string> list, char split)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < list.Count(); i++)
            {
                sb.Append(list.ElementAt(i));
                if (i + 1 != list.Count())
                {
                    sb.Append(split);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 使用分隔字符串把字符串列表转字符串
        /// </summary>
        /// <param name="list">字符串列表</param>
        /// <param name="split">分隔字符串</param>
        /// <returns></returns>
        public static string ToString(this IEnumerable<string> list, string split)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < list.Count(); i++)
            {
                sb.Append(list.ElementAt(i));
                if (i + 1 != list.Count())
                {
                    sb.Append(split);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 使用分隔字符把字符列表转字符串
        /// </summary>
        /// <param name="list">字符列表</param>
        /// <param name="split">分隔字符</param>
        /// <returns></returns>
        public static string ToString(this IEnumerable<char> list, char split)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < list.Count(); i++)
            {
                sb.Append(list.ElementAt(i));
                if (i + 1 != list.Count())
                {
                    sb.Append(split);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 使用分隔字符串把字符列表转字符串
        /// </summary>
        /// <param name="list">字符列表</param>
        /// <param name="split">分隔字符串</param>
        /// <returns></returns>
        public static string ToString(this IEnumerable<char> list, string split)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < list.Count(); i++)
            {
                sb.Append(list.ElementAt(i));
                if (i + 1 != list.Count())
                {
                    sb.Append(split);
                }
            }
            return sb.ToString();
        }
    }
}
