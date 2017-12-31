

namespace Dora.wx
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Weixin.MP;
    using Weixin.MP.Entities.Request;


    [Route("api/FwhApi")]
    [AllowAnonymous]
    public class FwhApiController : Controller
    {
        protected readonly ILogger<FwhApiController> _logger;


        const string Token = "craze";//你的token
        const string EncodingAESKey = "5c6376f6bf8cb3536f441b88b9cbff98";//你的token
        const string AppId = "wx3fe77afcef3c2848";//你的token

        public FwhApiController(
            ILoggerFactory loggerFactory
        )
        {
            this._logger = loggerFactory.CreateLogger<FwhApiController>();
        }

        // GET: api/values
        [AllowAnonymous]
        [HttpGet]
        public string Get(PostModel postModel, string echostr)
        {
            _logger.LogError("Get");

            if (CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, Token))
            {
                return echostr;
            }
            else
            {
                return ("failed:" + postModel.Signature + "," + CheckSignature.GetSignature(postModel.Timestamp, postModel.Nonce, Token) + "。" +
                    "如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
            }
        }


        // POST api/values
        [HttpPost]
        public string Post(PostModel postModel)
        {
            if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, Token))
            {
                return "参数错误！";
            }

            postModel.Token = Token;
            postModel.EncodingAESKey = EncodingAESKey;
            postModel.AppId = AppId;

            var messageHandler = new CustomMessageHandler.CustomMessageHandler(Request.Body, postModel, 10);

            messageHandler.Execute();
            return (messageHandler.ResponseDocument.ToString());
            //return new WeixinResult(messageHandler);//v0.8+
            //return new FixWeixinBugWeixinResult(messageHandler);//v0.8+





        }

       

        


        #region 消息类型适配器
        //private string ResponseMsg(string weixin)// 服务器响应微信请求
        //{
        //    //XmlDocument doc = new XmlDocument();
        //    //doc.LoadXml(weixin);//读取xml字符串
        //    //XmlElement root = doc.DocumentElement;
        //    //ExmlMsg xmlMsg = GetExmlMsg(root);
        //    ////XmlNode MsgType = root.SelectSingleNode("MsgType");
        //    ////string messageType = MsgType.InnerText;
        //    //string messageType = xmlMsg.MsgType;//获取收到的消息类型。文本(text)，图片(image)，语音等。

        //    string temp = string.Empty;

        //    var model = BasicSerialize<Receive.xml>.LoadXml(weixin);
        //    try
        //    {
        //        switch (model.MsgType)
        //        {
        //            //当消息为文本时
        //            case MsgType.text:
        //                temp = CallText(model);
        //                break;
        //            case MsgType.image:
        //                temp = CallImage(model);
        //                break;
        //            case MsgType.@event:
        //                temp = CallEvent(model);
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return temp;
        //}
        #endregion


        //private string getText(Receive.xml xmlMsg)
        //{
        //    string con = xmlMsg.Content.Trim();

        //    System.Text.StringBuilder retsb = new StringBuilder(200);
        //    retsb.Append("这里放你的业务逻辑");
        //    retsb.Append("接收到的消息：" + xmlMsg.Content);
        //    retsb.Append("用户的OPEANID：" + xmlMsg.FromUserName);

        //    return retsb.ToString();
        //}


        #region 操作文本消息 + void textCase(XmlElement root)

        //private string CallText(Receive.xml msg)
        //{
        //    int nowtime = ConvertDateTimeInt(DateTime.Now);
        //    string content = msg.Content;

        //    if (content.ToLower().StartsWith("b"))
        //    {
        //        var model = new Send.TextMessage()
        //        {
        //            Content = "您输入的班级邀请码有误，请检查后重试。还有2次重试机会。",
        //            MsgType = MsgType.text,
        //            CreateTime = nowtime,
        //            FromUserName = msg.ToUserName,
        //            ToUserName = msg.FromUserName
        //        };

        //        return SerializationHelper.Serialize(model);
        //    }
        //    else if (content.ToLower().StartsWith("kc"))
        //    {

        //        var model = new Send.ArticleMessage()
        //        {

        //            MsgType = MsgType.news,
        //            CreateTime = nowtime,
        //            FromUserName = msg.ToUserName,
        //            ToUserName = msg.FromUserName,
        //            ArticleCount = "1",
        //            Articles = new List<Send.Article>() { new Send.Article() { Title= "您已成功打入班级内部，开始学习吧！", Description= "课程名称：《高等数学》\r\n班级名称：0317141\r\n任课老师：稻草人\r\n点击进入班级，和小伙伴们认识吧！",
        //            PicUrl ="http://os.nieba.cn/cecheng.png",
        //            Url ="http://os.nieba.cn/zaoqi.html" } }
        //        };

        //        return SerializationHelper.Serialize(model);
        //    }
        //    else if (content == "人工服务")
        //    {
        //        var model = new Send.TextMessage()
        //        {
        //            Content = "Sorry! 作息全忙，请稍后再试！",
        //            MsgType = MsgType.text,
        //            CreateTime = nowtime,
        //            FromUserName = msg.ToUserName,
        //            ToUserName = msg.FromUserName
        //        };

        //        return SerializationHelper.Serialize(model);
        //    }
        //    else
        //    {
        //        var model = new Send.TextMessage()
        //        {
        //            Content = "帮助信息：\n\n1:输入B开头字符串进入班级\n2:输入ck开头字符串进入课程\n3:输入人工服务 转接人工客服",
        //            MsgType = MsgType.text,
        //            CreateTime = nowtime,
        //            FromUserName = msg.ToUserName,
        //            ToUserName = msg.FromUserName
        //        };

        //        return SerializationHelper.Serialize(model);
        //    }
        //}

        //private string CallImage(Receive.xml msg)
        //{
        //    int nowtime = ConvertDateTimeInt(DateTime.Now);
        //    string content = msg.Content;
        //    var model = new Send.TextMessage()
        //    {
        //        Content = "图片消息",
        //        MsgType = MsgType.text,
        //        CreateTime = nowtime,
        //        FromUserName = msg.ToUserName,
        //        ToUserName = msg.FromUserName
        //    };

        //    return SerializationHelper.Serialize(model);
        //}

        //private string CallEvent(Receive.xml msg)
        //{
        //    if (msg.Event == Event.subscribe)
        //    {
        //        //关注
        //        return CallEventSubscribe(msg);
        //    }
        //    else if (msg.Event == Event.unsubscribe)
        //    {
        //        //取消关注
        //        return CallEventUnsubscribe(msg);
        //    }
        //    else if (msg.Event == Event.CLICK)
        //    {
        //        return CallEventClick(msg);
        //    }
        //    else
        //    {
        //        return CallEventOther(msg);
        //    }
        //}

        //private string CallEventSubscribe(Receive.xml msg)
        //{
        //    int nowtime = ConvertDateTimeInt(DateTime.Now);

        //    var model = new Send.ArticleMessage()
        //    {

        //        MsgType = MsgType.news,
        //        CreateTime = nowtime,
        //        FromUserName = msg.ToUserName,
        //        ToUserName = msg.FromUserName,
        //        //Image = new Send.image() {  MediaId= "2KoTTu2xqdu6QwAwXWqOE84HHfOaoZEVkUeMYjC47wf0Io4mvbvMVsIHVVLWHXwS" }
        //        ArticleCount = "1",
        //        Articles = new List<Send.Article>() { new Send.Article() { Title= "关注成功，开启新的教与学体验之旅！", Description= "点击使用微信一键登录。",
        //            PicUrl ="http://os.nieba.cn/interest.png",
        //            Url ="http://www.baidu.com" } }
        //    };

        //    return SerializationHelper.Serialize(model);
        //}

        //private string CallEventClick(Receive.xml msg)
        //{
        //    int nowtime = ConvertDateTimeInt(DateTime.Now);

        //    if (msg.EventKey == "zaoqishike")
        //    {

        //        var model = new Send.ArticleMessage()
        //        {

        //            MsgType = MsgType.news,
        //            CreateTime = nowtime,
        //            FromUserName = msg.ToUserName,
        //            ToUserName = msg.FromUserName,
        //            ArticleCount = "1",
        //            Articles = new List<Send.Article>() { new Send.Article() { Title= "一起早起，来坚持一件有意义的小事！", Description= "加入【早起时刻】，更多新鲜出炉的知识甜点等你品尝！",
        //            PicUrl ="http://os.nieba.cn/zaoqishike.png",
        //            Url ="http://os.nieba.cn/zaoqi.html" } }
        //        };

        //        return SerializationHelper.Serialize(model);
        //    }
        //    else if (msg.EventKey == "inbanji")//inbanji
        //    {
        //        var model = new Send.TextMessage()
        //        {
        //            Content = "请直接回班级邀请码\n(不区分大小写)",
        //            MsgType = MsgType.text,
        //            CreateTime = nowtime,
        //            FromUserName = msg.ToUserName,
        //            ToUserName = msg.FromUserName
        //        };

        //        return SerializationHelper.Serialize(model);
        //    }
        //    else if (msg.EventKey == "inketang")//inbanji
        //    {
        //        var model = new Send.TextMessage()
        //        {
        //            Content = "请直接回复课堂暗号\n(不区分大小写)",
        //            MsgType = MsgType.text,
        //            CreateTime = nowtime,
        //            FromUserName = msg.ToUserName,
        //            ToUserName = msg.FromUserName
        //        };

        //        return SerializationHelper.Serialize(model);
        //    }
        //    else if (msg.EventKey == "help")//inbanji
        //    {
        //        var model = new Send.ArticleMessage()
        //        {

        //            MsgType = MsgType.news,
        //            CreateTime = nowtime,
        //            FromUserName = msg.ToUserName,
        //            ToUserName = msg.FromUserName,
        //            ArticleCount = "1",
        //            Articles = new List<Send.Article>() { new Send.Article() { Title= "雨课堂.帮助中心", Description= "如您需其他帮助，请直接回复【人工服务】工作人员会及时给您回复以解决您的问题。",
        //            PicUrl ="http://os.nieba.cn/help.png",
        //            Url ="http://os.nieba.cn/#/help" } }
        //        };

        //        return SerializationHelper.Serialize(model);
        //    }
        //    else
        //    {
        //        return CallEventOther(msg);
        //    }
        //}

        //private string CallEventUnsubscribe(Receive.xml msg)
        //{
        //    int nowtime = ConvertDateTimeInt(DateTime.Now);

        //    var model = new Send.TextMessage()
        //    {
        //        Content = "接收到事件消息",
        //        MsgType = MsgType.text,
        //        CreateTime = nowtime,
        //        FromUserName = msg.ToUserName,
        //        ToUserName = msg.FromUserName
        //    };

        //    return SerializationHelper.Serialize(model);
        //}

        //private string CallEventOther(Receive.xml msg)
        //{
        //    int nowtime = ConvertDateTimeInt(DateTime.Now);

        //    var model = new Send.TextMessage()
        //    {
        //        Content = "改功能暂未开发",
        //        MsgType = MsgType.text,
        //        CreateTime = nowtime,
        //        FromUserName = msg.ToUserName,
        //        ToUserName = msg.FromUserName
        //    };

        //    return SerializationHelper.Serialize(model);
        //}

        #endregion





    }



}

