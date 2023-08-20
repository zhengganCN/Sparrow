using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Sparrow.StandardResult.Web
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    public class StandardControllerBase : ControllerBase
    {
        private readonly string _key;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="key"><see cref="StandardDto"/> key</param>
        public StandardControllerBase(string key = "default-sparrow-standard-result")
        {
            _key = key;
        }
        /// <summary>
        /// 输出
        /// </summary>
        /// <returns></returns>
        public StandardDto GetStandard()
        {
            return new StandardDto(_key);
        }
        /// <summary>
        /// 输出
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <returns></returns>
        public StandardDto<T> GetStandard<T>()
        {
            return new StandardDto<T>(_key);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        public StandardPagination GetStandardPagination()
        {
            return new StandardPagination(_key);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="list">数据</param>
        /// <param name="count">数据量</param>
        /// <param name="index">页号</param>
        /// <param name="size">页大小</param>
        /// <returns></returns>
        public object GetStandardPagination(object list, int count, int index, int size)
        {
            return new StandardPagination(_key).GetPagination(list, count, index, size);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="list">数据</param>
        /// <param name="count">数据量</param>
        /// <param name="page">分页参数接口</param>
        /// <returns></returns>
        public object GetStandardPagination(object list, int count, IPagination page)
        {
            return new StandardPagination(_key).GetPagination(list, count, page);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <returns></returns>
        public StandardPagination<T> GetStandardPagination<T>()
        {
            return new StandardPagination<T>(_key);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="list">数据</param>
        /// <param name="count">数据量</param>
        /// <param name="index">页号</param>
        /// <param name="size">页大小</param>
        /// <returns></returns>
        public object GetStandardPagination<T>(IList<T> list, int count, int index, int size)
        {
            return new StandardPagination<T>(_key).GetPagination(list, count, index, size);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="list">数据</param>
        /// <param name="count">数据量</param>
        /// <param name="page">分页参数接口</param>
        /// <returns></returns>
        public object GetStandardPagination<T>(IList<T> list, int count, IPagination page)
        {
            return new StandardPagination<T>(_key).GetPagination(list, count, page);
        }
    }
}
