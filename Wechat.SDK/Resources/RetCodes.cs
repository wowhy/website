namespace Wechat.SDK.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static partial class RetCodes
    {
        private static Dictionary<int, RetCode> codes = new Dictionary<int, RetCode>();
        internal static Dictionary<int, RetCode> Codes { get { return codes; } }

        internal static void Reserve(int code, string message)
        {
            Codes.Add(code, new RetCode(code, message));
        }

        static RetCodes() 
        {
            ReserveAllCodes();
        }
    }
}