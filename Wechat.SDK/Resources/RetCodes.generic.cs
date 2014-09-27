

namespace Wechat.SDK.Resources
{
    public static partial class RetCodes
    {
        internal static void ReserveAllCodes()
        {
            Reserve(-1, @"系统繁忙");
            Reserve(0, @"请求成功");
            Reserve(40001, @"获取access_token时AppSecret错误，或者access_token无效");
            Reserve(40002, @"不合法的凭证类型");
            Reserve(40003, @"不合法的OpenID");
            Reserve(40004, @"不合法的媒体文件类型");
            Reserve(40005, @"不合法的文件类型");
            Reserve(40006, @"不合法的文件大小");
            Reserve(40007, @"不合法的媒体文件id");
            Reserve(40008, @"不合法的消息类型");
            Reserve(40009, @"不合法的图片文件大小");
            Reserve(40010, @"不合法的语音文件大小");
            Reserve(40011, @"不合法的视频文件大小");
            Reserve(40012, @"不合法的缩略图文件大小");
            Reserve(40013, @"不合法的APPID");
            Reserve(40014, @"不合法的access_token");
            Reserve(40015, @"不合法的菜单类型");
            Reserve(40016, @"不合法的按钮个数");
            Reserve(40017, @"不合法的按钮个数");
            Reserve(40018, @"不合法的按钮名字长度");
            Reserve(40019, @"不合法的按钮KEY长度");
            Reserve(40020, @"不合法的按钮URL长度");
            Reserve(40021, @"不合法的菜单版本号");
            Reserve(40022, @"不合法的子菜单级数");
            Reserve(40023, @"不合法的子菜单按钮个数");
            Reserve(40024, @"不合法的子菜单按钮类型");
            Reserve(40025, @"不合法的子菜单按钮名字长度");
            Reserve(40026, @"不合法的子菜单按钮KEY长度");
            Reserve(40027, @"不合法的子菜单按钮URL长度");
            Reserve(40028, @"不合法的自定义菜单使用用户");
            Reserve(40029, @"不合法的oauth_code");
            Reserve(40030, @"不合法的refresh_token");
            Reserve(40031, @"不合法的openid列表");
            Reserve(40032, @"不合法的openid列表长度");
            Reserve(40033, @"不合法的请求字符，不能包含\uxxxx格式的字符");
            Reserve(40035, @"不合法的参数");
            Reserve(40038, @"不合法的请求格式");
            Reserve(40039, @"不合法的URL长度");
            Reserve(40050, @"不合法的分组id");
            Reserve(40051, @"分组名字不合法");
            Reserve(41001, @"缺少access_token参数");
            Reserve(41002, @"缺少appid参数");
            Reserve(41003, @"缺少refresh_token参数");
            Reserve(41004, @"缺少secret参数");
            Reserve(41005, @"缺少多媒体文件数据");
            Reserve(41006, @"缺少media_id参数");
            Reserve(41007, @"缺少子菜单数据");
            Reserve(41008, @"缺少oauth");
            Reserve(41009, @"缺少openid");
            Reserve(42001, @"access_token超时");
            Reserve(42002, @"refresh_token超时");
            Reserve(42003, @"oauth_code超时");
            Reserve(43001, @"需要GET请求");
            Reserve(43002, @"需要POST请求");
            Reserve(43003, @"需要HTTPS请求");
            Reserve(43004, @"需要接收者关注");
            Reserve(43005, @"需要好友关系");
            Reserve(44001, @"多媒体文件为空");
            Reserve(44002, @"POST的数据包为空");
            Reserve(44003, @"图文消息内容为空");
            Reserve(44004, @"文本消息内容为空");
            Reserve(45001, @"多媒体文件大小超过限制");
            Reserve(45002, @"消息内容超过限制");
            Reserve(45003, @"标题字段超过限制");
            Reserve(45004, @"描述字段超过限制");
            Reserve(45005, @"链接字段超过限制");
            Reserve(45006, @"图片链接字段超过限制");
            Reserve(45007, @"语音播放时间超过限制");
            Reserve(45008, @"图文消息超过限制");
            Reserve(45009, @"接口调用超过限制");
            Reserve(45010, @"创建菜单个数超过限制");
            Reserve(45015, @"回复时间超过限制");
            Reserve(45016, @"系统分组，不允许修改");
            Reserve(45017, @"分组名字过长");
            Reserve(45018, @"分组数量超过上限");
            Reserve(46001, @"不存在媒体数据");
            Reserve(46002, @"不存在的菜单版本");
            Reserve(46003, @"不存在的菜单数据");
            Reserve(46004, @"不存在的用户");
            Reserve(47001, @"解析JSON/XML内容错误");
            Reserve(48001, @"api功能未授权");
            Reserve(50001, @"用户未授权该api");
        }

        public static RetCode @RM1 { get { return Codes[-1]; } }
        public static RetCode @R0 { get { return Codes[0]; } }
        public static RetCode @R40001 { get { return Codes[40001]; } }
        public static RetCode @R40002 { get { return Codes[40002]; } }
        public static RetCode @R40003 { get { return Codes[40003]; } }
        public static RetCode @R40004 { get { return Codes[40004]; } }
        public static RetCode @R40005 { get { return Codes[40005]; } }
        public static RetCode @R40006 { get { return Codes[40006]; } }
        public static RetCode @R40007 { get { return Codes[40007]; } }
        public static RetCode @R40008 { get { return Codes[40008]; } }
        public static RetCode @R40009 { get { return Codes[40009]; } }
        public static RetCode @R40010 { get { return Codes[40010]; } }
        public static RetCode @R40011 { get { return Codes[40011]; } }
        public static RetCode @R40012 { get { return Codes[40012]; } }
        public static RetCode @R40013 { get { return Codes[40013]; } }
        public static RetCode @R40014 { get { return Codes[40014]; } }
        public static RetCode @R40015 { get { return Codes[40015]; } }
        public static RetCode @R40016 { get { return Codes[40016]; } }
        public static RetCode @R40017 { get { return Codes[40017]; } }
        public static RetCode @R40018 { get { return Codes[40018]; } }
        public static RetCode @R40019 { get { return Codes[40019]; } }
        public static RetCode @R40020 { get { return Codes[40020]; } }
        public static RetCode @R40021 { get { return Codes[40021]; } }
        public static RetCode @R40022 { get { return Codes[40022]; } }
        public static RetCode @R40023 { get { return Codes[40023]; } }
        public static RetCode @R40024 { get { return Codes[40024]; } }
        public static RetCode @R40025 { get { return Codes[40025]; } }
        public static RetCode @R40026 { get { return Codes[40026]; } }
        public static RetCode @R40027 { get { return Codes[40027]; } }
        public static RetCode @R40028 { get { return Codes[40028]; } }
        public static RetCode @R40029 { get { return Codes[40029]; } }
        public static RetCode @R40030 { get { return Codes[40030]; } }
        public static RetCode @R40031 { get { return Codes[40031]; } }
        public static RetCode @R40032 { get { return Codes[40032]; } }
        public static RetCode @R40033 { get { return Codes[40033]; } }
        public static RetCode @R40035 { get { return Codes[40035]; } }
        public static RetCode @R40038 { get { return Codes[40038]; } }
        public static RetCode @R40039 { get { return Codes[40039]; } }
        public static RetCode @R40050 { get { return Codes[40050]; } }
        public static RetCode @R40051 { get { return Codes[40051]; } }
        public static RetCode @R41001 { get { return Codes[41001]; } }
        public static RetCode @R41002 { get { return Codes[41002]; } }
        public static RetCode @R41003 { get { return Codes[41003]; } }
        public static RetCode @R41004 { get { return Codes[41004]; } }
        public static RetCode @R41005 { get { return Codes[41005]; } }
        public static RetCode @R41006 { get { return Codes[41006]; } }
        public static RetCode @R41007 { get { return Codes[41007]; } }
        public static RetCode @R41008 { get { return Codes[41008]; } }
        public static RetCode @R41009 { get { return Codes[41009]; } }
        public static RetCode @R42001 { get { return Codes[42001]; } }
        public static RetCode @R42002 { get { return Codes[42002]; } }
        public static RetCode @R42003 { get { return Codes[42003]; } }
        public static RetCode @R43001 { get { return Codes[43001]; } }
        public static RetCode @R43002 { get { return Codes[43002]; } }
        public static RetCode @R43003 { get { return Codes[43003]; } }
        public static RetCode @R43004 { get { return Codes[43004]; } }
        public static RetCode @R43005 { get { return Codes[43005]; } }
        public static RetCode @R44001 { get { return Codes[44001]; } }
        public static RetCode @R44002 { get { return Codes[44002]; } }
        public static RetCode @R44003 { get { return Codes[44003]; } }
        public static RetCode @R44004 { get { return Codes[44004]; } }
        public static RetCode @R45001 { get { return Codes[45001]; } }
        public static RetCode @R45002 { get { return Codes[45002]; } }
        public static RetCode @R45003 { get { return Codes[45003]; } }
        public static RetCode @R45004 { get { return Codes[45004]; } }
        public static RetCode @R45005 { get { return Codes[45005]; } }
        public static RetCode @R45006 { get { return Codes[45006]; } }
        public static RetCode @R45007 { get { return Codes[45007]; } }
        public static RetCode @R45008 { get { return Codes[45008]; } }
        public static RetCode @R45009 { get { return Codes[45009]; } }
        public static RetCode @R45010 { get { return Codes[45010]; } }
        public static RetCode @R45015 { get { return Codes[45015]; } }
        public static RetCode @R45016 { get { return Codes[45016]; } }
        public static RetCode @R45017 { get { return Codes[45017]; } }
        public static RetCode @R45018 { get { return Codes[45018]; } }
        public static RetCode @R46001 { get { return Codes[46001]; } }
        public static RetCode @R46002 { get { return Codes[46002]; } }
        public static RetCode @R46003 { get { return Codes[46003]; } }
        public static RetCode @R46004 { get { return Codes[46004]; } }
        public static RetCode @R47001 { get { return Codes[47001]; } }
        public static RetCode @R48001 { get { return Codes[48001]; } }
        public static RetCode @R50001 { get { return Codes[50001]; } }
    }
}