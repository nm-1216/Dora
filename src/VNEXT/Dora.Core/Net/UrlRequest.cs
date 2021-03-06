﻿//-----------------------------------------------------------------------
// <copyright file="UrlRequest.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2012/02/25</datetime>
// <discription>UrlRequest</discription>
//-----------------------------------------------------------------------

namespace Dora.Core.Net
{
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// URL 请求
    /// </summary>
    public class UrlRequest
    {

        /// <summary>
        /// 获取 HttpWebResponse 对象
        /// </summary>
        /// <param name="url">请求 地址</param>
        /// <param name="contentType">content type</param>
        /// <param name="method">请求 方法</param>
        /// <param name="defaultCookieContainer">默认 cookie 容器</param>
        /// <param name="encoding">请求 编码格式</param>
        /// <param name="postData">发送 数据</param>
        /// <param name="cookieContainer">cookie 容器</param>
        /// <returns>返回 HttpWebResponse 对象</returns>
        public static async Task<HttpWebResponse> Send(string url, string contentType, string method, CookieContainer defaultCookieContainer, Encoding encoding, string postData)
        {   
                  
            try
            {   
                var hwr = (HttpWebRequest)WebRequest.Create(url);
                if (defaultCookieContainer != null)
                {   
                    hwr.CookieContainer = defaultCookieContainer;
                }
                else
                {
                    hwr.CookieContainer = new CookieContainer();
                }
                                
                //hwr.KeepAlive = false;
                //hwr.ContentLength = 0;

                if (!string.IsNullOrEmpty(contentType))
                {
                    hwr.ContentType = contentType;
                }

                if (!string.IsNullOrEmpty(method))
                {
                    hwr.Method = method;
                }

                if (!string.IsNullOrEmpty(postData))
                {
                    byte[] byte1 = encoding.GetBytes(postData);
                    //hwr.ContentLength = byte1.Length;                    
                    //Stream stream = hwr.GetRequestStream();
                    var stream = await hwr.GetRequestStreamAsync();
                    await stream.WriteAsync(byte1, 0, byte1.Length);
                    stream.Dispose();
                }

                var response = await hwr.GetResponseAsync();
                //cookieContainer = hwr.CookieContainer;
                return response as HttpWebResponse;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 获取 HttpWebResponse 对象
        /// </summary>
        /// <param name="url">请求 地址</param>
        /// <returns>返回 HttpWebResponse 对象</returns>
        public static Task<HttpWebResponse> Send(string url)
        {
            return Send(url, string.Empty, "GET", Encoding.UTF8, string.Empty);
        }

        /// <summary>
        /// 获取 HttpWebResponse 对象
        /// </summary>
        /// <param name="url">请求 地址</param>
        /// <param name="method">请求 方法</param>
        /// <returns>返回 HttpWebResponse 对象</returns>
        public static Task<HttpWebResponse> Send(string url, string method)
        {
            string contentType = string.Empty;
            if (method == "POST")
            {
                contentType = "application/x-www-form-urlencoded";
            }

            return Send(url, contentType, method, Encoding.UTF8, string.Empty);
        }

        /// <summary>
        /// 获取 HttpWebResponse 对象
        /// </summary>
        /// <param name="url">请求 地址</param>
        /// <param name="contentType">content type</param>
        /// <param name="method">请求 方法</param>
        /// <returns>返回 HttpWebResponse 对象</returns>
        public static Task<HttpWebResponse> Send(string url, string contentType, string method)
        {
            return Send(url, contentType, method, Encoding.UTF8, string.Empty);
        }

        /// <summary>
        /// 获取 HttpWebResponse 对象
        /// </summary>
        /// <param name="url">请求 地址</param>
        /// <param name="contentType">content type</param>
        /// <param name="method">请求 方法</param>
        /// <param name="encoding">请求 编码格式</param>
        /// <param name="postData">发送 数据</param>
        /// <returns>返回 HttpWebResponse 对象</returns>
        public static Task<HttpWebResponse> Send(string url, string contentType, string method, Encoding encoding, string postData)
        {
            return Send(url, contentType, method, null, encoding, postData);
        }


        /// <summary>
        /// 获取 字符串
        /// </summary>
        /// <param name="url">请求 地址</param>
        /// <returns>返回 字符串对象</returns>
        public static string GetText(string url)
        {
            string fileBody = string.Empty;

            using (var stream = GetStream(url))
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    fileBody = reader.ReadToEnd();
                }   
            }

            return fileBody;
        }

        public static string GetText(HttpWebResponse response)
        {
            string fileBody = string.Empty;

            using (var stream = GetStream(response))
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    fileBody = reader.ReadToEnd();
                }
            }

            return fileBody;
        }


        /// <summary>
        /// 获取 字符流
        /// </summary>
        /// <param name="url">请求 地址</param>
        /// <returns>返回 字符流对象</returns>
        public static Stream GetStream(string url)
        {
            var response = Send(url);
            Stream stream = null;
            if (response != null)
            {
                stream = response.Result.GetResponseStream();
            }

            return stream;
        }

        public static Stream GetStream(HttpWebResponse response)
        {            
            Stream stream = null;
            if (response != null)
            {
                stream = response.GetResponseStream();
            }

            return stream;
        }


        /// <summary>
        /// 保存 字符串 到文本
        /// </summary>
        /// <param name="file">字符串 对象</param>
        /// <param name="fileName">文本 路径</param>
        public static void Save(string file, string fileName)
        {
            using (var fs = File.Create(fileName))
            {
                byte[] buffer;
                buffer = System.Text.Encoding.GetEncoding("GB2312").GetBytes(file);
                fs.WriteAsync(buffer, 0, buffer.Length);
            }  
        }

        /// <summary>
        /// 保存 文件
        /// </summary>
        /// <param name="file">字符 流对象</param>
        /// <param name="fileName">文件 地址</param>
        public static void Save(Stream file, string fileName)
        {
            using (var fs = File.Create(fileName))
            {
                byte[] buffer = new byte[1024];

                int l;
                do
                {
                    l = file.Read(buffer, 0, buffer.Length);
                    if (l > 0)
                    {
                        fs.WriteAsync(buffer, 0, l);
                    }
                }
                while (l > 0);
            }
        }
    }
}