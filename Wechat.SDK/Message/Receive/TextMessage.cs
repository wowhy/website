﻿namespace Wechat.SDK.Message.Receive
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TextMessage : ReceiveMessageBase
    {
        public override string MsgType
        {
            get { return "text"; }
        }
    }
}