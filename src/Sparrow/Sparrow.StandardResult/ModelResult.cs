using Sparrow.Extension.System;
using System;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 结果模型
    /// </summary>
    public class ModelResult
    {
        private static readonly DateTime DateTime1970 = new DateTime(1970, 1, 1, 0, 0, 0);
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="type">时间格式类型</param>
        public ModelResult(EnumTimeType type = EnumTimeType.Timestamp)
        {
            switch (type)
            {
                case EnumTimeType.Timestamp:
                    Time = (DateTime.UtcNow - DateTime1970).TotalSeconds;
                    break;
                case EnumTimeType.DateTime:
                    Time = DateTime.UtcNow;
                    break;
            }
        }
        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public int? Code { get; set; }
        /// <summary>
        /// 请求是否成功
        /// </summary>
        public bool Success { get; set; } = true;
        /// <summary>
        /// 跟踪ID
        /// </summary>
        public string TraceId { get; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 时间
        /// </summary>
        public object Time { get; private set; }

        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public static ModelResult SuccessResult()
        {
            var model = new ModelResult
            {
                Data = default,
                Message = EnumModelResult.EnumResult.Success.GetDescription(),
                Code = (int)EnumModelResult.EnumResult.Success
            };
            return model;
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static ModelResult SuccessResult(object data)
        {
            var model = new ModelResult
            {
                Data = data,
                Message = EnumModelResult.EnumResult.Success.GetDescription(),
                Code = (int)EnumModelResult.EnumResult.Success
            };
            return model;
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static ModelResult SuccessResult(object data, string message)
        {
            var model = new ModelResult
            {
                Data = data,
                Message = message,
                Code = (int)EnumModelResult.EnumResult.Success
            };
            return model;
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public static ModelResult SuccessResult(object data, string message, int code)
        {
            var model = new ModelResult
            {
                Data = data,
                Message = message,
                Code = code
            };
            return model;
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        public static ModelResult FailResult()
        {
            var model = new ModelResult
            {
                Message = EnumModelResult.EnumResult.Error.GetDescription(),
                Code = (int)EnumModelResult.EnumResult.Error
            };
            return model;
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static ModelResult FailResult(string message)
        {
            var model = new ModelResult
            {
                Message = message,
                Code = (int)EnumModelResult.EnumResult.Error
            };
            return model;
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public static ModelResult FailResult(string message, int code)
        {
            var model = new ModelResult
            {
                Message = message,
                Code = code
            };
            return model;
        }
    }
    /// <summary>
    /// 结果模型
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public class ModelResult<T> : ModelResult
    {
        /// <summary>
        /// 数据
        /// </summary>
        public new T Data { get; set; }
    }
}
