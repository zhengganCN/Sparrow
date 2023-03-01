using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Extension.RabbitMQ
{
    public enum EnumExchangeArgument
    {
        /// <summary>
        /// 如果无法将邮件路由到此交换机，请将其发送到此处指定的备用交换机
        /// </summary>
        alternate_exchange
    }
}
