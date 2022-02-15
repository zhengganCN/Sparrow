using System;
using System.Collections.Generic;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 分页数据
    /// </summary>
    public static class Pagination
    {
        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="count">总数</param>
        /// <param name="pageIndex">页面索引</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns></returns>
        public static Pagination<T> GetPagination<T>(List<T> list, int count, int pageIndex = 1, int pageSize = 10)
        {
            var pagination = new Pagination<T>(count, pageIndex, pageSize)
            {
                List = list
            };
            return pagination;
        }
    }
    /// <summary>
    /// 分页数据
    /// </summary>
    public class Pagination<T>
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="count">总数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页面大小</param>
        public Pagination(int count, int pageIndex = 1, int pageSize = 10)
        {
            Count = count;
            PageIndex = pageIndex;
            PageSize = pageSize;
            PageCount = (int)Math.Ceiling((double)count / pageSize);
        }
        /// <summary>
        /// 数据列表
        /// </summary>
        public List<T> List { get; set; }
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
