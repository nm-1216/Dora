using System;
using System.Linq;
using Dora.Domain.Entities.School;
using Dora.Helpers.Extensions;
using Dora.Utilities.HttpUtility;
using Dora.Weixin.Exceptions;
using Dora.Weixin.MP;
using Dora.Weixin.MP.AdvancedAPIs;
using Dora.Weixin.MP.Agent;
using Dora.Weixin.MP.Entities;
using Dora.Weixin.MP.Helpers;
using Microsoft.EntityFrameworkCore;
using Senparc.Weixin.MP.Sample.CommonService.Download;

namespace Dora.wx.CustomMessageHandler
{
    /// <summary>
    /// 自定义MessageHandler
    /// </summary>
    public partial class CustomMessageHandler
    {


        #region  Ok

        

        #endregion
 

        public override Weixin.MP.Entities.IResponseMessageBase OnTextOrEventRequest(RequestMessageText requestMessage)
        {
            return null;

        }

        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnEvent_ClickRequest(RequestMessageEvent_Click requestMessage)
        {
            return null;

        }

        /// <summary>
        /// 进入事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnEvent_EnterRequest(RequestMessageEvent_Enter requestMessage)
        {
            return null;

        }

        /// <summary>
        /// 位置事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnEvent_LocationRequest(RequestMessageEvent_Location requestMessage)
        {
            return null;

        }

        /// <summary>
        /// 通过二维码扫描关注扫描事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnEvent_ScanRequest(RequestMessageEvent_Scan requestMessage)
        {
            //通过扫描关注
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            
            
            //绑定医生
            if (!string.IsNullOrEmpty(requestMessage.EventKey) && requestMessage.EventKey.StartsWith("QD,"))
            {
                string openId = requestMessage.FromUserName;

                var student= _studentService.GetAll().Include(o => o.SchoolUser).FirstOrDefault(o => o.SchoolUser.WxOpenId == openId);

                if (student == null)
                {
                    responseMessage.Content = "用户查询失败，请绑定学号";
                }
                else
                {
                    var temp = (requestMessage.EventKey.Replace("QD,", "")).Split(",");

                    var a = temp[0];
                    var b = temp[1];
                    var c = long.Parse(temp[2]);
                
                    //精确到秒
                    var d = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                    if (d > (c + 3600))
                    {
                        responseMessage.Content = "二维码已过期，有效时间一个小时";
                    }
                    else
                    {
                        var model=_timeCardService.Find(o => o.StudentId == student.StudentId && o.Batch == a);
                        if (model == null)
                        {
                            _timeCardService.Add(new TimeCard()
                            {
                                TeachingTaskId = b,
                                StudentId = student.StudentId,
                                Time = c,
                                Batch = a
                            });
                        }
                        
                        var strongResponseMessage = requestMessage.CreateResponseMessage<ResponseMessageNews>();
                        strongResponseMessage.ArticleCount = 1;
                        strongResponseMessage.Articles = new System.Collections.Generic.List<Article> { new Article() {
                            Title = "打卡成功，美好课程从此刻开始！",
                            Description = "好好学习，天天向上。",
                            PicUrl = "http://wx.nieba.cn/images/clock.jpg",
                            Url = "http://WX.NIEBA.CN/VUE/INDEX.HTML"
                        } };
                        return strongResponseMessage;
                    }
                }
            }

            responseMessage.Content =
                responseMessage.Content ?? requestMessage.EventKey;


            return responseMessage;
        }

        /// <summary>
        /// 打开网页事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnEvent_ViewRequest(RequestMessageEvent_View requestMessage)
        {
            //说明：这条消息只作为接收，下面的responseMessage到达不了客户端，类似OnEvent_UnsubscribeRequest
            return null;

        }

        /// <summary>
        /// 群发完成事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnEvent_MassSendJobFinishRequest(RequestMessageEvent_MassSendJobFinish requestMessage)
        {
            return null;

        }

        /// <summary>
        /// 订阅（关注）事件
        /// </summary>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnEvent_SubscribeRequest(RequestMessageEvent_Subscribe requestMessage)
        {
            var strongResponseMessage = requestMessage.CreateResponseMessage<ResponseMessageNews>();
            strongResponseMessage.ArticleCount = 1;
            strongResponseMessage.Articles = new System.Collections.Generic.List<Article> { new Article() {
                            Title = "关注成功，开启新的教与学体验之旅！",
                            Description = "点击使用微信一键登录。",
                            PicUrl = "http://wx.nieba.cn/images/guanzhu.jpg",
                            Url = "http://WX.NIEBA.CN/VUE/INDEX.HTML"
                        } };
            return strongResponseMessage;
        }

        /// <summary>
        /// 退订
        /// 实际上用户无法收到非订阅账号的消息，所以这里可以随便写。
        /// unsubscribe事件的意义在于及时删除网站应用中已经记录的OpenID绑定，消除冗余数据。并且关注用户流失的情况。
        /// </summary>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnEvent_UnsubscribeRequest(RequestMessageEvent_Unsubscribe requestMessage)
        {
            return null;

        }

        /// <summary>
        /// 事件之扫码推事件(scancode_push)
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnEvent_ScancodePushRequest(RequestMessageEvent_Scancode_Push requestMessage)
        {
            return null;

        }

        /// <summary>
        /// 事件之扫码推事件且弹出“消息接收中”提示框(scancode_waitmsg)
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnEvent_ScancodeWaitmsgRequest(RequestMessageEvent_Scancode_Waitmsg requestMessage)
        {
            return null;

        }

        /// <summary>
        /// 事件之弹出拍照或者相册发图（pic_photo_or_album）
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnEvent_PicPhotoOrAlbumRequest(RequestMessageEvent_Pic_Photo_Or_Album requestMessage)
        {
            return null;

        }

        /// <summary>
        /// 事件之弹出系统拍照发图(pic_sysphoto)
        /// 实际测试时发现微信并没有推送RequestMessageEvent_Pic_Sysphoto消息，只能接收到用户在微信中发送的图片消息。
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnEvent_PicSysphotoRequest(RequestMessageEvent_Pic_Sysphoto requestMessage)
        {
            return null;

        }

        /// <summary>
        /// 事件之弹出微信相册发图器(pic_weixin)
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnEvent_PicWeixinRequest(RequestMessageEvent_Pic_Weixin requestMessage)
        {
            return null;

        }

        /// <summary>
        /// 事件之弹出地理位置选择器（location_select）
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnEvent_LocationSelectRequest(RequestMessageEvent_Location_Select requestMessage)
        {
            return null;
        }

        /// <summary>
        /// 事件之发送模板消息返回结果
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override Weixin.MP.Entities.IResponseMessageBase OnEvent_TemplateSendJobFinishRequest(RequestMessageEvent_TemplateSendJobFinish requestMessage)
        {
            return null;
        }

        #region 微信认证事件推送

        public override Weixin.MP.Entities.IResponseMessageBase OnEvent_QualificationVerifySuccess(RequestMessageEvent_QualificationVerifySuccess requestMessage)
        {
            return new SuccessResponseMessage();
        }

        #endregion
        
        private ResponseMessageText xxx(string msg)
        {
            if (string.IsNullOrEmpty(msg))
            {
                return null;
            }

            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = msg;
            return responseMessage;
        }

    }
}