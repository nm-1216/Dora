
using Dora.Weixin.MessageHandlers;
using Dora.Weixin.MP.Entities;

namespace Dora.Weixin.MP.MessageHandlers
{

    public interface IMessageHandler : IMessageHandler<IRequestMessageBase, IResponseMessageBase>
    {
        new IRequestMessageBase RequestMessage { get; set; }
        new IResponseMessageBase ResponseMessage { get; set; }
    }
}
