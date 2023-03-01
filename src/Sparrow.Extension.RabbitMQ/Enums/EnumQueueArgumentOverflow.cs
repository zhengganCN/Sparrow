using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Extension.RabbitMQ
{
    public enum EnumQueueArgumentOverflow
    {
        drop_head,
        reject_publish ,
        reject_publish_dlx
    }
}
