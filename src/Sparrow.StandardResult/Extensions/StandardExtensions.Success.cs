namespace Sparrow.StandardResult
{
    /// <summary>
    /// 成功
    /// </summary>
    public static partial class StandardExtensions
    {
        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public static object SuccessResult(this Standard standard)
        {
            return SuccessResult(standard, standard.Data, standard.Option.SuccessMessage, standard.Option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static object SuccessResult(this Standard standard, object data)
        {
            return SuccessResult(standard, data, standard.Option.SuccessMessage, standard.Option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static object SuccessResult(this Standard standard, object data, string message)
        {
            return SuccessResult(standard, data, message, standard.Option.SuccessCode);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public static object SuccessResult(this Standard standard, object data, string message, string code)
        {
            standard.Data = data;
            standard.Message = message;
            standard.Code = code;
            standard.Time = standard.Option.Time.Invoke();
            return standard.StandardFormat();
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="pagination">分页数据</param>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public static object SuccessResult<T>(this Standard standard, IStandardPagination pagination, string message, string code)
        {
            standard.Data = pagination;
            standard.Message = message;
            standard.Code = code;
            standard.Time = standard.Option.Time.Invoke();
            return standard.StandardFormat();
        }
    }
}
