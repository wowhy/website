using Ext.Net;
using StudyWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyWeb
{
    public partial class Default
    {
        [DirectMethod]
        public List<tb_MeetingRoom> GetRooms()
        {
            using (var db = new UnitContext())
            {
                return db.tb_MeetingRoom.Where(k => k.State == 1).ToList();
            }
        }
    }
}