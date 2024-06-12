using Newtonsoft.Json;
using Sparrow.StandardResult.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 分页数据
    /// </summary>
    public class StandardPagination<T> : AbstractStandardPagination<T>, IStandardPagination, IAdditionalField
    {
        internal string Key { get; set; }
        internal StandardResultOption Option { get; set; }
        internal Dictionary<string, object> AdditionalFieldDict { get; set; } = new Dictionary<string, object>();
        /// <summary>
        /// 分页数据
        /// </summary>
        public StandardPagination()
        {
            Key = StandardResultConsts.DefaultKey;
            Option = StandardResultValues.StandardResultOptions[StandardResultConsts.DefaultKey];
        }
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="key">标识</param>
        public StandardPagination(string key)
        {
            Key = key;
            Option = StandardResultValues.StandardResultOptions[key];
        }
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="key">标识</param>
        /// <param name="list">数据列表</param>
        /// <param name="count">总数</param>
        /// <param name="pageIndex">页码，默认值为1</param>
        /// <param name="pageSize">页面大小，默认值为10</param>
        /// <returns></returns>
        public StandardPagination(string key, IList<T> list, int count, int pageIndex = 1, int pageSize = 10)
        {
            Key = key;
            Option = StandardResultValues.StandardResultOptions[key];
            Computer(list, count, pageIndex, pageSize);
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
            IList<object> list = default;
            if (List != null)
            {
                list = JsonConvert.DeserializeObject<IList<object>>(JsonConvert.SerializeObject(List));
            }
            var obj = Option.FormatStandardPagination(new StandardPagination<object>
            {
                List = list,
                Count = Count,
                PageIndex = PageIndex,
                PageSize = PageSize,
                PageCount = PageCount
            });
            if (AdditionalFieldDict is null || AdditionalFieldDict.Count == 0)
            {
                return obj;
            }
            else
            {
                return AdditionalField(obj, AdditionalFieldDict);
            }
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <returns></returns>
        public object StandardFormat(string key)
        {
            IList<object> list = default;
            if (List != null)
            {
                list = JsonConvert.DeserializeObject<IList<object>>(JsonConvert.SerializeObject(List));
            };
            var obj = StandardResultValues.StandardResultOptions[key].FormatStandardPagination(new StandardPagination<object>
            {
                List = list,
                Count = Count,
                PageIndex = PageIndex,
                PageSize = PageSize,
                PageCount = PageCount
            });
            if (AdditionalFieldDict is null || AdditionalFieldDict.Count == 0)
            {
                return obj;
            }
            else
            {
                return AdditionalField(obj, AdditionalFieldDict);
            }
        }

        /// <summary>
        /// 为对象添加附加字段
        /// </summary>
        /// <param name="name">附加字段名</param>
        /// <param name="value">附加字段值</param>
        public void AddAdditionalField(string name, object value)
        {
            if (AdditionalFieldDict.ContainsKey(name))
            {
                AdditionalFieldDict[name] = value;
            }
            else
            {
                AdditionalFieldDict.Add(name, value);
            }
        }

        /// <summary>
        /// 为对象添加附加字段
        /// </summary>
        /// <param name="obj">需要附加字段的对象实例</param>
        /// <param name="fields">附加字段字典</param>
        /// <returns></returns>
        internal override Dictionary<string, object> AdditionalField(object obj, Dictionary<string, object> fields)
        {
            if (obj is null)
            {
                return null;
            }
            var properties = obj.GetType().GetProperties();
            var dict = new Dictionary<string, object>();
            foreach (var property in properties)
            {
                if (!dict.ContainsKey(property.Name))
                {
                    dict.Add(property.Name, property.GetValue(obj, null));
                }
            }
            if (fields is null || fields.Count == 0)
            {
                return dict;
            }
            var keys = fields.Keys.ToList();
            for (int i = 0; i < keys.Count; i++)
            {
                if (!dict.ContainsKey(keys[i]))
                {
                    dict.Add(keys[i], fields[keys[i]]);
                }
            }
            return dict;
        }
    }
}
