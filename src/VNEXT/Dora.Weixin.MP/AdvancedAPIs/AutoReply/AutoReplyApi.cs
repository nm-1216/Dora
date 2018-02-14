

using System.Threading.Tasks;
using Dora.Weixin.MP.AdvancedAPIs.AutoReply;
using Dora.Weixin.MP.CommonAPIs;

namespace Dora.Weixin.MP.AdvancedAPIs
{
    /// <summary>
    /// 获取自动回复规则
    /// </summary>
    public static class AutoReplyApi
    {
        #region 同步方法

        /// <summary>
        /// 获取自动回复规则
        /// </summary>
        /// <param name="accessTokenOrAppId">调用接口凭证</param>
        /// <returns></returns>
        public static GetCurrentAutoreplyInfoResult GetCurrentAutoreplyInfo(string accessTokenOrAppId)
        {
            return ApiHandlerWapper.TryCommonApi(accessToken =>
            {
                string urlFormat = Config.ApiMpHost + "/cgi-bin/get_current_autoreply_info?access_token={0}";

                return CommonJsonSend.Send<GetCurrentAutoreplyInfoResult>(accessToken, urlFormat, null, CommonJsonSendType.GET);

            }, accessTokenOrAppId);
        }
        #endregion

#if !NET35 && !NET40
        #region 异步方法

        /// <summary>
        /// 【异步方法】获取自动回复规则
        /// </summary>
        /// <param name="accessTokenOrAppId">调用接口凭证</param>
        /// <returns></returns>
        public static async Task<GetCurrentAutoreplyInfoResult> GetCurrentAutoreplyInfoAsync(string accessTokenOrAppId)
        {
            return await ApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                string urlFormat = Config.ApiMpHost + "/cgi-bin/get_current_autoreply_info?access_token={0}";

                return await Dora.Weixin.CommonAPIs.CommonJsonSend.SendAsync<GetCurrentAutoreplyInfoResult>(accessToken, urlFormat, null, CommonJsonSendType.GET);

            }, accessTokenOrAppId);
        }
        #endregion
#endif
    }
}