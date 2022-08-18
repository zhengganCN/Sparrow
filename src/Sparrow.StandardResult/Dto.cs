using Sparrow.Extension.System;
using System.Runtime.InteropServices.ComTypes;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 输出结果
    /// </summary>
    public class Dto : BaseDto
    {
        private readonly StandardResultOption option;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="key">标识</param>
        public Dto(string key = StandardResultValues.DefaultKey)
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
        public void SuccessResult()
        {
            SuccessResult(default, option.SuccessMessage, option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public void SuccessResult(object data)
        {
            SuccessResult(data, option.SuccessMessage, option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public void SuccessResult(object data, string message)
        {
            SuccessResult(data, message, option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public void SuccessResult(object data, string message, string code)
        {
            Data = data;
            Message = message;
            Code = code;
            Time = option.Time.Invoke();
        }
        #endregion

        #region FailResult
        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        public void FailResult()
        {
            FailResult(option.FailMessage, option.FailCode, null);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public void FailResult(string message)
        {
            FailResult(message, option.FailCode, null);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public void FailResult(string message, string code)
        {
            FailResult(message, code, null);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public void FailResult(string message, string code, object data)
        {
            Message = message;
            Code = code;
            Data = data;
            Time = option.Time.Invoke();
        }
        #endregion

        #region ExceptionResult
        /// <summary>
        /// 异常
        /// </summary>
        /// <returns></returns>
        public void ExceptionResult()
        {
            ExceptionResult(option.ExceptionMessage, option.ExceptionCode, null);
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public void ExceptionResult(string message)
        {
            ExceptionResult(message, option.ExceptionCode, null);
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public void ExceptionResult(string message, string code)
        {
            ExceptionResult(message, code, null);
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public void ExceptionResult(string message, string code, object data)
        {
            Message = message;
            Code = code;
            Data = data;
            Time = option.Time.Invoke();
        }
        #endregion
    }
    /// <summary>
    /// 结果模型
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public class Dto<T> : BaseDto
    {
        private readonly StandardResultOption option;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="key">标识</param>
        public Dto(string key = StandardResultValues.DefaultKey)
        {
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
        public void FailResult()
        {
            FailResult(option.FailMessage, option.FailCode);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public void FailResult(string message)
        {
            FailResult(message, option.FailCode);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public void FailResult(string message, string code)
        {
            Message = message;
            Code = code;
            Time = option.Time.Invoke();
        }
        #endregion

        #region SuccessResult
        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public void SuccessResult()
        {
            SuccessResult(default, option.SuccessMessage, option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public void SuccessResult(T data)
        {
            SuccessResult(data, option.SuccessMessage, option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public void SuccessResult(T data, string message)
        {
            SuccessResult(data, message, option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public void SuccessResult(T data, string message, string code)
        {
            Data = data;
            Message = message;
            Code = code;
            Time = option.Time.Invoke();
        }
        #endregion
        #region ExceptionResult
        /// <summary>
        /// 异常
        /// </summary>
        /// <returns></returns>
        public void ExceptionResult()
        {
            ExceptionResult(option.ExceptionMessage, option.ExceptionCode);
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public void ExceptionResult(string message)
        {
            ExceptionResult(message, option.ExceptionCode);
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public void ExceptionResult(string message, string code)
        {
            Message = message;
            Code = code;
            Time = option.Time.Invoke();
        }
        #endregion
    }
}
