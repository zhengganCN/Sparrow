namespace Sparrow.DataValidation
{
    /// <summary>
    /// 枚举包含设置
    /// </summary>
    public enum EnumChineseOption
    {
        /// <summary>
        /// 至少包含一个中文
        /// </summary>
        Container = 1,
        /// <summary>
        /// 全部是中文
        /// </summary>
        All = 2
    }
    /// <summary>
    /// 时间格式枚举
    /// </summary>
    public enum EnumTimeFormat
    {
        /// <summary>
        /// 日期时间
        /// </summary>
        DateTime = 1,
        /// <summary>
        /// 日期
        /// </summary>
        Date = 2,
        /// <summary>
        /// 时间
        /// </summary>
        Time = 3,
        /// <summary>
        /// 日期时间-无分隔符(如“yyyyMMddhhmmss”)
        /// </summary>
        DateTimeNoSeparator = 4,
        /// <summary>
        /// 日期-无分隔符(如“yyyyMMdd”)
        /// </summary>
        DateNoSeparator = 5,
        /// <summary>
        /// 时间-无分隔符(如“hhmmss”)
        /// </summary>
        TimeNoSeparator = 6
    }
    /// <summary>
    /// 文件大小单位枚举
    /// </summary>
    public enum EnumSizeUnit
    {
        /// <summary>
        /// Byte
        /// </summary>
        UnitByte = 1,
        /// <summary>
        /// KB
        /// </summary>
        UnitKB = 2,
        /// <summary>
        /// MB
        /// </summary>
        UnitMB = 3
    }
    /// <summary>
    /// 枚举字符可转换类型
    /// </summary>
    public enum EnumStringConvertType
    {
        Int = 1,
        Lnog = 2,
        Float = 3,
        Double = 4
    }
}
