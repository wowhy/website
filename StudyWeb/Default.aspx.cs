using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Newtonsoft.Json;
using BLToolkit.Data;
using System.Data.SqlClient;

namespace StudyWeb
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindData();
            }
        }

        protected void cboTheme_DirectSelect(object sender, DirectEventArgs e)
        {
            var theme = (Theme)Enum.Parse(typeof(Theme), this.cboTheme.Text);
            this.SetTheme(theme);
            X.Reload();
        }

        private void BindData()
        {
            // 设置当前选择的主题
            this.cboTheme.Text = Manager.Theme.ToString();

            // 加载会议室列表
            this.store.DataSource = this.GetRooms();
            this.store.DataBind();
        }
    }
}