using Sparrow.DataValidation;
using System.Collections.Generic;
using System.Text.Json;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 输出结果
    /// </summary>
    public class StandardDto : BaseDto
    {
        private readonly StandardResultOption option;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="key">标识</param>
        public StandardDto(string key = StandardResultConsts.DefaultKey)
        {
            option = StandardResultValues.StandardResultOptions[key];
        }
        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }

        #region SuccessResult
        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public object SuccessResult()
        {
            return SuccessResult(default, option.SuccessMessage, option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public object SuccessResult(object data)
        {
            return SuccessResult(data, option.SuccessMessage, option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public object SuccessResult(object data, string message)
        {
            return SuccessResult(data, message, option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public object SuccessResult(object data, string message, string code)
        {
            Data = data;
            Message = message;
            Code = code;
            Time = option.Time.Invoke();
            return Format();
        }
        #endregion

        #region FailResult
        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        public object FailResult()
        {
            return FailResult(option.FailMessage, option.FailCode, null);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public object FailResult(string message)
        {
            return FailResult(message, option.FailCode, null);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public object FailResult(string message, string code)
        {
            return FailResult(message, code, null);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public object FailResult(string message, string code, object data)
        {
            Message = message;
            Code = code;
            Data = data;
            Time = option.Time.Invoke();
            return Format();
        }
        #endregion

        #region ExceptionResult
        /// <summary>
        /// 异常
        /// </summary>
        /// <returns></returns>
        public object ExceptionResult()
        {
            return ExceptionResult(option.ExceptionMessage, option.ExceptionCode, null);
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public object ExceptionResult(string message)
        {
            return ExceptionResult(message, option.ExceptionCode, null);
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public object ExceptionResult(string message, string code)
        {
            return ExceptionResult(message, code, null);
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public object ExceptionResult(string message, string code, object data)
        {
            Message = message;
            Code = code;
            Data = data;
            Time = option.Time.Invoke();
            return Format();
        }
        #endregion

        #region ModelValidResult
        /// <summary>
        /// 模型验证失败
        /// </summary>
        /// <returns></returns>
        public object ModelValidResult()
        {
            return ModelValidResult(option.ModelValidMessage, option.ModelValidCode, null);
        }

        /// <summary>
        /// 模型验证失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public object ModelValidResult(string message)
        {
            return ModelValidResult(message, option.ModelValidCode, null);
        }
        /// <summary>
        /// 模型验证失败
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public object ModelValidResult(List<ModelValidErrorInfo> data)
        {
            return ModelValidResult(option.ModelValidMessage, option.ModelValidCode, data);
        }

        /// <summary>
        /// 模型验证失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public object ModelValidResult(string message, string code)
        {
            return ModelValidResult(message, code, null);
        }

        /// <summary>
        /// 模型验证失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public object ModelValidResult(string message, string code, List<ModelValidErrorInfo> data)
        {
            Message = message;
            Code = code;
            Data = option.FormatModelValid.Invoke(data);
            Time = option.Time.Invoke();
            return Format();
        }
        #endregion
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
            return JsonSerializer.Serialize(option.FormatDto(this), serializer);
        }
        /// <summary>
        /// 格式化
        /// </summary>
        /// <returns></returns>
        private object Format()
        {
            return option.FormatDto(this);
        }
    }
    /// <summary>
    /// 结果模型
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public class StandardDto<T> : BaseDto
    {
        private readonly StandardResultOption option;
        private readonly string _key;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="key">标识</param>
        public StandardDto(string key = StandardResultConsts.DefaultKey)
        {
            _key = key;
            option = StandardResultValues.StandardResultOptions[key];
        }
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }

        #region FailResult
        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        public object FailResult()
        {
            return FailResult(option.FailMessage, option.FailCode);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public object FailResult(string message)
        {
            return FailResult(message, option.FailCode);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public object FailResult(string message, string code)
        {
            Message = message;
            Code = code;
            Time = option.Time.Invoke();
            return Format();
        }
        #endregion

        #region SuccessResult
        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public object SuccessResult()
        {
            return SuccessResult(default, option.SuccessMessage, option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public object SuccessResult(T data)
        {
            return SuccessResult(data, option.SuccessMessage, option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public object SuccessResult(T data, string message)
        {
            return SuccessResult(data, message, option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public object SuccessResult(T data, string message, string code)
        {
            Data = data;
            Message = message;
            Code = code;
            Time = option.Time.Invoke();
            return Format();
        }
        #endregion

        #region ExceptionResult
        /// <summary>
        /// 异常
        /// </summary>
        /// <returns></returns>
        public object ExceptionResult()
        {
            return ExceptionResult(option.ExceptionMessage, option.ExceptionCode);
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public object ExceptionResult(string message)
        {
            return ExceptionResult(message, option.ExceptionCode);
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public object ExceptionResult(string message, string code)
        {
            Message = message;
            Code = code;
            Time = option.Time.Invoke();
            return Format();
        }
        #endregion

        #region ModelValidResult
        /// <summary>
        /// 模型验证失败
        /// </summary>
        /// <returns></returns>
        public object ModelValidResult()
        {
            return ModelValidResult(option.ExceptionMessage, option.ExceptionCode);
        }

        /// <summary>
        /// 模型验证失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public object ModelValidResult(string message)
        {
            return ModelValidResult(message, option.ExceptionCode);
        }

        /// <summary>
        /// 模型验证失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public object ModelValidResult(string message, string code)
        {
            Message = message;
            Code = code;
            Time = option.Time.Invoke();
            return Format();
        }
        #endregion

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
            var dto = new StandardDto(_key)
            {
                Code = Code,
                Message = Message,
                Data = Data,
                Success = Success,
                Time = Time,
                TraceId = TraceId
            };
            return JsonSerializer.Serialize(option.FormatDto(dto), serializer);
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <returns></returns>
        private object Format()
        {
            var dto = new StandardDto(_key)
            {
                Code = Code,
                Message = Message,
                Data = Data,
                Success = Success,
                Time = Time,
                TraceId = TraceId
            };
            return option.FormatDto(dto);
        }

    }
}
