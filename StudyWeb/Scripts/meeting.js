/// <reference path="/Scripts/ext-all.js" />
/// <reference path="/Scripts/extnet-all.js" />

Date.prototype.format = function (format) {
    var o = {
        "M+": this.getMonth() + 1, //month
        "d+": this.getDate(),    //day
        "h+": this.getHours(),   //hour
        "m+": this.getMinutes(), //minute
        "s+": this.getSeconds(), //second
        "q+": Math.floor((this.getMonth() + 3) / 3),  //quarter
        "S": this.getMilliseconds() //millisecond
    }

    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }

    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
}

var __tl = {};

function create_timeline(sections) {
    // 会议室列
    __tl.sections = sections;
    __tl.tasks = [];

    for (var i = 0; i < sections.length; i++) {
        Ext.select('#room tbody').first().insertHtml('beforeEnd', '<tr><td>' + sections[i].label + '</td></tr>');
    }
}

function init_timeline(start, end, st) {
    start.setHours(0);
    start.setMinutes(0);
    start.setSeconds(0);
    end.setHours(0);
    end.setMinutes(0);
    end.setSeconds(0);

    __tl.start = start; // 起始时间
    __tl.end = end;     // 结束时间
    __tl.days = 0;      // 总共日期
    __tl.map = [];      // 索引映射, 2维数组, 根据日期及时间偏移量查找对应的列Index 

    var c_date = Ext.select('#timeline thead #c_date'), // 日期表头
	    c_time = Ext.select('#timeline thead #c_time'), // 时间表头
	    t_body = Ext.select('#timeline tbody'), // 背景单元
        cols = 0;   // 时间列index

    t_body.update('');
    c_date.update('');
    c_time.update('');

    var index = 0;
    if (st != undefined) {
        index = st * 2;
    }

    // 时间轴 表头
    do {
        ++__tl.days;

        var array = [];
        var tmp = start.format('yyyy-MM-dd');
        __tl.map[tmp] = array;

        c_date.insertHtml('beforeEnd', '<td colspan="' + (48 - index) + '">' + tmp + '</td>');
        for (var i = index; i < 48; i++) {
            c_time.insertHtml('beforeEnd', '<td id=' + tmp + '_' + i + '>' +
                        (i < 20 ? '0' : '') +
                        Math.round(i / 2 - 0.1) + ':' + (i % 2 == 0 ? '00' : '30') +
                        '</td>');

            array[i] = cols;
            ++cols;
        }

        start.setTime(start.getTime() + 1000 * 60 * 60 * 24);
    }
    while (start <= end);

    // 背景表格
    for (var i = 0; i < __tl.sections.length; i++) {
        var tr = '<tr key=' + __tl.sections[i].key + '>';
        for (var j = index; j < 48 * __tl.days; j++) {
            tr += '<td>&nbsp;</td>';
        }

//        for (var j = 0; j < __tl.days; j++) {
//            tr += '<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>' + // 5
//              '<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>' + // 5
//              '<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>' + // 5
//              '<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>' + // 5
//              '<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>' + // 5
//              '<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>' + // 5
//              '<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>' + // 5
//              '<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>' + // 5
//              '<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>' + // 5
//              '<td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>';  // 3              
//        }

        tr += '</tr>';
        t_body.insertHtml('beforeEnd', tr);
    }
}

function add_task(tasks) {
    for (var i = 0; i < tasks.length; i++) {
        var start = new Date(Date.parse(tasks[i].start.replace(/-/g, "/"))),
                    end = new Date(Date.parse(tasks[i].end.replace(/-/g, "/")));

        // id: 起始单元格相对日期的索引
        // offset: 单元格偏移量
        var id = start.getHours() * 2 + (start.getMinutes() >= 30 ? 1 : 0),
                    offset = ((end.getHours() - start.getHours()) * 60 + (end.getMinutes() - start.getMinutes())) / 30;
        offset = Math.round(offset);
        offset = offset == 0 ? 0 : offset - 1;

        // 起始单元格 index
        var cols = __tl.map[start.format('yyyy-MM-dd')][id];
        var td_class = tasks[i].permission == 'true' ? 'tl_task_p' : 'tl_task';
        Ext.select('tr[key=' + tasks[i].section_id + '] td:eq(' + cols + ')')
                    .addCls(td_class)
                    .set({ 'title': tasks[i].text });

        if (offset > 0) {
            Ext.select('tr[key=' + tasks[i].section_id + '] td:gt(' + cols + '):lt(' + offset + ')')
                    .addCls(td_class)
                    .set({ 'title': tasks[i].text });
        }
    }
}