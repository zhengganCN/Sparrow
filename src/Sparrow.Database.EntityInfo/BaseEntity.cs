using SqlSugar;
using System;

namespace Sparrow.Database.EntityInfo
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// 删除标识
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "删除标识")]
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "创建时间")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 32, ColumnDescription = "创建人")]
        public string Creator { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDescription = "删除时间")]
        public DateTime? DeleteTime { get; set; }
        /// <summary>
        /// 删除人
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 32, ColumnDescription = "删除人")]
        public string Deletor { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDescription = "更新时间")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 32, ColumnDescription = "更新人")]
        public string Updator { get; set; }
    }
}
