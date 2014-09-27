namespace Wechat.SDK.Message
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class MessageBase
    {
        public string ToUserName { get; set; }

        public string FromUserName { get; set; }

        public DateTimeOffset CreateTime { get; set; }

        public abstract string MsgType { get; }
    }
}