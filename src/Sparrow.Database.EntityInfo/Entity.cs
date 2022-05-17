using System;
using System.ComponentModel;

namespace Sparrow.Database.EntityInfo
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// 删除标识
        /// </summary>
        [Description("删除标识")]
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Description("创建人")]
        public long? Creator { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        [Description("删除时间")]
        public DateTime? DeleteTime { get; set; }
        /// <summary>
        /// 删除人
        /// </summary>
        [Description("删除人")]
        public long? Deletor { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Description("更新时间")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Description("更新人")]
        public long? Updator { get; set; }
    }
}
