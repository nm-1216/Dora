
using System;
using System.Threading.Tasks;
using Dora.Weixin.MP.Entities;
using Dora.Weixin.MP.CommonAPIs;
using Dora.Weixin.Exceptions;
using Dora.Weixin.Containers;
using Dora.Utilities.CacheUtility;

namespace Dora.Weixin.MP.Containers
{
    /// <summary>
    /// JsApiTicket包
    /// </summary>
    [Serializable]
    public class JsApiTicketBag : BaseContainerBag, IBaseContainerBag_AppId
    {
        public string AppId
        {
            get { return _appId; }
            set { this.SetContainerProperty(ref _appId, value); }
        }
        public string AppSecret
        {
            get { return _appSecret; }
            set { this.SetContainerProperty(ref _appSecret, value); }
        }

        public JsApiTicketResult JsApiTicketResult
        {
            get { return _jsApiTicketResult; }
            set { this.SetContainerProperty(ref _jsApiTicketResult, value); }
        }

        public DateTime JsApiTicketExpireTime
        {
            get { return _jsApiTicketExpireTime; }
            set { this.SetContainerProperty(ref _jsApiTicketExpireTime, value); }
        }

        /// <summary>
        /// 只针对这个AppId的锁
        /// </summary>
        internal object Lock = new object();

        private DateTime _jsApiTicketExpireTime;
        private JsApiTicketResult _jsApiTicketResult;
        private string _appSecret;
        private string _appId;
    }

    /// <summary>
    /// 通用接口JsApiTicket容器，用于自动管理JsApiTicket，如果过期会重新获取
    /// </summary>
    public class JsApiTicketContainer : BaseContainer<JsApiTicketBag>
    {
        const string LockResourceName = "MP.JsApiTicketContainer";

        #region 同步方法


        //static Dictionary<string, JsApiTicketBag> JsApiTicketCollection =
        //   new Dictionary<string, JsApiTicketBag>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// 注册应用凭证信息，此操作只是注册，不会马上获取Ticket，并将清空之前的Ticket，
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <param name="name">标记JsApiTicket名称（如微信公众号名称），帮助管理员识别</param>
        /*此接口不提供异步方法*/
        public static void Register(string appId, string appSecret, string name = null)
        {
            //记录注册信息，RegisterFunc委托内的过程会在缓存丢失之后自动重试
            RegisterFunc = () =>
            {
                using (FlushCache.CreateInstance())
                {
                    var bag = new JsApiTicketBag()
                    {
                        Name = name,
                        AppId = appId,
                        AppSecret = appSecret,
                        JsApiTicketExpireTime = DateTime.MinValue,
                        JsApiTicketResult = new JsApiTicketResult()
                    };
                    Update(appId, bag);
                    return bag;
                }
            };
            RegisterFunc();

        }


        #region JsApiTicket

        /// <summary>
        /// 使用完整的应用凭证获取Ticket，如果不存在将自动注册
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <param name="getNewTicket"></param>
        /// <returns></returns>
        public static string TryGetJsApiTicket(string appId, string appSecret, bool getNewTicket = false)
        {
            if (!CheckRegistered(appId) || getNewTicket)
            {
                Register(appId, appSecret);
            }
            return GetJsApiTicket(appId);
        }

        /// <summary>
        /// 获取可用Ticket
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="getNewTicket">是否强制重新获取新的Ticket</param>
        /// <returns></returns>
        public static string GetJsApiTicket(string appId, bool getNewTicket = false)
        {
            return GetJsApiTicketResult(appId, getNewTicket).ticket;
        }

        /// <summary>
        /// 获取可用Ticket
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="getNewTicket">是否强制重新获取新的Ticket</param>
        /// <returns></returns>
        public static JsApiTicketResult GetJsApiTicketResult(string appId, bool getNewTicket = false)
        {
            if (!CheckRegistered(appId))
            {
                throw new UnRegisterAppIdException(null, "此appId尚未注册，请先使用JsApiTicketContainer.Register完成注册（全局执行一次即可）！");
            }

            var jsApiTicketBag = TryGetItem(appId);
            using (Cache.BeginCacheLock(LockResourceName, appId))//同步锁
            {
                if (getNewTicket || jsApiTicketBag.JsApiTicketExpireTime <= DateTime.Now)
                {
                    //已过期，重新获取
                    jsApiTicketBag.JsApiTicketResult = CommonApi.GetTicket(jsApiTicketBag.AppId, jsApiTicketBag.AppSecret);
                    jsApiTicketBag.JsApiTicketExpireTime = ApiUtility.GetExpireTime(jsApiTicketBag.JsApiTicketResult.expires_in);
                }
            }
            return jsApiTicketBag.JsApiTicketResult;
        }

        #endregion

        #endregion

        #region 异步方法
        #region JsApiTicket

        /// <summary>
        /// 【异步方法】使用完整的应用凭证获取Ticket，如果不存在将自动注册
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <param name="getNewTicket"></param>
        /// <returns></returns>
        public static async Task<string> TryGetJsApiTicketAsync(string appId, string appSecret, bool getNewTicket = false)
        {
            if (!CheckRegistered(appId) || getNewTicket)
            {
                Register(appId, appSecret);
            }
            return await GetJsApiTicketAsync(appId, getNewTicket);
        }

        /// <summary>
        ///【异步方法】 获取可用Ticket
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="getNewTicket">是否强制重新获取新的Ticket</param>
        /// <returns></returns>
        public static async Task<string> GetJsApiTicketAsync(string appId, bool getNewTicket = false)
        {
            var result = await GetJsApiTicketResultAsync(appId, getNewTicket);
            return result.ticket;
        }

        /// <summary>
        /// 【异步方法】获取可用Ticket
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="getNewTicket">是否强制重新获取新的Ticket</param>
        /// <returns></returns>
        public static async Task<JsApiTicketResult> GetJsApiTicketResultAsync(string appId, bool getNewTicket = false)
        {
            if (!CheckRegistered(appId))
            {
                throw new UnRegisterAppIdException(null, "此appId尚未注册，请先使用JsApiTicketContainer.Register完成注册（全局执行一次即可）！");
            }

            var jsApiTicketBag = TryGetItem(appId);
            using (Cache.BeginCacheLock(LockResourceName, appId))//同步锁
            {
                if (getNewTicket || jsApiTicketBag.JsApiTicketExpireTime <= DateTime.Now)
                {
                    //已过期，重新获取
                    var jsApiTicketResult = await CommonApi.GetTicketAsync(jsApiTicketBag.AppId, jsApiTicketBag.AppSecret);
                    //jsApiTicketBag.JsApiTicketResult = CommonApi.GetTicket(jsApiTicketBag.AppId, jsApiTicketBag.AppSecret);
                    jsApiTicketBag.JsApiTicketResult = jsApiTicketResult;
                    jsApiTicketBag.JsApiTicketExpireTime = DateTime.Now.AddSeconds(jsApiTicketBag.JsApiTicketResult.expires_in);
                }
            }
            return jsApiTicketBag.JsApiTicketResult;
        }

        #endregion
        #endregion
    }
}
