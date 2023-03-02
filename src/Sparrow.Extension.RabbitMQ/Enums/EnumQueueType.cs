namespace Sparrow.Extension.RabbitMQ
{
    /// <summary>
    /// 枚举队列类型
    /// </summary>
    public enum EnumQueueType
    {
        /// <summary>
        /// 经典队列
        /// </summary>
        Classic,
        /// <summary>
        /// 仲裁队列，分布式
        /// </summary>
        Quorum,
        /// <summary>
        /// Stream队列
        /// </summary>
        Stream
    }
}
