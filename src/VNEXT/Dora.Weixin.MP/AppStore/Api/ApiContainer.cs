﻿
namespace Dora.Weixin.MP.AppStore.Api
{
    /// <summary>
    /// API操作容器（每次构造都会获取当前缓存中最新的Passport）
    /// </summary>
    public class ApiContainer
    {
        public Passport Passport { get; set; }

        public MemberApi MemberApi { get; set; }

        public ApiContainer(string appKey, string appSecret, string url = AppStoreManager.DEFAULT_URL)
        {
            var passportBag = AppStoreManager.GetPassportBag(appKey);
            if (passportBag == null || passportBag.Passport == null)
            {
                AppStoreManager.ApplyPassport(appKey, appSecret, url);
            }

            Passport = AppStoreManager.GetPassportBag(appKey).Passport;//执行SdkManager.ApplyPassport后，PassportCollection[appKey]必定存在

            MemberApi = new MemberApi(Passport);
        }
    }
}
