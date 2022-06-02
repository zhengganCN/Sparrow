using Sparrow.Extension.System;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 输出结果
    /// </summary>
    public class Dto : BaseDto
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="type">时间格式类型</param>
        public Dto(EnumTimeType type = EnumTimeType.Timestamp) : base(type)
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
            var message = EnumDto.EnumResult.Success.GetDescription();
            SuccessResult(default, message, (int)EnumDto.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public void SuccessResult(object data)
        {
            var message = EnumDto.EnumResult.Success.GetDescription();
            SuccessResult(data, message, (int)EnumDto.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public void SuccessResult(object data, string message)
        {
            SuccessResult(data, message, (int)EnumDto.EnumResult.Success);
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
        public static Dto SuccessResultStatic()
        {
            var message = EnumDto.EnumResult.Success.GetDescription();
            return SuccessResultStatic(default, message, (int)EnumDto.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static Dto SuccessResultStatic(object data)
        {
            var message = EnumDto.EnumResult.Success.GetDescription();
            return SuccessResultStatic(data, message, (int)EnumDto.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static Dto SuccessResultStatic(object data, string message)
        {
            return SuccessResultStatic(data, message, (int)EnumDto.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public static Dto SuccessResultStatic(object data, string message, int code)
        {
            var dto = new Dto
            {
                Data = data,
                Message = message,
                Code = code
            };
            return dto;
        }
        #endregion
        #region FailResultStatic
        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        public static Dto FailResultStatic()
        {
            var message = EnumDto.EnumResult.Error.GetDescription();
            return FailResultStatic(message, (int)EnumDto.EnumResult.Error);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static Dto FailResultStatic(string message)
        {
            return FailResultStatic(message, (int)EnumDto.EnumResult.Error);
        }
        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public static Dto FailResultStatic(string message, int code)
        {
            var dto = new Dto
            {
                Message = message,
                Code = code
            };
            return dto;
        }
        #endregion

    }
    /// <summary>
    /// 结果模型
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public class Dto<T> : BaseDto
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="type">时间格式类型</param>
        public Dto(EnumTimeType type = EnumTimeType.Timestamp) : base(type)
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
        public static Dto<T> FailResultStatic()
        {
            var message = EnumDto.EnumResult.Error.GetDescription();
            return FailResultStatic(message, (int)EnumDto.EnumResult.Error);
        }
        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static Dto<T> FailResultStatic(string message)
        {
            return FailResultStatic(message, (int)EnumDto.EnumResult.Error);
        }
        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public static Dto<T> FailResultStatic(string message, int code)
        {
            var dto = new Dto<T>
            {
                Message = message,
                Code = code
            };
            return dto;
        }
        #endregion
        #region SuccessResult
        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public void SuccessResult()
        {
            var message = EnumDto.EnumResult.Success.GetDescription();
            SuccessResult(default, message, (int)EnumDto.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public void SuccessResult(T data)
        {
            var message = EnumDto.EnumResult.Success.GetDescription();
            SuccessResult(data, message, (int)EnumDto.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public void SuccessResult(T data, string message)
        {
            SuccessResult(data, message, (int)EnumDto.EnumResult.Success);
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
        public static Dto<T> SuccessResultStatic()
        {
            var message = EnumDto.EnumResult.Success.GetDescription();
            return SuccessResultStatic(default, message, (int)EnumDto.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static Dto<T> SuccessResultStatic(T data)
        {
            var message = EnumDto.EnumResult.Success.GetDescription();
            return SuccessResultStatic(data, message, (int)EnumDto.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static Dto<T> SuccessResultStatic(T data, string message)
        {
            return SuccessResultStatic(data, message, (int)EnumDto.EnumResult.Success);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public static Dto<T> SuccessResultStatic(T data, string message, int code)
        {
            var dto = new Dto<T>
            {
                Data = data,
                Message = message,
                Code = code
            };
            return dto;
        }
        #endregion
    }
}
