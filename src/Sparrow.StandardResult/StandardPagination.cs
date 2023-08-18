using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 分页数据
    /// </summary>
    public class StandardPagination : BasePagination, IStandardResultFormat
    {
        private readonly StandardResultOption option;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="key">标识</param>
        public StandardPagination(string key = StandardResultConsts.DefaultKey)
        {
            option = StandardResultValues.StandardResultOptions[key];
        }
        
        /// <summary>
        /// 计算分页数据
        /// </summary>
        /// <param name="list">数据</param>
        /// <param name="count">总数</param>
        /// <param name="pageIndex">页码，默认值为1</param>
        /// <param name="pageSize">页面大小，默认值为10</param>
        private void Computer(object list, int count, int pageIndex = 1, int pageSize = 10)
        {
            List = list;
            Count = count;
            PageIndex = pageIndex;
            PageSize = pageSize;
            PageCount = (int)Math.Ceiling((double)count / PageSize);
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="count">总数</param>
        /// <param name="pageIndex">页码，默认值为1</param>
        /// <param name="pageSize">页面大小，默认值为10</param>
        /// <returns></returns>
        public object GetPagination(object list, int count, int pageIndex = 1, int pageSize = 10)
        {
            Computer(list, count, pageIndex, pageSize);
            return Format();
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
        public object GetPagination(object list, int count, Dictionary<string,object> additional, int pageIndex = 1, int pageSize = 10)
        {
            Computer(list, count, pageIndex, pageSize);
            return Format(additional);
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="count">总数</param>
        /// <param name="page">分页参数</param>
        /// <returns></returns>
        public object GetPagination(object list, int count, IPagination page)
        {
            Computer(list, count, page.GetPageIndex(), page.GetPageSize());
            return Format();
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="count">总数</param>
        /// <param name="additional">附加属性</param>
        /// <param name="page">分页参数</param>
        /// <returns></returns>
        public object GetPagination(object list, int count, Dictionary<string, object> additional, IPagination page)
        {
            Computer(list, count, page.GetPageIndex(), page.GetPageSize());
            return Format(additional);
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <returns></returns>
        public object Format()
        {
            return option.FormatStandardPagination(this);
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="additional">附加属性</param>
        /// <returns></returns>
        public object Format(Dictionary<string, object> additional)
        {
            var obj = Format();
            if (additional == null || additional.Count == 0)
            {
                return obj;
            }
            var properties = obj.GetType().GetProperties();
            var dic = new Dictionary<string, object>();
            foreach (var property in properties)
            {
                dic.Add(property.Name, property.GetValue(obj, null));
            }
            foreach (var item in additional)
            {
                dic.Add(item.Key, item.Value);
            }
            var dynamic = dic as dynamic;
            return dynamic;
        }
    }

    /// <summary>
    /// 分页数据
    /// </summary>
    public class StandardPagination<T> : BasePagination, IStandardResultFormat
    {
        private readonly StandardResultOption option;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="key">标识</param>
        public StandardPagination(string key = StandardResultConsts.DefaultKey)
        {
            option = StandardResultValues.StandardResultOptions[key];
        }

        /// <summary>
        /// 计算分页数据
        /// </summary>
        /// <param name="list">数据</param>
        /// <param name="count">总数</param>
        /// <param name="pageIndex">页码，默认值为1</param>
        /// <param name="pageSize">页面大小，默认值为10</param>
        private void Computer(IList<T> list, int count, int pageIndex = 1, int pageSize = 10)
        {
            List = list;
            Count = count;
            PageIndex = pageIndex;
            PageSize = pageSize;
            PageCount = (int)Math.Ceiling((double)count / PageSize);
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="count">总数</param>
        /// <param name="pageIndex">页码，默认值为1</param>
        /// <param name="pageSize">页面大小，默认值为10</param>
        /// <returns></returns>
        public object GetPagination(IList<T> list, int count, int pageIndex = 1, int pageSize = 10)
        {
            Computer(list, count, pageIndex, pageSize);
            return Format();
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
        public object GetPagination(IList<T> list, int count, Dictionary<string, object> additional, int pageIndex = 1, int pageSize = 10)
        {
            Computer(list, count, pageIndex, pageSize);
            return Format(additional);
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="count">总数</param>
        /// <param name="page">分页参数</param>
        /// <returns></returns>
        public object GetPagination(IList<T> list, int count, IPagination page)
        {
            Computer(list, count, page.GetPageIndex(), page.GetPageSize());
            return Format();
        }

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="count">总数</param>
        /// <param name="additional">附加属性</param>
        /// <param name="page">分页参数</param>
        /// <returns></returns>
        public object GetPagination(IList<T> list, int count, Dictionary<string, object> additional, IPagination page)
        {
            Computer(list, count, page.GetPageIndex(), page.GetPageSize());
            return Format(additional);
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <returns></returns>
        public object Format()
        {
            return option.FormatStandardPagination(this);
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="additional">附加属性</param>
        /// <returns></returns>
        public object Format(Dictionary<string, object> additional)
        {
            var obj = Format();
            if (additional == null || additional.Count == 0)
            {
                return obj;
            }
            var properties = obj.GetType().GetProperties();
            var dic = new Dictionary<string, object>();
            foreach (var property in properties)
            {
                dic.Add(property.Name, property.GetValue(obj, null));
            }
            foreach (var item in additional)
            {
                dic.Add(item.Key, item.Value);
            }
            var dynamic = dic as dynamic;
            return dynamic;
        }
    }
}
