using System;
using System.Collections.Generic;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 分页数据
    /// </summary>
    public static class StandardPagination
    {
        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="count">总数</param>
        /// <param name="pageIndex">页码，默认值为1</param>
        /// <param name="pageSize">页面大小，默认值为10</param>
        /// <returns></returns>
        public static StandardPagination<T> GetPagination<T>(List<T> list, int count, int pageIndex = 1, int pageSize = 10)
        {
            var pagination = new StandardPagination<T>(list, count, pageIndex, pageSize);
            return pagination;
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="count">总数</param>
        /// <param name="page">分页参数</param>
        /// <returns></returns>
        public static StandardPagination<T> GetPagination<T>(List<T> list, int count, IPagination page)
        {
            var pagination = new StandardPagination<T>(list, count, page.GetPageIndex(), page.GetPageSize());
            return pagination;
        }
    }
    /// <summary>
    /// 分页数据
    /// </summary>
    public class StandardPagination<T>
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="list">数据</param>
        /// <param name="count">总数</param>
        /// <param name="pageIndex">页码，默认值为1</param>
        /// <param name="pageSize">页面大小，默认值为10</param>
        public StandardPagination(IList<T> list, int count, int pageIndex = 1, int pageSize = 10)
        {
            List = list;
            Count = count;
            PageIndex = pageIndex;
            PageSize = pageSize;
            PageCount = (int)Math.Ceiling((double)count / PageSize);
        }
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
    }
}
