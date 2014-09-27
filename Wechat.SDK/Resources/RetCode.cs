namespace Wechat.SDK.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RetCode
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Message { get; set; }

        public RetCode(int code, string message) 
        {
            this.Code = code;
            this.Message = message;
        }
    }
}