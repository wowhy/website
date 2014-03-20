using BLToolkit.Data;
using Ext.Net;
using StudyWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace StudyWeb
{
    public partial class _Login
    {
        [DirectMethod]
        public void Login()
        {
            using (var db = new UnitContext())
            {
                if (db.tb_User.Where(k => k.LoginName == this.txtLoginName.Text &&
                                          k.Password == this.txtPassword.Text &&
                                          k.State == 1)
                      .Count() != 0)
                {
                    FormsAuthentication.SetAuthCookie("user", true);
                    Redirect();
                    return;
                }
            }

            ShowMessageBox("用户名或密码错误！");
        }

        private void Redirect()
        {
            var url = Request["ret"] == null ?
                        FormsAuthentication.DefaultUrl :
                        Request["ret"].ToString();
            X.Redirect(url);
        }
    }
}