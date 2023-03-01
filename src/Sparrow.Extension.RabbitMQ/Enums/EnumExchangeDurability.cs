using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Extension.RabbitMQ
{
    /// <summary>
    /// 交换机持久性
    /// </summary>
    public enum EnumExchangeDurability
    {
        /// <summary>
        /// 持久
        /// </summary>
        Durable,
        /// <summary>
        /// 瞬时
        /// </summary>
        Transient
    }
}
