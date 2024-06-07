using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.StandardResult.Abstracts
{
    public abstract class AbstractStandardPagination<T>
    {
        /// <summary>
        /// 数据列表
        /// </summary>
        public IList<T> List { get; set; }
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
        /// <summary>
        /// 计算分页数据
        /// </summary>
        /// <param name="list">数据</param>
        /// <param name="count">总数</param>
        /// <param name="pageIndex">页码，默认值为1</param>
        /// <param name="pageSize">页面大小，默认值为10</param>
        internal void Computer(IList<T> list, int count, int pageIndex = 1, int pageSize = 10)
        {
            List = list;
            Count = count;
            PageIndex = pageIndex;
            PageSize = pageSize;
            PageCount = (int)Math.Ceiling((double)count / PageSize);
        }
    }
}
