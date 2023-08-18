using System.Collections.Generic;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 基础分页
    /// </summary>
    public abstract class BasePagination
    {
        /// <summary>
        /// 数据列表
        /// </summary>
        public object List { get; set; }
        /// <summary>
        /// 页面索引
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 页面大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 数据总数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 页面总数
        /// </summary>
        public int PageCount { get; set; }
    }
}
