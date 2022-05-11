using Sparrow.Extension.System;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 结果模型
    /// </summary>
    public class ModelResult : BaseModelResult
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="type">时间格式类型</param>
        public ModelResult(EnumTimeType type = EnumTimeType.Timestamp) : base(type)
        {

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
            var message = EnumModelResult.EnumResult.Success.GetDescription();
            SuccessResult(default, message, (int)EnumModelResult.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public void SuccessResult(object data)
        {
            var message = EnumModelResult.EnumResult.Success.GetDescription();
            SuccessResult(data, message, (int)EnumModelResult.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public void SuccessResult(object data, string message)
        {
            SuccessResult(data, message, (int)EnumModelResult.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public void SuccessResult(object data, string message, int code)
        {
            Data = data;
            Message = message;
            Code = code;
        }
        #endregion

        #region SuccessResultStatic
        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public static ModelResult SuccessResultStatic()
        {
            var message = EnumModelResult.EnumResult.Success.GetDescription();
            return SuccessResultStatic(default, message, (int)EnumModelResult.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static ModelResult SuccessResultStatic(object data)
        {
            var message = EnumModelResult.EnumResult.Success.GetDescription();
            return SuccessResultStatic(data, message, (int)EnumModelResult.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static ModelResult SuccessResultStatic(object data, string message)
        {
            return SuccessResultStatic(data, message, (int)EnumModelResult.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public static ModelResult SuccessResultStatic(object data, string message, int code)
        {
            var model = new ModelResult
            {
                Data = data,
                Message = message,
                Code = code
            };
            return model;
        }
        #endregion
        #region FailResultStatic
        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        public static ModelResult FailResultStatic()
        {
            var message = EnumModelResult.EnumResult.Error.GetDescription();
            return FailResultStatic(message, (int)EnumModelResult.EnumResult.Error);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static ModelResult FailResultStatic(string message)
        {
            return FailResultStatic(message, (int)EnumModelResult.EnumResult.Error);
        }
        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public static ModelResult FailResultStatic(string message, int code)
        {
            var model = new ModelResult
            {
                Message = message,
                Code = code
            };
            return model;
        }
        #endregion

    }
    /// <summary>
    /// 结果模型
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public class ModelResult<T> : BaseModelResult
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="type">时间格式类型</param>
        public ModelResult(EnumTimeType type = EnumTimeType.Timestamp) : base(type)
        {
        }
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }

        #region FailResultStatic
        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        public static ModelResult<T> FailResultStatic()
        {
            var message = EnumModelResult.EnumResult.Error.GetDescription();
            return FailResultStatic(message, (int)EnumModelResult.EnumResult.Error);
        }
        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static ModelResult<T> FailResultStatic(string message)
        {
            return FailResultStatic(message, (int)EnumModelResult.EnumResult.Error);
        }
        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public static ModelResult<T> FailResultStatic(string message, int code)
        {
            var model = new ModelResult<T>
            {
                Message = message,
                Code = code
            };
            return model;
        }
        #endregion
        #region SuccessResult
        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public void SuccessResult()
        {
            var message = EnumModelResult.EnumResult.Success.GetDescription();
            SuccessResult(default, message, (int)EnumModelResult.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public void SuccessResult(T data)
        {
            var message = EnumModelResult.EnumResult.Success.GetDescription();
            SuccessResult(data, message, (int)EnumModelResult.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public void SuccessResult(T data, string message)
        {
            SuccessResult(data, message, (int)EnumModelResult.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public void SuccessResult(T data, string message, int code)
        {
            Data = data;
            Message = message;
            Code = code;
        }
        #endregion
        #region SuccessResultStatic
        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public static ModelResult<T> SuccessResultStatic()
        {
            var message = EnumModelResult.EnumResult.Success.GetDescription();
            return SuccessResultStatic(default, message, (int)EnumModelResult.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static ModelResult<T> SuccessResultStatic(T data)
        {
            var message = EnumModelResult.EnumResult.Success.GetDescription();
            return SuccessResultStatic(data, message, (int)EnumModelResult.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static ModelResult<T> SuccessResultStatic(T data, string message)
        {
            return SuccessResultStatic(data, message, (int)EnumModelResult.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public static ModelResult<T> SuccessResultStatic(T data, string message, int code)
        {
            var model = new ModelResult<T>
            {
                Data = data,
                Message = message,
                Code = code
            };
            return model;
        }
        #endregion
    }
}
