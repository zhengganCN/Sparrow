using System.Collections.Generic;

namespace Sparrow.Extension.RabbitMQ
{
    /// <summary>
    /// 交换机参数
    /// </summary>
    public class ExchangeArgument
    {
        /// <summary>
        /// 交换机类型 默认值为Direct
        /// </summary>
        public EnumExchangeType Type { get; set; } = EnumExchangeType.Direct;
        /// <summary>
        /// 持久 默认值为true
        /// </summary>
        public bool Durable { get; set; } = true;
        /// <summary>
        /// 自动删除 默认值为false
        /// </summary>
        public bool AutoDelete { get; set; } = false;
        /// <summary>
        /// 其他参数
        /// </summary>
        public IDictionary<string, object> Arguments { get; set; } = new Dictionary<string, object>();
    }
}
