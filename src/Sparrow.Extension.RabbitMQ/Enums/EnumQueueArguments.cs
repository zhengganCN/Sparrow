namespace Sparrow.Extension.RabbitMQ
{
    /// <summary>
    /// 枚举队列参数
    /// </summary>
    public enum EnumQueueArguments
    {
        /// <summary>
        /// 队列在自动删除之前可以使用多长时间（毫秒）
        /// </summary>
        x_expires,
        /// <summary>
        /// 发布到队列的消息在被丢弃之前可以生存多长时间（毫秒）。
        /// </summary>
        x_message_ttl,
        /// <summary>
        /// 这决定了当达到队列的最大长度时消息会发生什么。有效值为 drop-head, reject-publish or reject-publish-dlx。仲裁队列类型仅支持drop-head and reject-publish。
        /// </summary>
        x_overflow,
        /// <summary>
        /// 如果设置，请确保一次只有一个消费者从队列中消费，并在活动消费者被取消或死亡的情况下故障转移到另一个注册消费者。
        /// </summary>
        x_single_active_consumer,
        /// <summary>
        /// 如果邮件被拒绝或过期，将向其重新发布邮件的交易所的可选名称。
        /// </summary>
        x_dead_letter_exchange,
        /// <summary>
        /// 可选替换路由密钥，当邮件为死信时使用。如果未设置，则将使用邮件的原始路由密钥。
        /// </summary>
        x_dead_letter_routing_key,
        /// <summary>
        /// 队列在开始从其头部丢弃消息之前可以包含多少（ready）消息。
        /// </summary>
        x_max_length,
        /// <summary>
        /// 队列在开始从其头部丢弃就绪消息之前可以包含的消息的总正文大小。
        /// </summary>
        x_max_length_bytes,
        /// <summary>
        /// 队列支持的最大优先级数；如果未设置，队列将不支持消息优先级。
        /// </summary>
        x_max_priority,
        /// <summary>
        /// 将队列设置为惰性模式，在磁盘上保留尽可能多的消息以减少RAM使用；如果未设置，队列将保留内存缓存，以尽可能快地传递消息。
        /// </summary>
        x_queue_mode,
        /// <summary>
        /// 设置队列版本。默认为版本1。
        /// 版本1有一个基于日志的索引，它嵌入了小消息。
        /// 版本2有一个不同的索引，它可以在许多情况下提高内存使用率和性能，以及以前嵌入的消息的每个队列存储。
        /// </summary>
        x_queue_version,
        /// <summary>
        /// 设置在节点群集上声明队列领导者时所依据的规则。有效值为 client-local （default）和 balanced。
        /// </summary>
        x_queue_leader_locator
    }
}
