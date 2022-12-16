using Sparrow.ConvertSystem.Utils;

namespace Sparrow.ConvertSystem
{
    public static partial class SparrowConvert
    {
        /// <summary>
        /// 把数字转换成中文数字
        /// </summary>
        /// <param name="value">数值</param>
        /// <param name="category">中文类型</param>
        /// <returns></returns>
        public static string ToChineseNumber(this float value, ChineseCategory category)
        {
            return ChineseNumberUtil.GetChinese(value.ToString(), category);
        }

        /// <summary>
        /// 把数字转换成中文数字
        /// </summary>
        /// <param name="value">数值</param>
        /// <param name="category">中文类型</param>
        /// <returns></returns>
        public static string ToChineseNumber(this double value, ChineseCategory category)
        {
            return ChineseNumberUtil.GetChinese(value.ToString(), category);
        }

        /// <summary>
        /// 把数字转换成中文数字
        /// </summary>
        /// <param name="value">数值</param>
        /// <param name="category">中文类型</param>
        /// <returns></returns>
        public static string ToChineseNumber(this decimal value, ChineseCategory category)
        {
            return ChineseNumberUtil.GetChinese(value.ToString(), category);
        }

        /// <summary>
        /// 把数字转换成中文数字
        /// </summary>
        /// <param name="value">数值</param>
        /// <param name="category">中文类型</param>
        /// <returns></returns>
        public static string ToChineseNumber(this ushort value, ChineseCategory category)
        {
            return ChineseNumberUtil.GetChinese(value.ToString(), category);
        }

        /// <summary>
        /// 把数字转换成中文数字
        /// </summary>
        /// <param name="value">数值</param>
        /// <param name="category">中文类型</param>
        /// <returns></returns>
        public static string ToChineseNumber(this short value, ChineseCategory category)
        {
            return ChineseNumberUtil.GetChinese(value.ToString(), category);
        }

        /// <summary>
        /// 把数字转换成中文数字
        /// </summary>
        /// <param name="value">数值</param>
        /// <param name="category">中文类型</param>
        /// <returns></returns>
        public static string ToChineseNumber(this uint value, ChineseCategory category)
        {
            return ChineseNumberUtil.GetChinese(value.ToString(), category);
        }

        /// <summary>
        /// 把数字转换成中文数字
        /// </summary>
        /// <param name="value">数值</param>
        /// <param name="category">中文类型</param>
        /// <returns></returns>
        public static string ToChineseNumber(this int value, ChineseCategory category)
        {
            return ChineseNumberUtil.GetChinese(value.ToString(), category);
        }

        /// <summary>
        /// 把数字转换成中文数字
        /// </summary>
        /// <param name="value">数值</param>
        /// <param name="category">中文类型</param>
        /// <returns></returns>
        public static string ToChineseNumber(this ulong value, ChineseCategory category)
        {
            return ChineseNumberUtil.GetChinese(value.ToString(), category);
        }

        /// <summary>
        /// 把数字转换成中文数字
        /// </summary>
        /// <param name="value">数值</param>
        /// <param name="category">中文类型</param>
        /// <returns></returns>
        public static string ToChineseNumber(this long value, ChineseCategory category)
        {
            return ChineseNumberUtil.GetChinese(value.ToString(), category);
        }

        /// <summary>
        /// 把数字转换成中文数字
        /// </summary>
        /// <param name="value">数值</param>
        /// <param name="category">中文类型</param>
        /// <returns></returns>
        public static string ToChineseNumber(this string value, ChineseCategory category)
        {
            return ChineseNumberUtil.GetChinese(value, category);
        }
    }
}
