using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyWeb.FramePage
{
    public partial class RoomList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Ext.Net.JsonWriter jw = new Ext.Net.JsonWriter(new Ext.Net.JsonWriter.Config { });
        }
    }
}