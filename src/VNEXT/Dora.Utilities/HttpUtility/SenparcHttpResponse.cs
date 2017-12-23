using System.Net.Http;

namespace Dora.Weixin.HttpUtility
{
    /// <summary>
    /// 统一封装HttpResonse请求，提供Http请求过程中的调试、跟踪等扩展能力
    /// </summary>
    public class DoraHttpResponse
    {
        public HttpResponseMessage Result { get; set; }

        public DoraHttpResponse(HttpResponseMessage httpWebResponse)
        {
            Result = httpWebResponse;
        }
    }
}