using System.Collections.Generic;
using System.Linq;

namespace Sparrow.StandardResult.Abstracts
{
    /// <summary>
    /// 抽象标准输出基类
    /// </summary>
    public abstract class AbstractStandardBase
    {
        /// <summary>
        /// 为对象添加附加字段
        /// </summary>
        /// <param name="obj">需要附加字段的对象实例</param>
        /// <param name="fields">附加字段字典</param>
        /// <returns></returns>
        internal virtual Dictionary<string, object> AdditionalField(object obj, Dictionary<string, object> fields)
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
