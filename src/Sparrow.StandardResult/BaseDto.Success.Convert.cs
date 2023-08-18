using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.StandardResult
{
    public abstract partial class BaseDto<T>
    {
        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public R SuccessResult<R>() where R : class
        {
            return Convert<R>(SuccessResult());
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public R SuccessResult<R>(T data) where R : class
        {
            return Convert<R>(SuccessResult(data));
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public R SuccessResult<R>(T data, string message) where R : class
        {
            return Convert<R>(SuccessResult(data, message));
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public R SuccessResult<R>(T data, string message, string code) where R : class
        {
            return Convert<R>(SuccessResult(data, message, code));
        }
    }
}
