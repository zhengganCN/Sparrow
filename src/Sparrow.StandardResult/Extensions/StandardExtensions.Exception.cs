namespace Sparrow.StandardResult
{
    /// <summary>
    /// 异常
    /// </summary>
    public static partial class StandardExtensions
    {
        /// <summary>
        /// 异常
        /// </summary>
        /// <returns></returns>
        public static object ExceptionResult(this Standard standard)
        {
            return ExceptionResult(standard, standard.Option.ExceptionMessage, standard.Option.ExceptionCode, standard.Data);
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static object ExceptionResult(this Standard standard, string message)
        {
            return ExceptionResult(standard, message, standard.Option.ExceptionCode, standard.Data);
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public static object ExceptionResult(this Standard standard, string message, string code)
        {
            return ExceptionResult(standard, message, code, standard.Data);
        }
        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static object ExceptionResult(this Standard standard, string message, string code, object data)
        {
            standard.Message = message;
            standard.Code = code;
            standard.Data = data;
            standard.Time = standard.Option.Time.Invoke();
            return standard.StandardFormat();
        }
    }
}
