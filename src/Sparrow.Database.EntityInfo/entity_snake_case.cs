using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Sparrow.Database.EntityInfo
{
#pragma warning disable IDE1006 // 命名样式
    /// <summary>
    /// 实体基类（下划线命名/蛇形命名法）
    /// </summary>
    public class entity_snake_case
    {
        /// <summary>
        /// 删除标识
        /// </summary>
        [Description("删除标识")]
        public bool is_deleted { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime? create_time { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Description("创建人")]
        public long? creator { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        [Description("删除时间")]
        public DateTime? delete_time { get; set; }
        /// <summary>
        /// 删除人
        /// </summary>
        [Description("删除人")]
        public long? deletor { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Description("更新时间")]
        public DateTime? update_time { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Description("更新人")]
        public long? updator { get; set; }
    }
#pragma warning restore IDE1006 // 命名样式
}
