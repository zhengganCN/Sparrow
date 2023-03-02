namespace Sparrow.Extension.RabbitMQ
{
    /// <summary>
    /// 交换机类型
    /// </summary>
    public enum EnumExchangeType
    {
        /// <summary>
        /// 直连模式
        /// </summary>
        Direct,
        /// <summary>
        /// 发布/订阅模式(一个生产者发送的消息会被多个消费者获取)
        /// </summary>
        Fanout,
        /// <summary>
        /// 参数模式
        /// </summary>
        Headers,
        /// <summary>
        /// 主题模式
        /// </summary>
        Topic
    }
}
