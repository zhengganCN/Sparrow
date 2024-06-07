using Newtonsoft.Json;
using Sparrow.StandardResult.Abstracts;
using System;
using System.Collections.Generic;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 分页数据
    /// </summary>
    public class StandardPagination<T> : AbstractStandardPagination<T>, IStandardPagination
    {
        internal string Key { get; set; } 
        internal StandardResultOption Option { get; set; } 
        /// <summary>
        /// 初始化
        /// </summary>
        public StandardPagination()
        {
            Key = StandardResultConsts.DefaultKey;
            Option = StandardResultValues.StandardResultOptions[StandardResultConsts.DefaultKey];
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="key">标识</param>
        public StandardPagination(string key)
        {
            Key = key;
            Option = StandardResultValues.StandardResultOptions[key];
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="count">总数</param>
        /// <param name="pageIndex">页码，默认值为1</param>
        /// <param name="pageSize">页面大小，默认值为10</param>
        /// <returns></returns>
        public StandardPagination<T> GetPagination(IList<T> list, int count, int pageIndex = 1, int pageSize = 10)
        {
            Computer(list, count, pageIndex, pageSize);
            return this;
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="count">总数</param>
        /// <param name="page">分页参数</param>
        /// <returns></returns>
        public StandardPagination<T> GetPagination(IList<T> list, int count, IPagination page)
        {
            Computer(list, count, page.GetPageIndex(), page.GetPageSize());
            return this;
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <returns></returns>
        public object StandardFormat()
        {
            return Option.FormatStandardPagination(new StandardPagination<object>
            {
                List = (IList<object>)List,
                Count = Count,
                PageIndex = PageIndex,
                PageSize = PageSize,
                PageCount = PageCount
            });
        }
    }
}
