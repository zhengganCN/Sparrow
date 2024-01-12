namespace Sparrow.StandardResult
{
    public abstract partial class BaseDto<T>
    {
        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public object SuccessResult()
        {
            return SuccessResult(default, option.SuccessMessage, option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public object SuccessResult(T data)
        {
            return SuccessResult(data, option.SuccessMessage, option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public object SuccessResult(T data, string message)
        {
            return SuccessResult(data, message, option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public object SuccessResult(T data, string message, string code)
        {
            Data = data;
            Message = message;
            Code = code;
            Time = option.Time.Invoke();
            return Format();
        }
    }
}
