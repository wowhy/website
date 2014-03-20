using BLToolkit.Data;
using BLToolkit.Data.Linq;
using Ext.Net;
using StudyWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


namespace StudyWeb
{
    public partial class Register
    {
        [DirectMethod]
        public void CreateUser()
        {
            try
            {
                AssertNullOrEmpty(this.txtLoginName.Text);
                AssertNullOrEmpty(this.txtPassword.Text);
                AssertNullOrEmpty(this.txtUserName.Text);

                using (var db = new UnitContext())
                {
                    db.BeginTransaction();

                    if (db.tb_User.Where(k => k.LoginName == this.txtLoginName.Text && k.State == 1)
                          .Count() != 0)
                        throw new ArgumentException("用户名已经存在！");

                    db.tb_User.Insert(() => new tb_User
                    {
                        UserName = this.txtUserName.Text,
                        LoginName = this.txtLoginName.Text,
                        Password = this.txtPassword.Text
                    });

                    db.CommitTransaction();
                }

                ShowMessageBox(
                    "注册成功",
                    handler: "window.location='/Login.aspx';");
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }
        }
    }
}