using System.ComponentModel;

namespace Sparrow.Extension.System.Enums
{
    /// <summary>
    /// 枚举值类型
    /// </summary>
    public enum EnumValueType
    {
        /// <summary>
        /// 字符串
        /// </summary>
        [Description("字符串")]
        Character = 1,
        /// <summary>
        /// 整数
        /// </summary>
        [Description("整数")]
        Integer = 2
    }
}
