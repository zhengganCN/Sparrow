using Sparrow.DataValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 无效模型
    /// </summary>
    public static partial class StandardExtensions
    {
        /// <summary>
        /// 无效模型
        /// </summary>
        /// <returns></returns>
        public static object InvalidModelResult(this Standard standard)
        {
            return InvalidModelResult(standard, standard.Option.ExceptionMessage, standard.Option.ExceptionCode);
        }

        /// <summary>
        /// 无效模型
        /// </summary>
        /// <param name="errors">错误信息</param>
        /// <returns></returns>
        public static object InvalidModelResult(this Standard standard, List<ModelValidErrorInfo> errors)
        {
            return InvalidModelResult(standard, standard.Option.ModelValidMessage, standard.Option.ModelValidCode, errors);
        }

        /// <summary>
        /// 无效模型
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static object InvalidModelResult(this Standard standard, string message)
        {
            return InvalidModelResult(standard, message, standard.Option.ExceptionCode);
        }

        /// <summary>
        /// 无效模型
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public static object InvalidModelResult(this Standard standard, string message, string code)
        {
            return InvalidModelResult(standard, message, code, null);
        }

        /// <summary>
        /// 无效模型
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <param name="data">错误信息</param>
        /// <returns></returns>
        public static object InvalidModelResult(this Standard standard, string message, string code, List<ModelValidErrorInfo> data)
        {
            var errors = new List<string>();
            foreach (var item in data)
            {
                if (item.Errors?.Any() == true)
                {
                    errors.AddRange(item.Errors);
                }
            }
            standard.Message = message;
            standard.Code = code;
            standard.Errors = errors.ToArray();
            standard.Time = standard.Option.Time.Invoke();
            return standard.StandardFormat();
        }
    }
}
