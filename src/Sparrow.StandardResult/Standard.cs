using Newtonsoft.Json;
using Sparrow.DataValidation;
using Sparrow.StandardResult.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 标准输出
    /// </summary>
    public class Standard : AbstractStandard, IStandardFormat
    {
        internal string Key { get; set; } 
        internal StandardResultOption Option { get; set; }
        internal StandardPagination<object> Pagination { get; set; }
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
        /// 数据是否已格式化
        /// </summary>
        private bool IsFormatStandard { get; set; }
        /// <summary>
        /// 格式化数据
        /// </summary>
        private object FormatData { get; set; }


        /// <summary>
        /// 重置格式化状态
        /// </summary>
        public void ResetFormat()
        {
            IsFormatStandard = false;
            FormatData = null;
        }

        /// <summary>
        /// 标准输出属性名列表
        /// </summary>
        private string[] StandardPropertyNames { get; set; } = new string[]
        {
            nameof(Data),
            nameof(Message),
            nameof(Code),
            nameof(Success),
            nameof(TraceId),
            nameof(Time),
            nameof(Errors),
        };

        /// <summary>
        /// 分页属性名列表
        /// </summary>
        private string[] PaginationPropertyNames { get; set; } = new string[]
        {
            "List",
            "Count",
            "PageIndex",
            "PageSize",
            "PageCount"
        };

        /// <summary>
        /// 格式化
        /// </summary>
        /// <returns></returns>
        public object StandardFormat()
        {
            if (IsFormatStandard)
            {
                return FormatData;
            }
            var type = Data?.GetType();
            if (Data != null && Data is IStandardPagination)
            {
                Data = (Data as IStandardPagination).StandardFormat();
            }
            FormatData = Option.FormatStandard(new Standard
            {
                Success = Success,
                Code = Code,
                Data = Data,
                Errors = Errors,
                Message = Message,
                Time = Time,
                TraceId = TraceId
            });
            IsFormatStandard = true;
            return FormatData;
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
        /// 格式化
        /// </summary>
        /// <param name="original">格式化前的数据实例</param>
        /// <param name="format">格式化后的数据实例</param>
        /// <returns></returns>
        private object Additional(object original, object format)
        {
            var dic = new Dictionary<string, object>();
            var formatProperties = format.GetType().GetProperties();
            foreach (var property in formatProperties)
            {
                dic.Add(property.Name, property.GetValue(format, null));
            }
            var originalProperties = original.GetType().GetProperties()
                .Where(e => !PaginationPropertyNames.Contains(e.Name))
                .ToList();
            foreach (var property in originalProperties)
            {
                dic.Add(property.Name, property.GetValue(original, null));
            }
            return dic;
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
