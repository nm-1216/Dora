#region Apache License Version 2.0
/*----------------------------------------------------------------

Copyright 2017 Jeffrey Su & Suzhou Senparc Network Technology Co.,Ltd.

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
except in compliance with the License. You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the
License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
either express or implied. See the License for the specific language governing permissions
and limitations under the License.

Detail: https://github.com/JeffreySu/WeiXinMPSDK/blob/master/license.md

----------------------------------------------------------------*/
#endregion Apache License Version 2.0

/*----------------------------------------------------------------
    Copyright (C) 2017 Senparc

    文件名：RequestUtility.Post.cs
    文件功能描述：获取请求结果（Post）


    创建标识：Senparc - 20171006

    修改描述：移植Post方法过来

----------------------------------------------------------------*/

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
using Dora.Weixin.HttpUtility;
using Dora.Helpers;

namespace Dora.Utilities.HttpUtility
{
    /// <summary>
    /// HTTP 请求工具类
    /// </summary>
    public static partial class RequestUtility
    {
        #region 静态公共方法


        /// <summary>
        /// 给.NET Core使用的HttpPost请求公共设置方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="hc"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="postStream"></param>
        /// <param name="fileDictionary"></param>
        /// <param name="refererUrl"></param>
        /// <param name="encoding"></param>
        /// <param name="cer"></param>
        /// <param name="useAjax"></param>
        /// <param name="timeOut"></param>
        /// <param name="checkValidationResult"></param>
        /// <returns></returns>
        public static HttpClient HttpPost_Common_NetCore(string url, out HttpContent hc, CookieContainer cookieContainer = null,
            Stream postStream = null, Dictionary<string, string> fileDictionary = null, string refererUrl = null,
            Encoding encoding = null, X509Certificate2 cer = null, bool useAjax = false, int timeOut = Config.TIME_OUT,
            bool checkValidationResult = false)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookieContainer;

            if (checkValidationResult)
            {
                handler.ServerCertificateCustomValidationCallback = new Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool>(CheckValidationResult);
            }

            if (cer != null)
            {
                handler.ClientCertificates.Add(cer);
            }

            HttpClient client = new HttpClient(handler);
            HttpClientHeader(client, refererUrl, useAjax, timeOut);


            #region 处理Form表单文件上传

            var formUploadFile = fileDictionary != null && fileDictionary.Count > 0;//是否用Form上传文件
            if (formUploadFile)
            {

                //通过表单上传文件
                string boundary = "----" + DateTime.Now.Ticks.ToString("x");
                hc = new MultipartFormDataContent(boundary);

                foreach (var file in fileDictionary)
                {
                    try
                    {
                        var fileName = file.Value;
                        //准备文件流
                        using (var fileStream = FileHelper.GetFileStream(fileName))
                        {
                            if (fileStream != null)
                            {
                                //存在文件
                                //hc.Add(new StreamContent(fileStream), file.Key, Path.GetFileName(fileName)); //报流已关闭的异常
                                fileStream.Dispose();
                                (hc as MultipartFormDataContent).Add(CreateFileContent(File.Open(fileName, FileMode.Open), Path.GetFileName(fileName)), file.Key, Path.GetFileName(fileName));
                            }
                            else
                            {
                                //不存在文件或只是注释
                                (hc as MultipartFormDataContent).Add(new StringContent(string.Empty), file.Key, file.Value);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                hc.Headers.ContentType = MediaTypeHeaderValue.Parse(string.Format("multipart/form-data; boundary={0}", boundary));
            }
            else
            {
                hc = new StreamContent(postStream);

                //使用Url格式Form表单Post提交的时候才使用application/x-www-form-urlencoded
                //hc.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                hc.Headers.ContentType = new MediaTypeHeaderValue("text/xml");
            }

            //HttpContentHeader(hc, timeOut);
            #endregion

            if (!string.IsNullOrEmpty(refererUrl))
            {
                client.DefaultRequestHeaders.Referrer = new Uri(refererUrl);
            }

            return client;
        }

        #endregion

        #region 同步方法

        /// <summary>
        /// 使用Post方法获取字符串结果，常规提交
        /// </summary>
        /// <returns></returns>
        public static string HttpPost(string url, CookieContainer cookieContainer = null, Dictionary<string, string> formData = null, Encoding encoding = null, X509Certificate2 cer = null, bool useAjax = false, int timeOut = Config.TIME_OUT)
        {
            MemoryStream ms = new MemoryStream();
            formData.FillFormDataStream(ms);//填充formData
            return HttpPost(url, cookieContainer, ms, null, null, encoding, cer, useAjax, timeOut);
        }

        /// <summary>
        /// 使用Post方法获取字符串结果
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="postStream"></param>
        /// <param name="fileDictionary">需要上传的文件，Key：对应要上传的Name，Value：本地文件名</param>
        /// <param name="encoding"></param>
        /// <param name="cer">证书，如果不需要则保留null</param>
        /// <param name="useAjax"></param>
        /// <param name="timeOut"></param>
        /// <param name="checkValidationResult">验证服务器证书回调自动验证</param>
        /// <param name="refererUrl"></param>
        /// <returns></returns>
        public static string HttpPost(string url, CookieContainer cookieContainer = null, Stream postStream = null, Dictionary<string, string> fileDictionary = null, string refererUrl = null, Encoding encoding = null, X509Certificate2 cer = null, bool useAjax = false, int timeOut = Config.TIME_OUT, bool checkValidationResult = false)
        {
            if (cookieContainer == null)
            {
                cookieContainer = new CookieContainer();
            }

            var senparcResponse = HttpResponsePost(url, cookieContainer, postStream, fileDictionary, refererUrl, encoding, cer, useAjax, timeOut, checkValidationResult);
            var response = senparcResponse.Result;

            if (response.Content.Headers.ContentType.CharSet != null &&
                response.Content.Headers.ContentType.CharSet.ToLower().Contains("utf8"))
            {
                response.Content.Headers.ContentType.CharSet = "utf-8";
            }

            var retString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return retString;

            //t1.Wait();
            //return t1.Result;
        }


        /// <summary>
        /// 使用Post方法获取HttpWebResponse或HttpResponseMessage对象，本方法独立使用时通常用于测试）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="postStream"></param>
        /// <param name="fileDictionary">需要上传的文件，Key：对应要上传的Name，Value：本地文件名</param>
        /// <param name="encoding"></param>
        /// <param name="cer">证书，如果不需要则保留null</param>
        /// <param name="useAjax"></param>
        /// <param name="timeOut"></param>
        /// <param name="checkValidationResult">验证服务器证书回调自动验证</param>
        /// <param name="refererUrl"></param>
        /// <returns></returns>

        public static DoraHttpResponse HttpResponsePost(string url, CookieContainer cookieContainer = null, Stream postStream = null,
            Dictionary<string, string> fileDictionary = null, string refererUrl = null, Encoding encoding = null,
            X509Certificate2 cer = null, bool useAjax = false, int timeOut = Config.TIME_OUT,
            bool checkValidationResult = false)
        {
            if (cookieContainer == null)
            {
                cookieContainer = new CookieContainer();
            }

            HttpContent hc;
            var client = HttpPost_Common_NetCore(url, out hc, cookieContainer, postStream, fileDictionary, refererUrl, encoding, cer, useAjax, timeOut, checkValidationResult);

            var response = client.PostAsync(url, hc).GetAwaiter().GetResult();
            return new DoraHttpResponse(response);


        }

        #endregion

        #region 异步方法

        /// <summary>
        /// 使用Post方法获取字符串结果，常规提交
        /// </summary>
        /// <returns></returns>
        public static async Task<string> HttpPostAsync(string url, CookieContainer cookieContainer = null, Dictionary<string, string> formData = null, Encoding encoding = null, X509Certificate2 cer = null, bool useAjax = false, int timeOut = Config.TIME_OUT)
        {
            MemoryStream ms = new MemoryStream();
            await formData.FillFormDataStreamAsync(ms);//填充formData
            return await HttpPostAsync(url, cookieContainer, ms, null, null, encoding, cer, useAjax, timeOut);

        }


        /// <summary>
        /// 使用Post方法获取字符串结果
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="postStream"></param>
        /// <param name="fileDictionary">需要上传的文件，Key：对应要上传的Name，Value：本地文件名</param>
        /// <param name="cer"></param>
        /// <param name="useAjax"></param>
        /// <param name="timeOut"></param>
        /// <param name="checkValidationResult">验证服务器证书回调自动验证</param>
        /// <param name="refererUrl"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static async Task<string> HttpPostAsync(string url, CookieContainer cookieContainer = null, Stream postStream = null, Dictionary<string, string> fileDictionary = null, string refererUrl = null, Encoding encoding = null, X509Certificate2 cer = null,
            bool useAjax = false, int timeOut = Config.TIME_OUT, bool checkValidationResult = false)
        {
            if (cookieContainer == null)
            {
                cookieContainer = new CookieContainer();
            }

            HttpContent hc;
            var client = HttpPost_Common_NetCore(url, out hc, cookieContainer, postStream, fileDictionary, refererUrl, encoding, cer, useAjax, timeOut, checkValidationResult);

            var r = await client.PostAsync(url, hc);

            if (r.Content.Headers.ContentType.CharSet != null &&
                r.Content.Headers.ContentType.CharSet.ToLower().Contains("utf8"))
            {
                r.Content.Headers.ContentType.CharSet = "utf-8";
            }

            return await r.Content.ReadAsStringAsync();
        }


        #endregion

    }
}
