namespace OceanWechat.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using HyLibrary.ExtensionMethod;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Check(string signature, string timestamp, string nonce, string echostr)
        {
            using (var sha1 = SHA1.Create())
            {
                var token = ConfigurationManager.AppSettings["wechat:token"];
                var list = new List<string>() 
                {
                    token, timestamp, nonce
                };

                list.Sort();

                var value = list.Join("");
                var buffer = value.ToBytes();
                if (string.CompareOrdinal(sha1.ComputeHash(buffer).ToHexString(), signature) == 0)
                {
                    return echostr;
                }
            }

            return string.Empty;
        }

        public ActionResult Goto(string url)
        {
            // return Redirect(url);

            var request = (HttpWebRequest)HttpWebRequest.Create(url);

            // request.UserAgent = "mozilla/5.0 (iphone; cpu iphone os 7_1_2 like mac os x) applewebkit/534.46 (khtml, like gecko) mobile/9b206";
            request.UserAgent = this.Request.UserAgent;
            var index = request.UserAgent.IndexOf("micromessenger", StringComparison.OrdinalIgnoreCase);
            if (index != -1)
            {
                request.UserAgent = request.UserAgent.Substring(0, index);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                foreach (var header in response.Headers.AllKeys)
                {
                    if (this.Response.Headers[header] != null)
                    {
                        this.Response.Headers[header] = response.Headers[header];
                    }
                }

                var ms = new MemoryStream();
                var buffer = new byte[4096];
                var len = 0;
                while ((len = stream.Read(buffer, 0, 4096)) > 0)
                {
                    ms.Write(buffer, 0, len);
                }

                ms.Seek(0, SeekOrigin.Begin);

                return File(ms, response.ContentType);
            }
        }

        public ActionResult Taobao(string id)
        {
            var url = "http://h5.m.taobao.com/awp/core/detail.htm?id=" + id;
            var request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.UserAgent = this.Request.UserAgent;
            var index = request.UserAgent.IndexOf("micromessenger", StringComparison.OrdinalIgnoreCase);
            if (index != -1)
            {
                request.UserAgent = request.UserAgent.Substring(0, index);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                foreach (var header in response.Headers.AllKeys)
                {
                    if (this.Response.Headers[header] != null)
                    {
                        this.Response.Headers[header] = response.Headers[header];
                    }
                }

                var ms = new MemoryStream();
                var buffer = new byte[4096];
                var len = 0;
                while ((len = stream.Read(buffer, 0, 4096)) > 0)
                {
                    ms.Write(buffer, 0, len);
                }

                ms.Seek(0, SeekOrigin.Begin);

                return File(ms, response.ContentType);
            }
        }

        public ActionResult TaobaoApp(string id)
        {
            var url = "taobao://h5.m.taobao.com/awp/core/detail.htm?id=" + id;
            return Redirect(url);
        }
    }
}