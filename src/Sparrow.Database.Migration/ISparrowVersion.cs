namespace Sparrow.Database.Migration
{
    /// <summary>
    /// 版本接口
    /// </summary>
    public interface ISparrowVersion
    {
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// 主版本号
        /// </summary>
        ushort Major { get; set; }
        /// <summary>
        /// 子版本号
        /// </summary>
        ushort Minor { get; set; }
        /// <summary>
        /// 修正版本号
        /// </summary>
        ushort Revision { get; set; }
        /// <summary>
        /// 临时版本号
        /// </summary>
        ushort Temporary { get; set; }
    }
}
