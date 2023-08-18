using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.StandardResult
{
    public abstract partial class BaseDto<T>
    {
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
        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public object ExceptionResult(string message, string code, T data)
        {
            Message = message;
            Code = code;
            Data = data;
            Time = option.Time.Invoke();
            return Format();
        }
    }
}
