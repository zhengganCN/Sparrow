namespace Sparrow.StandardResult
{
    /// <summary>
    /// 失败
    /// </summary>
    public static partial class StandardExtensions
    {
        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        public static object FailResult(this Standard standard)
        {
            return FailResult(standard, standard.Option.FailMessage, standard.Option.FailCode, standard.Data);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static object FailResult(this Standard standard, string message)
        {
            return FailResult(standard, message, standard.Option.FailCode, standard.Data);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public static object FailResult(this Standard standard, string message, string code)
        {
            return FailResult(standard, message, code, standard.Data);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static object FailResult(this Standard standard, string message, string code, object data)
        {
            standard.Message = message;
            standard.Code = code;
            standard.Data = data;
            standard.Time = standard.Option.Time.Invoke();
            return standard.StandardFormat();
        }
    }
}
