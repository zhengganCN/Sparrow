using System.Collections.Generic;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 分页数据
    /// </summary>
    public class StandardPagination : BasePagination<object>, IStandardResultFormat
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="key">标识</param>
        public StandardPagination(string key = StandardResultConsts.DefaultKey)
        {
            option = StandardResultValues.StandardResultOptions[key];
        }
    }

    /// <summary>
    /// 分页数据
    /// </summary>
    public class StandardPagination<T> : BasePagination<IList<T>>, IStandardResultFormat
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="key">标识</param>
        public StandardPagination(string key = StandardResultConsts.DefaultKey)
        {
            option = StandardResultValues.StandardResultOptions[key];
        }
    }
}
