using Microsoft.Extensions.Logging;

namespace Sparrow.Util.Logger
{
    /// <summary>
    /// 通用日志
    /// </summary>
    public class CommonLogger
    {
        /// <summary>
        /// 日志实例
        /// </summary>
        public static ILogger Logger { get; internal set; }
    }
}
