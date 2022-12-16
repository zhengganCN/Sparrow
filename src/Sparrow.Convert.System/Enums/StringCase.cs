using System.ComponentModel;

namespace Sparrow.ConvertSystem
{
    /// <summary>
    /// 字符串枚举
    /// </summary>
    public enum StringCase
    {
        /// <summary>
        /// 小写
        /// </summary>
        [Description("小写")]
        Lowercase = 10,
        /// <summary>
        /// 首字母小写
        /// </summary>
        LowercaseFirstLetter = 11,
        /// <summary>
        /// 大写
        /// </summary>
        [Description("大写")]
        Uppercase = 20,
        /// <summary>
        /// 首字母大写
        /// </summary>
        UppercaseFirstLetter,
    }
}
