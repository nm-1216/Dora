﻿

using System.Threading.Tasks;
using Dora.Utilities.HttpUtility;
using Dora.Weixin.Entities;

namespace Dora.Weixin.MP.AdvancedAPIs
{
    /// <summary>
    /// 微信支付维权接口，官方API：https://mp.weixin.qq.com/htmledition/res/bussiness-course2/wxm-payment-kf-api.pdf
    /// </summary>
    public static class TenPayRights
    {
        #region 同步方法
        
        
        /// <summary>
        /// 标记客户的投诉处理状态
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId">支付该笔订单的用户 ID</param>
        /// <param name="feedBackId">投诉单号</param>
        /// <returns></returns>
        public static WxJsonResult UpDateFeedBack(string accessToken, string openId, string feedBackId)
        {
            var urlFormat = Config.ApiMpHost + "/payfeedback/update?access_token={0}&openid={1}&feedbackid={2}";
            var url = string.Format(urlFormat, accessToken.AsUrlData(), openId.AsUrlData(), feedBackId.AsUrlData());

            return Get.GetJson<WxJsonResult>(url);
        }
        #endregion

        #region 异步方法
         
        /// <summary>
        /// 【异步方法】标记客户的投诉处理状态
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId">支付该笔订单的用户 ID</param>
        /// <param name="feedBackId">投诉单号</param>
        /// <returns></returns>
        public static async Task<WxJsonResult> UpDateFeedBackAsync(string accessToken, string openId, string feedBackId)
        {
            var urlFormat = Config.ApiMpHost + "/payfeedback/update?access_token={0}&openid={1}&feedbackid={2}";
            var url = string.Format(urlFormat, accessToken.AsUrlData(), openId.AsUrlData(), feedBackId.AsUrlData());

            return await Get.GetJsonAsync<WxJsonResult>(url);
        }
        #endregion
    }
}
