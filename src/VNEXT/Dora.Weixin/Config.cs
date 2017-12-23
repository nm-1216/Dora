namespace Dora.Weixin
{
    using System;

    /// <summary>
    /// 全局设置
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// 请求超时设置（以毫秒为单位），默认为10秒。(说明：此处常量专为提供给方法的参数的默认值，不是方法内所有请求的默认超时时间。)
        /// </summary>
        public const int TIME_OUT = 10000;

        private static bool _isDebug = false;

        /// <summary>
        /// 指定是否是Debug状态，如果是，系统会自动输出日志
        /// </summary>
        public static bool IsDebug
        {
            get
            {
                return _isDebug;
            }
            set
            {
                _isDebug = value;
            }
        }

        /// <summary>
        /// JavaScriptSerializer 类接受的 JSON 字符串的最大长度
        /// </summary>
        public static int MaxJsonLength = int.MaxValue;//TODO:需要考虑分布式的情况，后期需要储存在缓存中

        /// <summary>
        /// 默认缓存键的第一级命名空间，默认值：DefaultCache
        /// </summary>
        public static string DefaultCacheNamespace = "DefaultCache";

        /// <summary>
        /// 微信支付使用沙箱模式
        /// </summary>
        public static bool UseSandBoxPay { get; set; }

        /// <summary>
        /// 网站根目录绝对路径
        /// </summary>
        public static string RootDictionaryPath { get; set; }

        /// <summary>
        /// 公众号（小程序）、开放平台 API 的服务器地址（默认为：https://api.weixin.qq.com）
        /// </summary>
        private static string _apiMpHost = "https://api.weixin.qq.com";
        /// <summary>
        /// 公众号（小程序）、开放平台 API 的服务器地址（默认为：https://api.weixin.qq.com）
        /// </summary>
        public static string ApiMpHost
        {
            get { return _apiMpHost; }
            set { _apiMpHost = value; }
        }

        /// <summary>
        /// 企业微信API的服务器地址（默认为：https://qyapi.weixin.qq.com）
        /// </summary>
        private static string _apiWorkHost = "https://qyapi.weixin.qq.com";

        /// <summary>
        /// 企业微信API的服务器地址（默认为：https://qyapi.weixin.qq.com）
        /// </summary>
        public static string ApiWorkHost
        {
            get { return _apiWorkHost; }
            set { _apiWorkHost = value; }
        }

        /// <summary>
        /// 默认的AppId检查规则
        /// </summary>
        public static Func<string, PlatformType, bool> DefaultAppIdCheckFunc = (accessTokenOrAppId, platFormType) =>
        {
            if (platFormType == PlatformType.QY || platFormType == PlatformType.Work)
            {
                return accessTokenOrAppId != null && accessTokenOrAppId.Contains("@");
            }
            else
            {
                return accessTokenOrAppId != null && accessTokenOrAppId.Length <= 32;
            }
        };
    }
}
