namespace Sparrow.Extension.RabbitMQ
{
    /// <summary>
    /// 队列持久性
    /// </summary>
    public enum EnumQueueDurability
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
