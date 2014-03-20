using Ext.Net;
using BLToolkit.Data.Linq;
using StudyWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyWeb.Ajax
{
    /// <summary>
    /// MeetingRoom 的摘要说明
    /// </summary>
    public class MeetingRoom : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var action = context.Request["action"];
            var sa = string.IsNullOrWhiteSpace(action) ? StoreAction.Read : Store.Action(action);
            var sr = new StoreResponseData();          

            try
            {
                switch (sa)
                {
                    case StoreAction.Read:
                        this.ReadData(sr);
                        break;

                    case StoreAction.Create:
                        this.AddData(new StoreDataHandler(context).ObjectData<tb_MeetingRoom>(), sr);
                        break;

                    case StoreAction.Destroy:
                        this.RemoveData(new StoreDataHandler(context).ObjectData<tb_MeetingRoom>());
                        break;

                    case StoreAction.Update:
                        this.UpdateData(new StoreDataHandler(context).ObjectData<tb_MeetingRoom>());
                        break;
                }
            }
            catch(Exception ex)
            {
                sr.Success = false;
                sr.Message = ex.Message;
            }

            sr.Return();
        }

        private void ReadData(StoreResponseData sr)
        {
            using (var db = new UnitContext())
            {
                sr.Data = JSON.Serialize(db.tb_MeetingRoom.Where(k => k.State == 1).ToList());
            }
        }

        private void AddData(List<tb_MeetingRoom> list, StoreResponseData sr)
        {
            using (var db = new UnitContext())
            {
                db.BeginTransaction();

                var adds = new List<int>();

                foreach (var room in list)
                {
                    adds.Add(Convert.ToInt32(db.tb_MeetingRoom.InsertWithIdentity(() => new tb_MeetingRoom
                    {
                        RoomName = room.RoomName,
                        Location = room.Location ?? ""
                    })));
                }

                sr.Data = JSON.Serialize(db.tb_MeetingRoom.Where(k => adds.Contains(k.Id)).ToList());

                db.CommitTransaction();
            }
        }

        private void UpdateData(List<tb_MeetingRoom> list)
        {
            using (var db = new UnitContext())
            {
                db.BeginTransaction();

                foreach (var room in list)
                {
                    db.tb_MeetingRoom.Where(k => k.Id == room.Id)
                        .Set(k => k.RoomName, room.RoomName)
                        .Set(k => k.Location, room.Location ?? "")
                      .Update();
                }

                db.CommitTransaction();
            }
        }

        private void RemoveData(List<tb_MeetingRoom> list)
        {
            using (var db = new UnitContext())
            {
                db.BeginTransaction();

                var id = list.Select(k => k.Id);

                db.tb_MeetingRoom.Where(k => id.Contains(k.Id))
                    .Set(k => k.State, 0)
                  .Update();

                db.CommitTransaction();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}