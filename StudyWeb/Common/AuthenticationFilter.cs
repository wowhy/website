using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace StudyWeb.Common
{
    public static class AuthenticationFilter
    {
        private static HashSet<string> ignore = new HashSet<string>(StringComparer.OrdinalIgnoreCase) 
        {
            FormsAuthentication.LoginUrl.Trim('/'),
            "REGISTER.ASPX"
        };

        private static HashSet<string> resource = new HashSet<string>(StringComparer.OrdinalIgnoreCase) 
        {
            ".AXD", ".JPG", ".JPEG", ".GIF", ".PNG", ".BMP",
            ".SWF", ".FLV", ".JS"
        };

        private static HashSet<string> aspx = new HashSet<string>(StringComparer.OrdinalIgnoreCase) 
        {
            ".ASPX", ""
        };

        public static void Filter(Global This)
        {
            if (This.Request.IsAuthenticated)
                return;

            if (ignore.Contains(Path.GetFileName(This.Request.Path)))
                return;

            var extension = Path.GetExtension(This.Request.Path);
            if (resource.Contains(extension))
                return;

            if (aspx.Contains(extension))
            {                
                This.Response.Redirect(
                    FormsAuthentication.LoginUrl + 
                    "?ret=" + 
                    HttpUtility.UrlEncode(This.Request.RawUrl.ToString()));
                return;
            }

            This.Response.Clear();
            //This.Response.Write("");
            This.Response.End();
        }
    }
}