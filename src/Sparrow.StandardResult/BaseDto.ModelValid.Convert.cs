using Sparrow.DataValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.StandardResult
{
    public abstract partial class BaseDto<T>
    {
        /// <summary>
        /// 模型验证失败
        /// </summary>
        /// <returns></returns>
        public R ModelValidResult<R>() where R : class
        {
            return Convert<R>(ModelValidResult());
        }

        /// <summary>
        /// 模型验证失败
        /// </summary>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public R ModelValidResult<R>(List<ModelValidErrorInfo> errors) where R : class
        {
            return Convert<R>(ModelValidResult(errors));
        }

        /// <summary>
        /// 模型验证失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public R ModelValidResult<R>(string message) where R : class
        {
            return Convert<R>(ModelValidResult(message));
        }

        /// <summary>
        /// 模型验证失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public R ModelValidResult<R>(string message, string code) where R : class
        {
            return Convert<R>(ModelValidResult(message, code));
        }

        /// <summary>
        /// 模型验证失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public R ModelValidResult<R>(string message, string code, List<ModelValidErrorInfo> errors) where R : class
        {
            return Convert<R>(ModelValidResult(message, code, errors));
        }
    }
}
