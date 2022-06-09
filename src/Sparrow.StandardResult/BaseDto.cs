using Sparrow.Extension.System;
using System;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// Base输出
    /// </summary>
    public class BaseDto
    {

        private static readonly DateTime DateTime1970 = new DateTime(1970, 1, 1, 0, 0, 0);
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="type">时间格式类型</param>
        public BaseDto(EnumTimeType type = EnumTimeType.Timestamp)
        {
            switch (type)
            {
                case EnumTimeType.Timestamp:
                    Time = (DateTime.UtcNow - DateTime1970).TotalSeconds;
                    break;
                case EnumTimeType.DateTime:
                    Time = DateTime.UtcNow;
                    break;
            }
        }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public int? Code { get; set; }
        /// <summary>
        /// 请求是否成功
        /// </summary>
        public bool Success { get; set; } = true;
        /// <summary>
        /// 跟踪ID
        /// </summary>
        public string TraceId { get; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 时间
        /// </summary>
        public object Time { get; private set; }
        #region FailResult
        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        public void FailResult()
        {
            var message = EnumDto.EnumResult.Error.GetDescription();
            FailResult(message, (int)EnumDto.EnumResult.Error);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public void FailResult(string message)
        {
            FailResult(message, (int)EnumDto.EnumResult.Error);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public void FailResult(string message, int code)
        {
            Message = message;
            Code = code;
        }
        #endregion
    }
}
