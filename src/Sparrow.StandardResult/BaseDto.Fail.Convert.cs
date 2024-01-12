namespace Sparrow.StandardResult
{
    public abstract partial class BaseDto<T>
    {
        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        public R FailResult<R>() where R : class
        {
            return Convert<R>(FailResult());
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public R FailResult<R>(string message) where R : class
        {
            return Convert<R>(FailResult(message));
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public R FailResult<R>(string message, string code) where R : class
        {
            return Convert<R>(FailResult(message, code));
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public R FailResult<R>(string message, string code, T data) where R : class
        {
            return Convert<R>(FailResult(message, code, data));
        }
    }
}
