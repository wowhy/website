namespace Wechat.SDK.Message
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class ReceiveMessageBase : MessageBase
    {
        public long MsgId { get; set; }
    }
}