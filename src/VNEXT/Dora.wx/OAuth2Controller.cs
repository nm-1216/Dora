using Dora.Domain.Entities.School;
using Microsoft.AspNetCore.Identity;

namespace Dora.wx
{
    using Dora.Utilities.HttpUtility;
    using Dora.Weixin;
    using Dora.Weixin.Exceptions;
    using Dora.Weixin.MP;
    using Dora.Weixin.MP.AdvancedAPIs;
    using Dora.Weixin.MP.AdvancedAPIs.OAuth;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using System;
    using System.Linq;

    [AllowAnonymous]
    public class OAuth2Controller : Controller
    {
        private readonly WxConfig _wxConfig;
        //private readonly IWxUserService _wxUserService;
        
        protected readonly UserManager<SchoolUser> _userManager;

        private const string KEY_STATE = "state";
        private const string KEY_STATE_PREFIX = "wx-auth-";
        public OAuth2Controller(IOptions<WxConfig> wxConfig,UserManager<SchoolUser> userManager)
        {
            this._wxConfig = wxConfig.Value;
            //this._wxUserService = wxUserService;
            _userManager = userManager;
        }

        public ActionResult Index(string returnUrl)
        {
            var state = KEY_STATE_PREFIX + DateTime.Now.Millisecond;
            HttpContext.Session.SetString(KEY_STATE, state);

            var src = OAuthApi.GetAuthorizeUrl(_wxConfig.AppID, $"{_wxConfig.RedirectUri}BaseCallback?returnUrl=" + returnUrl.UrlEncode(), state, OAuthScope.snsapi_base);

            return Redirect(src);
        }

        public ActionResult BaseCallback(string code, string state, string returnUrl)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Content("您拒绝了授权！");
            }

            if (state != HttpContext.Session.GetString(KEY_STATE))
            {
                return Content("验证失败！请从正规途径进入！");
            }

            var result = OAuthApi.GetAccessToken(_wxConfig.AppID, _wxConfig.Appsecret, code);
            if (result.errcode != ReturnCode.请求成功)
            {
                return Content("错误：" + result.errmsg);
            }

            HttpContext.Session.Set<DateTime>("OAuthAccessTokenStartTime", DateTime.Now);
            HttpContext.Session.Set<OAuthAccessTokenResult>("OAuthAccessToken", result);

            //_wxUserService.GetAll().Include(b => b.WxIds).FirstOrDefault(b => b.WxIds.Select(b => b.WxOpenId) == result.openid);
            //var model=_wxUserService.GetAll().Include(b => b.WxIds).FirstOrDefault(b => b.WxIds.Contains(b.WxIds.FirstOrDefault(c=>c.WxOpenId==result.openid)));

            var model = _userManager.Users.FirstOrDefault(b => b.WxOpenId == result.openid);
            if (model == null)
            {
                return Redirect($"{returnUrl}/{result.openid}/{0}");
            }
            else
            {
                return Redirect($"{returnUrl}/{result.openid}/{model.Id}");
            }
            //OAuthUserInfo userInfo = null;
            //try
            //{
            //    userInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);

            //    if (!string.IsNullOrEmpty(returnUrl))
            //    {
            //        return Redirect($"{returnUrl}/{result.openid}/{1}");
            //    }
            //    else
            //    {
            //        return Content("");
            //    }
            //}
            //catch (ErrorJsonResultException ex)
            //{
            //    throw ex;
            //}
        }
    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
                                  JsonConvert.DeserializeObject<T>(value);
        }
    }
}