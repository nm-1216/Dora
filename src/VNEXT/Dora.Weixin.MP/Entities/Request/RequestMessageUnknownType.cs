

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Dora.Weixin.MP.Entities
{
    public class RequestMessageUnknownType : RequestMessageBase, IRequestMessageBase
    {
        public override RequestMsgType MsgType
        {
            get { return RequestMsgType.Unknown; }
        }

        /// <summary>
        /// 请求消息的XML对象（明文）
        /// </summary>
        public XDocument RequestDocument { get; set; }

    }
}
