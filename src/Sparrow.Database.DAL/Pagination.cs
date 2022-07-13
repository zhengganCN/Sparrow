using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Database.DAL
{
    /// <summary>
    /// 分页数据
    /// </summary>
    public class Pagination<T>
    {
        /// <summary>
        /// 数据列表
        /// </summary>
        public List<T> List { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 数据总数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 分页数量
        /// </summary>
        public int PageCount { get; set; }
    }
}
