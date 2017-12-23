namespace Dora.Utilities.HttpUtility
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Dora.Utilities.WebProxy;

    /// <summary>
    /// HTTP 请求工具类
    /// </summary>
    public static partial class RequestUtility
    {
        #region 代理

        private static IWebProxy _webproxy = null;
        /// <summary>
        /// 设置Web代理
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void SetHttpProxy(string host, string port, string username, string password)
        {
            ICredentials cred;
            cred = new NetworkCredential(username, password);
            if (!string.IsNullOrEmpty(host))
            {
                _webproxy = new CoreWebProxy(new Uri(host + ":" + port ?? "80"), cred, true);
            }
        }

        /// <summary>
        /// 清除Web代理状态
        /// </summary>
        public static void RemoveHttpProxy()
        {
            _webproxy = null;
        }

        #endregion

        #region 私有方法


        /// <summary>
        /// 验证服务器证书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }


        /// <summary>
        /// 验证服务器证书
        /// </summary>
        /// <param name="request"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns></returns>
        private static bool CheckValidationResult(HttpRequestMessage request, X509Certificate2 certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private static StreamContent CreateFileContent(Stream stream, string fileName, string contentType = "application/octet-stream")
        {
            fileName = UrlEncode(fileName);
            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"media\"",
                FileName = "\"" + fileName + "\""
            }; // the extra quotes are key here
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            return fileContent;
        }

        /// <summary>
        /// 设置HTTP头
        /// </summary>
        /// <param name="client"></param>
        /// <param name="refererUrl"></param>
        /// <param name="useAjax">是否使用Ajax</param>
        /// <param name="timeOut"></param>
        private static void HttpClientHeader(HttpClient client, string refererUrl, bool useAjax, int timeOut)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xhtml+xml"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.9));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/webp"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*", 0.8));


            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36");
            client.DefaultRequestHeaders.Add("Timeout", timeOut.ToString());
            client.DefaultRequestHeaders.Add("KeepAlive", "true");

            if (!string.IsNullOrEmpty(refererUrl))
            {
                client.DefaultRequestHeaders.Referrer = new Uri(refererUrl);
            }

            if (useAjax)
            {
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            }
        }


        #endregion

        #region 同步方法

        /// <summary>
        /// 填充表单信息的Stream
        /// </summary>
        /// <param name="formData"></param>
        /// <param name="stream"></param>
        public static void FillFormDataStream(this Dictionary<string, string> formData, Stream stream)
        {
            string dataString = GetQueryString(formData);
            var formDataBytes = formData == null ? new byte[0] : Encoding.UTF8.GetBytes(dataString);
            stream.Write(formDataBytes, 0, formDataBytes.Length);
            stream.Seek(0, SeekOrigin.Begin);//设置指针读取位置
        }

        #endregion

        #region 异步方法

        /// <summary>
        /// 填充表单信息的Stream
        /// </summary>
        /// <param name="formData"></param>
        /// <param name="stream"></param>
        public static async Task FillFormDataStreamAsync(this Dictionary<string, string> formData, Stream stream)
        {
            string dataString = GetQueryString(formData);
            var formDataBytes = formData == null ? new byte[0] : Encoding.UTF8.GetBytes(dataString);
            await stream.WriteAsync(formDataBytes, 0, formDataBytes.Length);
            stream.Seek(0, SeekOrigin.Begin);//设置指针读取位置
        }

        #endregion

        #region 只需要使用同步的方法

        /// <summary>
        /// 组装QueryString的方法
        /// 参数之间用&amp;连接，首位没有符号，如：a=1&amp;b=2&amp;c=3
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        public static string GetQueryString(this Dictionary<string, string> formData)
        {
            if (formData == null || formData.Count == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();

            var i = 0;
            foreach (var kv in formData)
            {
                i++;
                sb.AppendFormat("{0}={1}", kv.Key, kv.Value);
                if (i < formData.Count)
                {
                    sb.Append("&");
                }
            }

            return sb.ToString();
        }


        /// <summary>
        /// 封装System.Web.HttpUtility.HtmlEncode
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string HtmlEncode(this string html)
        {
            return WebUtility.HtmlEncode(html);
        }

        /// <summary>
        /// 封装System.Web.HttpUtility.HtmlDecode
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string HtmlDecode(this string html)
        {
            return WebUtility.HtmlDecode(html);
        }

        /// <summary>
        /// 封装System.Web.HttpUtility.UrlEncode
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string UrlEncode(this string url)
        {
            return WebUtility.UrlEncode(url);//转义后字母为大写
        }

        /// <summary>
        /// 封装System.Web.HttpUtility.UrlDecode
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string UrlDecode(this string url)
        {
            return WebUtility.UrlDecode(url);
        }

        /// <summary>
        /// <para>将 URL 中的参数名称/值编码为合法的格式。</para>
        /// <para>可以解决类似这样的问题：假设参数名为 tvshow, 参数值为 Tom&Jerry，如果不编码，可能得到的网址： http://a.com/?tvshow=Tom&Jerry&year=1965 编码后则为：http://a.com/?tvshow=Tom%26Jerry&year=1965 </para>
        /// <para>实践中经常导致问题的字符有：'&', '?', '=' 等</para>
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string AsUrlData(this string data)
        {
            if (data == null)
            {
                return null;
            }
            return Uri.EscapeDataString(data);
        }


        #endregion
    }
}
