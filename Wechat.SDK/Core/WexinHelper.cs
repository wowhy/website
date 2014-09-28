namespace Wechat.SDK.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using HyLibrary.ExtensionMethod;

    public static class WexinHelper
    {
        public static bool CheckSignature(
            string signature,
            string timestamp,
            string nonce,
            string token)
        {
            using (var sha1 = SHA1.Create())
            {
                var list = new List<string>() 
                {
                    token, timestamp, nonce
                };

                list.Sort();

                var value = list.Join("");
                var buffer = value.ToBytes();
                if (string.CompareOrdinal(sha1.ComputeHash(buffer).ToHexString(), signature) == 0)
                {
                    return true;
                }
            }

            return false;
        }


    }
}