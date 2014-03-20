﻿using Ext.Net;
using StudyWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyWeb.FramePage
{
    public partial class Meeting
    {
        [DirectMethod]
        public static object GetRooms()
        {
            using (var db = new UnitContext())
            {
                var query = from p in db.tb_MeetingRoom
                            where p.State == 1
                            select new 
                            {
                                key = p.Id,
                                label = p.RoomName
                            };
                return query.ToList();
            }
        }
    }
}