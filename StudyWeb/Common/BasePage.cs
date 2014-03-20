using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace StudyWeb
{
    public class BasePage : Page
    {
        private ResourceManager manager = new ResourceManager();
        public ResourceManager Manager
        {
            get { return manager; }
            protected set { manager = value; }
        }

        protected override void OnPreLoad(EventArgs e)
        {
            this.Header.Controls.Add(manager);
            if (!IsPostBack)
            {
                X.ResourceManager.Theme = this.GetTheme();
            }
            
            base.OnInit(e);
        }

        protected Theme GetTheme()
        {
            if (Request.Cookies["theme"] == null)
                return GlobalConfig.Settings.Theme;

            return (Theme)Enum.Parse(
                typeof(Theme),
                Request.Cookies["theme"].Value);
        }

        protected void SetTheme(Ext.Net.Theme theme)
        {
            Response.SetCookie(new HttpCookie("theme", theme.ToString())
            {
                Expires = DateTime.Now.AddDays(30)
            });
        }

        protected void ShowMessageBox(
            string msg, 
            string title = "提示", 
            MessageBox.Icon icon = MessageBox.Icon.INFO,
            string handler = null)
        {
            X.MessageBox.Show(new MessageBoxConfig
            {
                Title = title,
                Message = msg,
                Icon = icon,
                Buttons = MessageBox.Button.OK,
                Handler = handler
            });
        }

        protected void AssertNullOrEmpty(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException("input");
        }
    }
}