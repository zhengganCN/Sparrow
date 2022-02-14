using Sparrow.Extension.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.StandardResult
{
    public static class ModelResultExtension
    {
        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public static void SuccessResult(this ModelResult result)
        {
            result.Data = default;
            result.Message = EnumModelResult.EnumResult.Success.GetDescription();
            result.Code = (int)EnumModelResult.EnumResult.Success;
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static void SuccessResult(this ModelResult result,object data)
        {
            result.Data = data;
            result.Message = EnumModelResult.EnumResult.Success.GetDescription();
            result.Code = (int)EnumModelResult.EnumResult.Success;
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static void SuccessResult(this ModelResult result, object data, string message)
        {
            result.Data = data;
            result.Message = message;
            result.Code = (int)EnumModelResult.EnumResult.Success;
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public static void SuccessResult(this ModelResult result, object data, string message, int code)
        {
            result.Data = data;
            result.Message = message;
            result.Code = code;
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        public static void FailResult(this ModelResult result)
        {
            result.Data = null;
            result.Message = EnumModelResult.EnumResult.Error.GetDescription();
            result.Code = (int)EnumModelResult.EnumResult.Error;
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static void FailResult(this ModelResult result, string message)
        {
            result.Data = null;
            result.Message = message;
            result.Code = (int)EnumModelResult.EnumResult.Error;
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public static void FailResult(this ModelResult result, string message, int code)
        {
            result.Data = null;
            result.Message = message;
            result.Code = code;
        }
    }
}
