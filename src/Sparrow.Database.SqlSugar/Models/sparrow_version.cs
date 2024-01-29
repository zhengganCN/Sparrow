using Sparrow.Database.EntityInfo;
using SqlSugar;

namespace Sparrow.Database.SqlSugar.Models
{
    /// <summary>
    /// 版本表
    /// </summary>
#pragma warning disable IDE1006 // 命名样式
    public class sparrow_version : base_entity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, ColumnDescription = "主键")]
        public long id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 255, ColumnDescription = "名称")]
        public string name { get; set; }
        /// <summary>
        /// 主版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "主版本号")]
        public ushort major { get; set; }
        /// <summary>
        /// 子版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "子版本号")]
        public ushort minor { get; set; }
        /// <summary>
        /// 修正版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "修正版本号")]
        public ushort revision { get; set; }
        /// <summary>
        /// 临时版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "临时版本号")]
        public ushort temporary { get; set; }
        /// <summary>
        /// 序列
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "序列")]
        public ulong serial { get; set; }
    }
#pragma warning restore IDE1006 // 命名样式
}
