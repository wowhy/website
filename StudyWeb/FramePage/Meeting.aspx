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

    <script type="text/javascript" src="/Scripts/jquery-1.10.1.min.js"></script>
    <script type="text/javascript">
        var section = [{key: 1, label: '主会议室' }];
    </script>
    <script type="text/javascript" src="/Scripts/meeting.js"></script>
</head>
<body>
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
        $(document).ready(function () {
            var start = new Date(),
                end = new Date();
            end.setTime(start.getTime());

            $('#dtpStart').val(start.format('yyyy-MM-dd'));
            if (!section) return;

            create_timeline(section);

            loading(start, end);

            var t = new Date();
            var hh = t.getHours() * 2 + (t.getMinutes() >= 30 ? 1 : 0);
            $('.tl_line').scrollLeft($('#' + t.format('yyyy-MM-dd') + '_' + hh).offset().left - $('.tl_line').offset().left);

            $('#btnQuery').click(function () {
                if ($('#dtpStart').val() == '') {
                    alert('请选择查询日期');
                }

                var s = new Date(Date.parse($('#dtpStart').val().replace(/-/g, "/") + ' 00:00:00'));
                var e = new Date(s.getTime());

                loading(s, e);
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
            $.ajax({
                url: "/Manager/Module/CRS/ajax/MeetingItems.aspx",
                type: "GET",
                dataType: "json",
                data: { s: s, e: e },
                contentType: "application/json",
                cache: false,
                success: function (data) {
                    if (data && data.state == 'true') {
                        add_task(data.items);
                    }
                }
            });
        }
    </script>
</body>
</html>
