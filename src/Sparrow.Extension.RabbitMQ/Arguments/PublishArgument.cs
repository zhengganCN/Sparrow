using RabbitMQ.Client;
using Sparrow.Extension.RabbitMQ.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Sparrow.Extension.RabbitMQ
{
    /// <summary>
    /// 发布参数
    /// </summary>
    public class PublishArgument
    {
        private IBasicProperties _properties;
        /// <summary>
        /// Mandatory
        /// </summary>
        public bool Mandatory { get; set; } = false;
        /// <summary>
        /// 属性
        /// </summary>
        public IBasicProperties BasicProperties { get; set; } = null;
        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        public void AddBasicProperties(EnumPublishProperty property, object value)
        {
            if (_properties is null)
            {
                _properties = new DefaultBasicProperties();
            }
            switch (property)
            {
                case EnumPublishProperty.content_type:
                    _properties.ClearContentType();
                    _properties.ContentType = value as string;
                    break;
                case EnumPublishProperty.content_encoding:
                    _properties.ClearContentEncoding();
                    _properties.ContentEncoding = value as string;
                    break;
                case EnumPublishProperty.priority:
                    _properties.ClearPriority();
                    _properties.Priority = (byte)value;
                    break;
                case EnumPublishProperty.correlation_id:
                    _properties.ClearCorrelationId();
                    _properties.CorrelationId = value as string;
                    break;
                case EnumPublishProperty.reply_to:
                    _properties.ClearReplyTo();
                    _properties.ReplyTo = value as string;
                    break;
                case EnumPublishProperty.expiration:
                    _properties.ClearExpiration();
                    _properties.Expiration = value as string;
                    break;
                case EnumPublishProperty.message_id:
                    _properties.ClearMessageId();
                    _properties.MessageId = value as string;
                    break;
                case EnumPublishProperty.timestamp:
                    _properties.ClearTimestamp();
                    _properties.Timestamp = new AmqpTimestamp((long)value);
                    break;
                case EnumPublishProperty.type:
                    _properties.ClearType();
                    _properties.Type = value as string;
                    break;
                case EnumPublishProperty.user_id:
                    _properties.ClearUserId();
                    _properties.UserId = value as string;
                    break;
                case EnumPublishProperty.app_id:
                    _properties.ClearAppId();
                    _properties.AppId = value as string;
                    break;
                case EnumPublishProperty.cluster_id:
                    _properties.ClearClusterId();
                    _properties.ClusterId = value as string;
                    break;
            }
        }
    }
    internal class DefaultBasicProperties : IBasicProperties
    {
        public string AppId { get; set; }
        public string ClusterId { get; set; }
        public string ContentEncoding { get; set; }
        public string ContentType { get; set; }
        public string CorrelationId { get; set; }
        public byte DeliveryMode { get; set; }
        public string Expiration { get; set; }
        public IDictionary<string, object> Headers { get; set; }
        public string MessageId { get; set; }
        public bool Persistent { get; set; }
        public byte Priority { get; set; }
        public string ReplyTo { get; set; }
        public PublicationAddress ReplyToAddress { get; set; }
        public AmqpTimestamp Timestamp { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }

        public ushort ProtocolClassId { get; }

        public string ProtocolClassName { get; }

        public void ClearAppId()
        {
            AppId = default;
        }

        public void ClearClusterId()
        {
            ClusterId = default;
        }

        public void ClearContentEncoding()
        {
            ContentEncoding = default;
        }

        public void ClearContentType()
        {
            ContentType = default;
        }

        public void ClearCorrelationId()
        {
            CorrelationId = default;
        }

        public void ClearDeliveryMode()
        {
            DeliveryMode = default;
        }

        public void ClearExpiration()
        {
            Expiration = default;
        }

        public void ClearHeaders()
        {
            Headers = default;
        }

        public void ClearMessageId()
        {
            MessageId = default;
        }

        public void ClearPriority()
        {
            Priority = default;
        }

        public void ClearReplyTo()
        {
            ReplyTo = default;
        }

        public void ClearTimestamp()
        {
            Timestamp = default;
        }

        public void ClearType()
        {
            Type = default;
        }

        public void ClearUserId()
        {
            UserId = default;
        }

        public bool IsAppIdPresent()
        {
            return !string.IsNullOrEmpty(AppId);
        }

        public bool IsClusterIdPresent()
        {
            return !string.IsNullOrEmpty(ClusterId);
        }

        public bool IsContentEncodingPresent()
        {
            return !string.IsNullOrEmpty(ContentEncoding);
        }

        public bool IsContentTypePresent()
        {
            return !string.IsNullOrEmpty(ContentType);
        }

        public bool IsCorrelationIdPresent()
        {
            return !string.IsNullOrEmpty(CorrelationId);
        }

        public bool IsDeliveryModePresent()
        {
            return DeliveryMode != 0;
        }

        public bool IsExpirationPresent()
        {
            return !string.IsNullOrEmpty(Expiration);
        }

        public bool IsHeadersPresent()
        {
            return Headers?.Any() == true;
        }

        public bool IsMessageIdPresent()
        {
            return !string.IsNullOrEmpty(MessageId);
        }

        public bool IsPriorityPresent()
        {
            return Priority != 0;
        }

        public bool IsReplyToPresent()
        {
            return !string.IsNullOrEmpty(ReplyTo);
        }

        public bool IsTimestampPresent()
        {
            return Timestamp.UnixTime != 0;
        }

        public bool IsTypePresent()
        {
            return !string.IsNullOrEmpty(Type);
        }

        public bool IsUserIdPresent()
        {
            return !string.IsNullOrEmpty(UserId);
        }
    }
}
