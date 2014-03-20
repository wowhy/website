<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Meeting.aspx.cs" Inherits="StudyWeb.FramePage.Meeting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
		"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
	<meta http-equiv="Content-type" content="text/html; charset=utf-8" />
	<title></title>
    <style type="text/css">
        /* 背景容器 */
        .tl_container{ width:100%; height:100%; }
    
        /* 左侧 Y轴容器 */
        .tl_room{ width:10%;float:left; }
    
        /* 右侧 X轴容器 */
        .tl_line{ width:90%; overflow:scroll;float:left; }
    
        .tl_container table{ border-collapse:collapse; text-align:center; }
        .tl_container table td { font-size:12px; }
        .tl_container thead { background:#dcdcdc; }
        .tl_container thead td{ height:20px; }
        .tl_room table td { border:1px solid #9f9f9f;  height:20px; }
        .tl_line thead td { border:1px solid #9f9f9f; border-left: 0px; }
        .tl_line tbody td { border-bottom:1px dotted #9f9f9f;  height:20px; }
    
        /* 单元格填充 */
        .tl_task{ background:#D2691E; }
        .tl_task_p{ background:#98FB98; }
    
        .clear { clear: both; display: block; overflow: hidden; visibility: hidden; width: 0; height: 0; }
    </style>
</head>
<body>
    <script type="text/javascript" src="/Scripts/meeting.js"></script>

    <div class="tl_container" style="margin-bottom:2px;">
        <div style="float:left;"><%=DateTime.Now.ToShortDateString() %> 至 <%=DateTime.Now.AddDays(7).ToShortDateString() %> 期间会议室预订情况</div>
        <div style="float:right;margin-top:7px;margin-right:18px;">
            <div style="float:left;margin-left:10px;">
            我的预订:&nbsp;&nbsp;
            </div>
            <div style="float:left;width:30px;background:#98FB98;">&nbsp;</div>
            <div style="float:left;margin-left:10px;">
            他人预订:&nbsp;&nbsp;
            </div>
            <div style="float:left;width:30px;background:#D2691E;">&nbsp;</div>
        </div>
    </div>
    <div class="clear"></div>
    <div class="tl_container">
        <div class="tl_room">
            <table id="room" style="width:100%">
                <thead>
                    <tr>
                        <td>日期</td>
                    </tr>
                    <tr>
                        <td>时间</td>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
        <div class="tl_line">
            <table id="timeline">
                <thead>
                    <tr id="c_date">
                    </tr>
                    <tr id="c_time">

                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    </div>

    <script type="text/javascript">
        function afterGetRooms(sections) {
            if (!sections) return;

            var start = new Date(),
                end = new Date();
            end.setTime(start.getTime() + (7 * 24 * 60 * 60 * 1000));

            create_timeline(sections);
            loading(start, end);

            var t = new Date();
            var hh = t.getHours() * 2 + (t.getMinutes() >= 30 ? 1 : 0);
            Ext.select('.tl_line').scroll('l', 
                Ext.select('#' + t.format('yyyy-MM-dd') + '_' + hh).first().getX() -
                Ext.select('.tl_line').first().getX());
        }

        Ext.onReady(function () {
            App.direct.GetRooms({
                success: function (result) {
                    afterGetRooms(result);
                }
            });
        });

        function loading(start, end, st) {
            var s = start.format('yyyy-MM-dd');
            var e = end.format('yyyy-MM-dd');
            if (st == undefined) {
                init_timeline(start, end);
            }
            else {
                init_timeline(start, end, st);
            }

            // loading data
            //$.ajax({
            //    url: "/Ajax/MeetingItems.ashx",
            //    type: "GET",
            //    dataType: "json",
            //    data: { s: s, e: e },
            //    contentType: "application/json",
            //    cache: false,
            //    success: function (data) {
            //        if (data && data.state == 'true') {
            //            add_task(data.items);
            //        }
            //    }
            //});
        }
    </script>
</body>
</html>
