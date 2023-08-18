using Sparrow.DataValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparrow.StandardResult
{
    public abstract partial class BaseDto<T>
    {
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
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public object ModelValidResult(List<ModelValidErrorInfo> errors)
        {
            return ModelValidResult(option.ModelValidMessage, option.ModelValidCode, errors);
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
            ModelValidResult(message, code, null);
            return Format();
        }

        /// <summary>
        /// 模型验证失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <param name="data">错误信息</param>
        /// <returns></returns>
        public object ModelValidResult(string message, string code, List<ModelValidErrorInfo> data)
        {
            var errors = new List<string>();
            foreach (var item in data)
            {
                if (item.Errors?.Any() == true)
                {
                    errors.AddRange(item.Errors);
                }
            }
            Message = message;
            Code = code;
            Errors = errors.ToArray();
            Time = option.Time.Invoke();
            return Format();
        }
    }
}
