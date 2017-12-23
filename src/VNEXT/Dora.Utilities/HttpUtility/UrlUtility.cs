using System;
using Microsoft.AspNetCore.Http;

namespace Dora.Utilities.HttpUtility
{
    /// <summary>
    /// URL工具类
    /// </summary>
    public class UrlUtility
    {
        /// <summary>
        /// 生成OAuth用的CallbackUrl参数（原始状态，未整体进行UrlEncode）
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="oauthCallbackUrl"></param>
        /// <returns></returns>
        public static string GenerateOAuthCallbackUrl(HttpRequest request, string oauthCallbackUrl)
        {
            var location = new Uri($"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}");
            var returnUrl = location.AbsoluteUri; //httpContext.Request.Url.ToString();
            var urlData = request;
            var scheme = urlData.Scheme;//协议
            var host = urlData.Host.Host;//主机名（不带端口）
            var port = urlData.Host.Port;//端口（因为从.NET Framework移植，因此不直接使用urlData.Host）
            string portSetting = null;//Url中的端口部分
            string schemeUpper = scheme.ToUpper();//协议（大写）

            if ((schemeUpper == "HTTP" && port == 80) ||
                (schemeUpper == "HTTPS" && port == 443))
            {
                portSetting = "";//使用默认值
            }
            else
            {
                portSetting = ":" + port;//添加端口
            }

            //授权回调字符串
            var callbackUrl = string.Format("{0}://{1}{2}{3}{4}returnUrl={5}",
                scheme,
                host,
                portSetting,
                oauthCallbackUrl,
                oauthCallbackUrl.Contains("?") ? "&" : "?",
                returnUrl.UrlEncode()
            );
            return callbackUrl;
        }
    }
}
