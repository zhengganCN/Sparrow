namespace Sparrow.StandardResult
{
    public abstract partial class BaseDto<T>
    {
        /// <summary>
        /// 异常
        /// </summary>
        /// <returns></returns>
        public R ExceptionResult<R>() where R : class
        {
            return Convert<R>(ExceptionResult());
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public R ExceptionResult<R>(string message) where R : class
        {
            return Convert<R>(ExceptionResult(message));
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public R ExceptionResult<R>(string message, string code) where R : class
        {
            return Convert<R>(ExceptionResult(message, code));
        }
        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public R ExceptionResult<R>(string message, string code, T data) where R : class
        {
            return Convert<R>(ExceptionResult(message, code, data));
        }
    }
}
