using System.Collections.Generic;
using System.Text.Json;

namespace Sparrow.StandardResult
{
    public abstract partial class BasePagination<T>
    {
        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="count">总数</param>
        /// <param name="pageIndex">页码，默认值为1</param>
        /// <param name="pageSize">页面大小，默认值为10</param>
        /// <returns></returns>
        public R GetPagination<R>(T list, int count, int pageIndex = 1, int pageSize = 10) where R : class
        {
            Computer(list, count, pageIndex, pageSize);
            return Convert<R>(Format());
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="count">总数</param>
        /// <param name="additional">附加属性</param>
        /// <param name="pageIndex">页码，默认值为1</param>
        /// <param name="pageSize">页面大小，默认值为10</param>
        /// <returns></returns>
        public R GetPagination<R>(T list, int count, Dictionary<string, object> additional, int pageIndex = 1, int pageSize = 10) where R : class
        {
            Computer(list, count, pageIndex, pageSize);
            return Convert<R>(Format(additional));
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="count">总数</param>
        /// <param name="page">分页参数</param>
        /// <returns></returns>
        public R GetPagination<R>(T list, int count, IPagination page) where R : class
        {
            Computer(list, count, page.GetPageIndex(), page.GetPageSize());
            return Convert<R>(Format());
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="count">总数</param>
        /// <param name="additional">附加属性</param>
        /// <param name="page">分页参数</param>
        /// <returns></returns>
        public R GetPagination<R>(T list, int count, Dictionary<string, object> additional, IPagination page) where R : class
        {
            Computer(list, count, page.GetPageIndex(), page.GetPageSize());
            return Convert<R>(Format(additional));
        }

        /// <summary>
        /// 类型转换
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        private R Convert<R>(object obj) where R : class
        {
            if (obj is R)
            {
                return obj as R;
            }
            else
            {
                return JsonSerializer.Deserialize<R>(JsonSerializer.Serialize(obj));
            }
        }
    }
}
