namespace Sparrow.Extension.RabbitMQ
{
    /// <summary>
    /// 交换机类型
    /// </summary>
    public enum EnumExchangeType
    {
        /// <summary>
        /// 直连
        /// </summary>
        Direct,
        Fanout,
        Headers,
        /// <summary>
        /// 订阅
        /// </summary>
        Topic
    }
}
