
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using System.Threading.Tasks;
using Dora.Weixin.MP.MessageHandlers;
using Dora.Weixin.MP.Entities.Request;
using Dora.Weixin.MP.Entities;
using Dora.Weixin.MP.Helpers;
using Dora.Weixin.MP.AdvancedAPIs;
using Dora.Weixin.Entities.Request;
using Dora.Weixin.Exceptions;
using Dora.Weixin;
using Dora.Helpers;
using Dora.Services.School.Interfaces;
using Dora.Weixin.MP;
using Dora.Weixin.MP.Agent;
using Senparc.Weixin.MP.Sample.CommonService;

namespace Dora.wx.CustomMessageHandler
{
    /// <summary>
    /// 自定义MessageHandler
    /// 把MessageHandler作为基类，重写对应请求的处理方法
    /// </summary>
    public partial class CustomMessageHandler : MessageHandler<CustomMessageContext>
    {
        private string appId = string.Empty;
        private string appSecret = string.Empty;

        private ITimeCardService _timeCardService;
        private IStudentService _studentService;

        /// <summary>
        /// 模板消息集合（Key：checkCode，Value：OpenId）
        /// </summary>
        public static Dictionary<string, string> TemplateMessageCollection = new Dictionary<string, string>();

        public CustomMessageHandler(Stream inputStream, PostModel postModel
            , ITimeCardService timeCardService
            , IStudentService studentService
            , int maxRecordCount = 0)
            : base(inputStream, postModel, maxRecordCount)
        {
            //这里设置仅用于测试，实际开发可以在外部更全局的地方设置，
            //比如MessageHandler<MessageContext>.GlobalWeixinContext.ExpireMinutes = 3。
            WeixinContext.ExpireMinutes = 3;
            _timeCardService = timeCardService;
            _studentService = studentService;
            
            if (!string.IsNullOrEmpty(postModel.AppId))
            {
                appId = postModel.AppId; //通过第三方开放平台发送过来的请求
            }

            //在指定条件下，不使用消息去重
            base.OmitRepeatedMessageFunc = requestMessage =>
            {
                var textRequestMessage = requestMessage as RequestMessageText;
                if (textRequestMessage != null && textRequestMessage.Content == "容错")
                {
                    return false;
                }

                return true;
            };
        }

        public CustomMessageHandler(Weixin.MP.Entities.RequestMessageBase requestMessage)
            : base(requestMessage)
        {
        }

        public override void OnExecuting()
        {
            //测试MessageContext.StorageData
            if (CurrentMessageContext.StorageData == null)
            {
                CurrentMessageContext.StorageData = 0;
            }
            base.OnExecuting();
        }

        public override void OnExecuted()
        {
            base.OnExecuted();
            CurrentMessageContext.StorageData = ((int)CurrentMessageContext.StorageData) + 1;
        }

        /// <summary>
        /// 处理文字请求
        /// </summary>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            var defaultResponseMessage = base.CreateResponseMessage<ResponseMessageText>();
            var requestHandler =requestMessage.StartHandler()
                .Keyword("OPENID", () =>
                {
                    var openId = requestMessage.FromUserName;//获取OpenId
                    var userInfo = Weixin.MP.AdvancedAPIs.UserApi.Info(appId, openId, Language.zh_CN);

                    defaultResponseMessage.Content = string.Format(
                        "您的OpenID为：{0}\r\n昵称：{1}\r\n性别：{2}\r\n地区（国家/省/市）：{3}/{4}/{5}\r\n关注时间：{6}\r\n关注状态：{7}",
                        requestMessage.FromUserName, userInfo.nickname, (Sex)userInfo.sex, userInfo.country, userInfo.province, userInfo.city, DateTimeHelper.GetDateTimeFromXml(userInfo.subscribe_time), userInfo.subscribe);
                    return defaultResponseMessage;
                })
                .Default(() =>
                {
                    var result = new StringBuilder();
                    result.AppendFormat("您刚才发送了文字信息：{0}\r\n\r\n", requestMessage.Content);

                    result.Append("可惜我不会回答，正在学习中...");

                    defaultResponseMessage.Content = result.ToString();
                    return defaultResponseMessage;
                })
                //正则表达式
                .Regex(@"^\d+#\d+$", () =>
                {
                    defaultResponseMessage.Content = string.Format("您输入了：{0}，符合正则表达式：^\\d+#\\d+$", requestMessage.Content);
                    return defaultResponseMessage;
                });

            return requestHandler.GetResponseMessage() as Weixin.MP.Entities.IResponseMessageBase;
        }

        /// <summary>
        /// 处理位置请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        //public override Weixin.MP.Entities.IResponseMessageBase OnLocationRequest(RequestMessageLocation requestMessage)
        //{
            //var locationService = new LocationService();
            //var responseMessage = locationService.GetResponseMessage(requestMessage as RequestMessageLocation);
            //return responseMessage;
        //}

        public override Weixin.MP.Entities.IResponseMessageBase OnShortVideoRequest(RequestMessageShortVideo requestMessage)
        {
            return null;
        }

        /// <summary>
        /// 处理图片请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnImageRequest(RequestMessageImage requestMessage)
        {
            return null;
        }

        /// <summary>
        /// 处理语音请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnVoiceRequest(RequestMessageVoice requestMessage)
        {
            return null;
        }
        /// <summary>
        /// 处理视频请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnVideoRequest(RequestMessageVideo requestMessage)
        {
            return null;
        }


        /// <summary>
        /// 处理链接消息请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnLinkRequest(RequestMessageLink requestMessage)
        {
            return null;
        }

        /// <summary>
        /// 处理事件请求（这个方法一般不用重写，这里仅作为示例出现。除非需要在判断具体Event类型以外对Event信息进行统一操作
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnEventRequest(IRequestMessageEventBase requestMessage)
        {
            var eventResponseMessage = base.OnEventRequest(requestMessage);//对于Event下属分类的重写方法，见：CustomerMessageHandler_Events.cs
            //TODO: 对Event信息进行统一操作
            return eventResponseMessage;
        }

        public override Weixin.MP.Entities.IResponseMessageBase DefaultResponseMessage(Weixin.MP.Entities.IRequestMessageBase requestMessage)
        {
            /* 所有没有被处理的消息会默认返回这里的结果，
            * 因此，如果想把整个微信请求委托出去（例如需要使用分布式或从其他服务器获取请求），
            * 只需要在这里统一发出委托请求，如：
            * var responseMessage = MessageAgent.RequestResponseMessage(agentUrl, agentToken, RequestDocument.ToString());
            * return responseMessage;
            */

            return null;
        }


        public override Weixin.MP.Entities.IResponseMessageBase OnUnknownTypeRequest(RequestMessageUnknownType requestMessage)
        {
            /*
             * 此方法用于应急处理SDK没有提供的消息类型，
             * 原始XML可以通过requestMessage.RequestDocument（或this.RequestDocument）获取到。
             * 如果不重写此方法，遇到未知的请求类型将会抛出异常（v14.8.3 之前的版本就是这么做的）
             */
            var msgType = MsgTypeHelper.GetRequestMsgTypeString(requestMessage.RequestDocument);
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "未知消息类型：" + msgType;


            return responseMessage;
        }
    }
}
