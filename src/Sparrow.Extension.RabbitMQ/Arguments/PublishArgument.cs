using RabbitMQ.Client;

namespace Sparrow.Extension.RabbitMQ
{
    /// <summary>
    /// 发布参数
    /// </summary>
    public class PublishArgument
    {
        /// <summary>
        /// Mandatory
        /// </summary>
        public bool Mandatory { get; set; } = false;
        /// <summary>
        /// 属性
        /// </summary>
        public IBasicProperties BasicProperties { get; set; } = null;
    }
}
