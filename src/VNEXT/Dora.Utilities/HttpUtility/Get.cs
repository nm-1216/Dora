namespace Dora.Utilities.HttpUtility
{
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Text;

    /// <summary>
    /// Get 请求处理
    /// </summary>
    public static class Get
    {
        #region 同步方法

        /// <summary>
        /// GET方式请求URL，并返回T类型
        /// </summary>
        /// <typeparam name="T">接收JSON的数据类型</typeparam>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <param name="maxJsonLength">允许最大JSON长度</param>
        /// <returns></returns>
        public static T GetJson<T>(string url, Encoding encoding = null, int? maxJsonLength = null)
        {
            string returnText = RequestUtility.HttpGet(url, encoding);            

            T result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(returnText);

            return result;
        }

        /// <summary>
        /// 从Url下载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="stream"></param>
        public static void Download(string url, Stream stream)
        {

            HttpClient httpClient = new HttpClient();
            var t = httpClient.GetByteArrayAsync(url);
            t.Wait();
            var data = t.Result;
            stream.Write(data, 0, data.Length);
        }

        //#if !NET35 && !NET40
        /// <summary>
        /// 从Url下载，并保存到指定目录
        /// </summary>
        /// <param name="url">需要下载文件的Url</param>
        /// <param name="filePathName"></param>
        /// <returns></returns>
        public static string Download(string url, string filePathName)
        {
            var dir = Path.GetDirectoryName(filePathName) ?? "/";
            Directory.CreateDirectory(dir);



            System.Net.Http.HttpClient httpClient = new HttpClient();
            using (var responseMessage = httpClient.GetAsync(url).Result)
            {
                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    var fullName = filePathName;
                    using (var fs = File.Open(fullName, FileMode.Create))
                    {
                        using (var responseStream = responseMessage.Content.ReadAsStreamAsync().Result)
                        {
                            responseStream.CopyTo(fs);
                            return fullName;
                        }
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        //#endif
        #endregion

        #region 异步方法

        /// <summary>
        /// 【异步方法】异步GetJson
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <param name="maxJsonLength">允许最大JSON长度</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ErrorJsonResultException"></exception>
        public static async Task<T> GetJsonAsync<T>(string url, Encoding encoding = null, int? maxJsonLength = null)
        {
            string returnText = await RequestUtility.HttpGetAsync(url, encoding);
            
            T result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(returnText);

            return result;
        }

        /// <summary>
        /// 【异步方法】异步从Url下载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task DownloadAsync(string url, Stream stream)
        {
            HttpClient httpClient = new HttpClient();
            var data = await httpClient.GetByteArrayAsync(url);
            await stream.WriteAsync(data, 0, data.Length);
        }

        /// <summary>
        /// 【异步方法】从Url下载，并保存到指定目录
        /// </summary>
        /// <param name="url">需要下载文件的Url</param>
        /// <param name="filePathName"></param>
        /// <returns></returns>
        public static async Task<string> DownloadAsync(string url, string filePathName)
        {
            var dir = Path.GetDirectoryName(filePathName) ?? "/";
            Directory.CreateDirectory(dir);

            System.Net.Http.HttpClient httpClient = new HttpClient();
            using (var responseMessage = await httpClient.GetAsync(url))
            {
                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    var fullName = filePathName;
                    using (var fs = File.Open(fullName, FileMode.Create))
                    {
                        using (var responseStream = await responseMessage.Content.ReadAsStreamAsync())
                        {
                            await responseStream.CopyToAsync(fs);
                            return fullName;
                        }
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

    }
}
