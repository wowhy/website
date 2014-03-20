using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyWeb.FramePage
{
    public partial class GridMeeting : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest || !IsPostBack)
            {
                BuildColumns();
            }
        }

        private void BuildColumns()
        { 
            
        }

        private void AddColumns()
        {
            for (int i = 0; i < 24; i++)
            {
                grid.AddColumn(new Ext.Net.Column(new Column.Config 
                {
                }));
            }
        }
    }
}