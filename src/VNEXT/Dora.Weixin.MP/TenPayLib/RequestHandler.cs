
using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using Dora.Helpers.StringHelper;
using Dora.Weixin.MP.Helpers;

using Microsoft.AspNetCore.Http;

namespace Dora.Weixin.MP.TenPayLib
{
    /**
    'ǩ��������
     ============================================================================/// <summary>
    'api˵����
    'Init();
    '��ʼ��������Ĭ�ϸ�һЩ������ֵ��
    'SetKey(key_)'�����̻���Կ
    'CreateMd5Sign(signParams);�ֵ�����Md5ǩ��
    'GenPackage(packageParams);��ȡpackage��
    'CreateSHA1Sign(signParams);����ǩ��SHA1
    'ParseXML();���xml
    'GetDebugInfo(),��ȡdebug��Ϣ
     * 
     * ============================================================================
     */
    public class RequestHandler
    {

        public RequestHandler(HttpContext httpContext)
        {
            Parameters = new Hashtable();

            this.HttpContext = httpContext;
        }
        /// <summary>
        /// ��Կ
        /// </summary>
        private string Key;

        protected HttpContext HttpContext;

        /// <summary>
        /// ����Ĳ���
        /// </summary>
        protected Hashtable Parameters;

        /// <summary>
        /// debug��Ϣ
        /// </summary>
        private string DebugInfo;

        /// <summary>
        /// ��ʼ������
        /// </summary>
        public virtual void Init()
        {
        }
        /// <summary>
        /// ��ȡdebug��Ϣ
        /// </summary>
        /// <returns></returns>
        public String GetDebugInfo()
        {
            return DebugInfo;
        }
        /// <summary>
        /// ��ȡ��Կ
        /// </summary>
        /// <returns></returns>
        public string GetKey()
        {
            return Key;
        }
        /// <summary>
        /// ������Կ
        /// </summary>
        /// <param name="key"></param>
        public void SetKey(string key)
        {
            this.Key = key;
        }

        /// <summary>
        /// ���ò���ֵ
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="parameterValue"></param>
        public void SetParameter(string parameter, string parameterValue)
        {
            if (parameter != null && parameter != "")
            {
                if (Parameters.Contains(parameter))
                {
                    Parameters.Remove(parameter);
                }

                Parameters.Add(parameter, parameterValue);
            }
        }


        /// <summary>
        /// ��ȡpackage��������ǩ����
        /// </summary>
        /// <returns></returns>
        public string GetRequestURL()
        {
            this.CreateSign();
            StringBuilder sb = new StringBuilder();
            ArrayList akeys = new ArrayList(Parameters.Keys);
            akeys.Sort(ASCIISort.Create());
            foreach (string k in akeys)
            {
                string v = (string)Parameters[k];
                if (null != v && "key".CompareTo(k) != 0)
                {
                    sb.Append(k + "=" + TenPayUtil.UrlEncode(v, GetCharset()) + "&");
                }
            }

            //ȥ�����һ��&
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }


            return sb.ToString();

        }

        /// <summary>
        /// ����md5ժҪ,������:����������a-z����,������ֵ�Ĳ������μ�ǩ��
        /// </summary>
        protected virtual void CreateSign()
        {
            StringBuilder sb = new StringBuilder();

            ArrayList akeys = new ArrayList(Parameters.Keys);
            akeys.Sort(ASCIISort.Create());

            foreach (string k in akeys)
            {
                string v = (string)Parameters[k];
                if (null != v && "".CompareTo(v) != 0
                    && "sign".CompareTo(k) != 0 && "key".CompareTo(k) != 0)
                {
                    sb.Append(k + "=" + v + "&");
                }
            }

            sb.Append("key=" + this.GetKey());
            string sign = MD5UtilHelper.GetMD5(sb.ToString(), GetCharset()).ToUpper();

            this.SetParameter("sign", sign);

            //debug��Ϣ
            this.SetDebugInfo(sb.ToString() + " => sign:" + sign);
        }


        /// <summary>
        /// ����packageǩ��
        /// </summary>
        /// <returns></returns>
        public virtual string CreateMd5Sign()
        {
            StringBuilder sb = new StringBuilder();
            ArrayList akeys = new ArrayList(Parameters.Keys);
            akeys.Sort(ASCIISort.Create());

            foreach (string k in akeys)
            {
                string v = (string)Parameters[k];
                if (null != v && "".CompareTo(v) != 0
                    && "sign".CompareTo(k) != 0 && "".CompareTo(v) != 0)
                {
                    sb.Append(k + "=" + v + "&");
                }
            }
            string sign = MD5UtilHelper.GetMD5(sb.ToString(), GetCharset()).ToLower();

            this.SetParameter("sign", sign);
            return sign;
        }


        /// <summary>
        /// ����sha1ǩ��
        /// </summary>
        /// <returns></returns>
        public string CreateSHA1Sign()
        {
            StringBuilder sb = new StringBuilder();
            ArrayList akeys = new ArrayList(Parameters.Keys);
            akeys.Sort(ASCIISort.Create());

            foreach (string k in akeys)
            {
                string v = (string)Parameters[k];
                if (null != v && "".CompareTo(v) != 0
                       && "sign".CompareTo(k) != 0 && "key".CompareTo(k) != 0)
                {
                    if (sb.Length == 0)
                    {
                        sb.Append(k + "=" + v);
                    }
                    else
                    {
                        sb.Append("&" + k + "=" + v);
                    }
                }
            }
            string paySign = SHA1UtilHelper.GetSha1(sb.ToString()).ToString().ToLower();

            //debug��Ϣ
            this.SetDebugInfo(sb.ToString() + " => sign:" + paySign);
            return paySign;
        }


        /// <summary>
        /// ���XML
        /// </summary>
        /// <returns></returns>
        public string ParseXML()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<xml>");
            foreach (string k in Parameters.Keys)
            {
                string v = (string)Parameters[k];
                if (Regex.IsMatch(v, @"^[0-9.]$"))
                {

                    sb.Append("<" + k + ">" + v + "</" + k + ">");
                }
                else
                {
                    sb.Append("<" + k + "><![CDATA[" + v + "]]></" + k + ">");
                }

            }
            sb.Append("</xml>");
            return sb.ToString();
        }



        /// <summary>
        /// ����debug��Ϣ
        /// </summary>
        /// <param name="debugInfo"></param>
        public void SetDebugInfo(String debugInfo)
        {
            this.DebugInfo = debugInfo;
        }

        public Hashtable GetAllParameters()
        {
            return this.Parameters;
        }

        protected virtual string GetCharset()
        {
#if NET35 || NET40 || NET45
            return this.HttpContext.Request.ContentEncoding.BodyName;
#else
            return Encoding.UTF8.WebName;
#endif
        }
    }
}
