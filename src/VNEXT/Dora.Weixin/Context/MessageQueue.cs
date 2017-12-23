﻿using System.Collections.Generic;
using Dora.Weixin.Entities;

namespace Dora.Weixin.Context
{
    /// <summary>
    /// 微信消息队列（所有微信账号的往来消息）
    /// </summary>
    /// <typeparam name="TM">IMessageContext&lt;TRequest, TResponse&gt;</typeparam>
    /// <typeparam name="TRequest">IRequestMessageBase</typeparam>
    /// <typeparam name="TResponse">IResponseMessageBase</typeparam>
    public class MessageQueue<TM,TRequest, TResponse> : List<TM> 
        where TM : class, IMessageContext<TRequest, TResponse>, new()
        where TRequest : IRequestMessageBase
        where TResponse : IResponseMessageBase
    {
    }
}
