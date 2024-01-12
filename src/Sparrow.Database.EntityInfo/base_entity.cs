using SqlSugar;
using System;

namespace Sparrow.Database.EntityInfo
{
#pragma warning disable IDE1006 // 命名样式
    /// <summary>
    /// 实体基类（下划线命名/蛇形命名法）
    /// </summary>
    public abstract class base_entity
    {
        /// <summary>
        /// 删除标识
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "删除标识")]
        public bool is_deleted { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "创建时间")]
        public DateTime create_time { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 32, ColumnDescription = "创建人")]
        public string creator { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDescription = "删除时间")]
        public DateTime? delete_time { get; set; }
        /// <summary>
        /// 删除人
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 32, ColumnDescription = "删除人")]
        public string deletor { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDescription = "更新时间")]
        public DateTime? update_time { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 32, ColumnDescription = "更新人")]
        public string updator { get; set; }
    }
#pragma warning restore IDE1006 // 命名样式
}
