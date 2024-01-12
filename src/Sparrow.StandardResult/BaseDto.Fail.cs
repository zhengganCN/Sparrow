namespace Sparrow.StandardResult
{
    public abstract partial class BaseDto<T>
    {
        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        public object FailResult()
        {
            return FailResult(option.FailMessage, option.FailCode, default);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public object FailResult(string message)
        {
            return FailResult(message, option.FailCode, default);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public object FailResult(string message, string code)
        {
            return FailResult(message, code, default);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public object FailResult(string message, string code, T data)
        {
            Message = message;
            Code = code;
            Data = data;
            Time = option.Time.Invoke();
            return Format();
        }
    }
}
