using Newtonsoft.Json;
using Sparrow.StandardResult.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 标准输出
    /// </summary>
    public class Standard : AbstractStandard, IStandardFormat, IAdditionalField
    {
        internal string Key { get; set; }
        internal StandardResultOption Option { get; set; }
        internal StandardPagination<object> Pagination { get; set; }
        internal Dictionary<string, object> AdditionalFieldDict { get; set; } = new Dictionary<string, object>();
        /// <summary>
        /// 标准输出
        /// </summary>
        public Standard()
        {
            Key = StandardResultConsts.DefaultKey;
            Option = StandardResultValues.StandardResultOptions[StandardResultConsts.DefaultKey];
        }
        /// <summary>
        /// 标准输出
        /// </summary>
        /// <param name="key">标识</param>
        public Standard(string key)
        {
            Key = key;
            Option = StandardResultValues.StandardResultOptions[key];
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <returns></returns>
        public object StandardFormat()
        {
            var type = Data?.GetType();
            if (Data != null && Data is IStandardPagination)
            {
                Data = (Data as IStandardPagination).StandardFormat(Key);
            }
            var obj = Option.FormatStandard(new Standard
            {
                Success = Success,
                Code = Code,
                Data = Data,
                Errors = Errors,
                Message = Message,
                Time = Time,
                TraceId = TraceId
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
            var type = Data?.GetType();
            if (Data != null && Data is IStandardPagination)
            {
                Data = (Data as IStandardPagination).StandardFormat(key);
            }
            var obj = StandardResultValues.StandardResultOptions[key].FormatStandard(new Standard
            {
                Success = Success,
                Code = Code,
                Data = Data,
                Errors = Errors,
                Message = Message,
                Time = Time,
                TraceId = TraceId
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
        /// 序列化
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            return Serialize(Option.FormatJsonSerializerOption);
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <returns></returns>
        public string Serialize(JsonSerializerSettings serializer)
        {
            return JsonConvert.SerializeObject(StandardFormat(), serializer);
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
    /// <summary>
    /// 标准输出
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class StandardDto<T> : Standard
    {
        /// <summary>
        /// 数据
        /// </summary>
        public new T Data { get; set; }
    }
}
