using Sparrow.Database.EntityInfo;
using SqlSugar;

namespace Sparrow.Database.SqlSugar.Models
{
    /// <summary>
    /// 版本表
    /// </summary>
    public class SparrowVersion : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, ColumnDescription = "主键")]
        public long Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 255, ColumnDescription = "名称")]
        public string Name { get; set; }
        /// <summary>
        /// 主版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "主版本号")]
        public ushort Major { get; set; }
        /// <summary>
        /// 子版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "子版本号")]
        public ushort Minor { get; set; }
        /// <summary>
        /// 修正版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "修正版本号")]
        public ushort Revision { get; set; }
        /// <summary>
        /// 临时版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "临时版本号")]
        public ushort Temporary { get; set; }
        /// <summary>
        /// 序列
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "序列")]
        public ulong Serial { get; set; }
    }
}
