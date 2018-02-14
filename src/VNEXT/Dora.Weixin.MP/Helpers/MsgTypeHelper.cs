
using System;
using System.Xml.Linq;

namespace Dora.Weixin.MP.Helpers
{
    /// <summary>
    /// 消息类型帮助类
    /// </summary>
    public static class MsgTypeHelper
    {
        #region RequestMsgType
        /// <summary>
        /// 根据xml信息，返回RequestMsgType
        /// </summary>
        /// <returns></returns>
        public static string GetRequestMsgTypeString(XDocument requestMessageDocument)
        {
            if (requestMessageDocument == null || requestMessageDocument.Root == null || requestMessageDocument.Root.Element("MsgType") == null)
            {
                return "Unknow";
            }

            return requestMessageDocument.Root.Element("MsgType").Value;
        }

        /// <summary>
        /// 根据xml信息，返回RequestMsgType
        /// </summary>
        /// <returns></returns>
        public static RequestMsgType GetRequestMsgType(XDocument requestMessageDocument)
        {
            return GetRequestMsgType(GetRequestMsgTypeString(requestMessageDocument));
        }
        /// <summary>
        /// 根据xml信息，返回RequestMsgType
        /// </summary>
        /// <returns></returns>
        public static RequestMsgType GetRequestMsgType(string str)
        {
            try
            {
                return (RequestMsgType)Enum.Parse(typeof(RequestMsgType), str, true);
            }
            catch
            {
                return RequestMsgType.Unknown;
            }
        }

        #endregion

        #region ResponseMsgType
        /// <summary>
        /// 根据xml信息，返回ResponseMsgType
        /// </summary>
        /// <returns></returns>
        public static ResponseMsgType GetResponseMsgType(XDocument doc)
        {
            return GetResponseMsgType(doc.Root.Element("MsgType").Value);
        }
        /// <summary>
        /// 根据xml信息，返回ResponseMsgType
        /// </summary>
        /// <returns></returns>
        public static ResponseMsgType GetResponseMsgType(string str)
        {
            return (ResponseMsgType)Enum.Parse(typeof(ResponseMsgType), str, true);
        }

        #endregion
    }
}
