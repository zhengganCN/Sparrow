using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// Base输出
    /// </summary>
    public abstract partial class BaseDto<T> where T : class
    {
        internal StandardResultOption option;
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public object Code { get; set; }
        /// <summary>
        /// 请求是否成功
        /// </summary>
        public bool Success { get; set; } = true;
        /// <summary>
        /// 跟踪ID
        /// </summary>
        public string TraceId { get; internal set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 时间
        /// </summary>
        public object Time { get; set; }
        /// <summary>
        /// 错误列表
        /// </summary>
        public string[] Errors { get; set; }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            return Serialize(option.FormatJsonSerializerOption);
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <returns></returns>
        public string Serialize(JsonSerializerOptions serializer)
        {
            return JsonSerializer.Serialize(Format(), serializer);
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <returns></returns>
        public object Format()
        {
            return option.FormatStandardDto(new StandardDto
            {
                Success = Success,
                Code = Code,
                Data = Data,
                Errors = Errors,
                Message = Message,
                Time = Time,
                TraceId = TraceId
            });
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
