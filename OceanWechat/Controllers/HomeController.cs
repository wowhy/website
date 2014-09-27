namespace OceanWechat.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Security.Cryptography;
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
            return Redirect(url);
        }
    }
}