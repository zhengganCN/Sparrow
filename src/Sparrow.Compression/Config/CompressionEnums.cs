using System.ComponentModel;

namespace Sparrow.Compression
{
    /// <summary>
    /// 枚举路径类型
    /// </summary>
    internal enum EnumPathType
    {
        [Description("文件路径")]
        FilePath = 1,
        [Description("目录路径")]
        DirectoryPath = 2,
        [Description("路径不存在")]
        NoExits = 3
    }
}
