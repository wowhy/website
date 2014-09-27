namespace Wechat.SDK.Message
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class SendMessageBase : MessageBase
    {
        public virtual void Write(Stream stream) 
        {
        }
    }
}