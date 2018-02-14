
using System;
using System.Threading.Tasks;
using Dora.Utilities.CacheUtility;
using Dora.Weixin.Containers;
using Dora.Weixin.Exceptions;
using Dora.Weixin.MP.AdvancedAPIs;
using Dora.Weixin.MP.AdvancedAPIs.OAuth;

namespace Dora.Weixin.MP.Containers
{
    /// <summary>
    /// OAuth包
    /// </summary>
    [Serializable]
    public class OAuthAccessTokenBag : BaseContainerBag, IBaseContainerBag_AppId
    {
        public string AppId
        {
            get { return _appId; }
#if NET35 || NET40
            set { this.SetContainerProperty(ref _appId, value, "AppId"); }
#else
            set { this.SetContainerProperty(ref _appId, value); }
#endif
        }
        public string AppSecret
        {
            get { return _appSecret; }
#if NET35 || NET40
            set { this.SetContainerProperty(ref _appSecret, value, "AppSecret"); }
#else
            set { this.SetContainerProperty(ref _appSecret, value); }
#endif
        }

        public OAuthAccessTokenResult OAuthAccessTokenResult
        {
            get { return _oAuthAccessTokenResult; }
#if NET35 || NET40
            set { this.SetContainerProperty(ref _oAuthAccessTokenResult, value, "OAuthAccessTokenResult"); }
#else
            set { this.SetContainerProperty(ref _oAuthAccessTokenResult, value); }
#endif
        }

        public DateTime OAuthAccessTokenExpireTime
        {
            get { return _oAuthAccessTokenExpireTime; }
#if NET35 || NET40
            set { this.SetContainerProperty(ref _oAuthAccessTokenExpireTime, value, "OAuthAccessTokenExpireTime"); }
#else
            set { this.SetContainerProperty(ref _oAuthAccessTokenExpireTime, value); }
#endif
        }

        /// <summary>
        /// 只针对这个AppId的锁
        /// </summary>
        internal object Lock = new object();

        private DateTime _oAuthAccessTokenExpireTime;
        private OAuthAccessTokenResult _oAuthAccessTokenResult;
        private string _appSecret;
        private string _appId;
    }

    /// <summary>
    /// 用户OAuth容器，用于自动管理OAuth的AccessToken，如果过期会重新获取（测试中，暂时别用）
    /// </summary>
    public class OAuthAccessTokenContainer : BaseContainer<OAuthAccessTokenBag>
    {
        const string LockResourceName = "MP.OAuthAccessTokenContainer";

        #region 同步方法


        //static Dictionary<string, JsApiTicketBag> JsApiTicketCollection =
        //   new Dictionary<string, JsApiTicketBag>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// 注册应用凭证信息，此操作只是注册，不会马上获取Ticket，并将清空之前的Ticket，
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <param name="name">标记JsApiTicket名称（如微信公众号名称），帮助管理员识别</param>
        /// 此接口不提供异步方法
        public static void Register(string appId, string appSecret, string name = null)
        {
            RegisterFunc = () =>
            {
                using (FlushCache.CreateInstance())
                {
                    var bag = new OAuthAccessTokenBag()
                    {
                        Name = name,
                        AppId = appId,
                        AppSecret = appSecret,
                        OAuthAccessTokenExpireTime = DateTime.MinValue,
                        OAuthAccessTokenResult = new OAuthAccessTokenResult()
                    };
                    Update(appId, bag);
                    return bag;
                }
            };
            RegisterFunc();
        }

        #region OAuthAccessToken

        /// <summary>
        /// 使用完整的应用凭证获取Ticket，如果不存在将自动注册
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <param name="code">code作为换取access_token的票据，每次用户授权带上的code将不一样，code只能使用一次，5分钟未被使用自动过期。</param>
        /// <param name="getNewToken"></param>
        /// <returns></returns>
        public static string TryGetOAuthAccessToken(string appId, string appSecret, string code, bool getNewToken = false)
        {
            if (!CheckRegistered(appId) || getNewToken)
            {
                Register(appId, appSecret);
            }
            return GetOAuthAccessToken(appId, code, getNewToken);
        }

        /// <summary>
        /// 获取可用Ticket
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="code">code作为换取access_token的票据，每次用户授权带上的code将不一样，code只能使用一次，5分钟未被使用自动过期。</param>
        /// <param name="getNewToken">是否强制重新获取新的Ticket</param>
        /// <returns></returns>
        public static string GetOAuthAccessToken(string appId, string code, bool getNewToken = false)
        {
            return GetOAuthAccessTokenResult(appId, code, getNewToken).access_token;
        }

        /// <summary>
        /// 获取可用Ticket
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="code">code作为换取access_token的票据，每次用户授权带上的code将不一样，code只能使用一次，5分钟未被使用自动过期。</param>
        /// <param name="getNewToken">是否强制重新获取新的Ticket</param>
        /// <returns></returns>
        public static OAuthAccessTokenResult GetOAuthAccessTokenResult(string appId, string code, bool getNewToken = false)
        {
            if (!CheckRegistered(appId))
            {
                throw new UnRegisterAppIdException(null, "此appId尚未注册，请先使用OAuthAccessTokenContainer.Register完成注册（全局执行一次即可）！");
            }

            var oAuthAccessTokenBag = TryGetItem(appId);
            using (Cache.BeginCacheLock(LockResourceName, appId))//同步锁
            {
                if (getNewToken || oAuthAccessTokenBag.OAuthAccessTokenExpireTime <= DateTime.Now)
                {
                    //已过期，重新获取
                    oAuthAccessTokenBag.OAuthAccessTokenResult = OAuthApi.GetAccessToken(oAuthAccessTokenBag.AppId, oAuthAccessTokenBag.AppSecret, code);
                    oAuthAccessTokenBag.OAuthAccessTokenExpireTime =
                        ApiUtility.GetExpireTime(oAuthAccessTokenBag.OAuthAccessTokenResult.expires_in);
                }
            }
            return oAuthAccessTokenBag.OAuthAccessTokenResult;
        }

        #endregion
        #endregion

#if !NET35 && !NET40
        #region 异步方法
        #region OAuthAccessToken

        /// <summary>
        /// 【异步方法】使用完整的应用凭证获取Ticket，如果不存在将自动注册
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <param name="code">code作为换取access_token的票据，每次用户授权带上的code将不一样，code只能使用一次，5分钟未被使用自动过期。</param>
        /// <param name="getNewToken"></param>
        /// <returns></returns>
        public static async Task<string> TryGetOAuthAccessTokenAsync(string appId, string appSecret, string code, bool getNewToken = false)
        {
            if (!CheckRegistered(appId) || getNewToken)
            {
                Register(appId, appSecret);
            }
            return await GetOAuthAccessTokenAsync(appId, code, getNewToken);
        }

        /// <summary>
        /// 【异步方法】获取可用Ticket
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="code">code作为换取access_token的票据，每次用户授权带上的code将不一样，code只能使用一次，5分钟未被使用自动过期。</param>
        /// <param name="getNewToken">是否强制重新获取新的Ticket</param>
        /// <returns></returns>
        public static async Task<string> GetOAuthAccessTokenAsync(string appId, string code, bool getNewToken = false)
        {
            var result = await GetOAuthAccessTokenResultAsync(appId, code, getNewToken);
            return result.access_token;
        }

        /// <summary>
        /// 【异步方法】获取可用Ticket
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="code">code作为换取access_token的票据，每次用户授权带上的code将不一样，code只能使用一次，5分钟未被使用自动过期。</param>
        /// <param name="getNewToken">是否强制重新获取新的Ticket</param>
        /// <returns></returns>
        public static async Task<OAuthAccessTokenResult> GetOAuthAccessTokenResultAsync(string appId, string code, bool getNewToken = false)
        {
            if (!CheckRegistered(appId))
            {
                throw new UnRegisterAppIdException(null, "此appId尚未注册，请先使用OAuthAccessTokenContainer.Register完成注册（全局执行一次即可）！");
            }

            var oAuthAccessTokenBag = TryGetItem(appId);
            using (Cache.BeginCacheLock(LockResourceName, appId))//同步锁
            {
                if (getNewToken || oAuthAccessTokenBag.OAuthAccessTokenExpireTime <= DateTime.Now)
                {
                    //已过期，重新获取
                    var oAuthAccessTokenResult = await OAuthApi.GetAccessTokenAsync(oAuthAccessTokenBag.AppId, oAuthAccessTokenBag.AppSecret, code);
                    oAuthAccessTokenBag.OAuthAccessTokenResult = oAuthAccessTokenResult;
                    //oAuthAccessTokenBag.OAuthAccessTokenResult =  OAuthApi.GetAccessToken(oAuthAccessTokenBag.AppId, oAuthAccessTokenBag.AppSecret, code);
                    oAuthAccessTokenBag.OAuthAccessTokenExpireTime =
                        ApiUtility.GetExpireTime(oAuthAccessTokenBag.OAuthAccessTokenResult.expires_in);
                }
            }
            return oAuthAccessTokenBag.OAuthAccessTokenResult;
        }

        #endregion
        #endregion
#endif
    }
}
