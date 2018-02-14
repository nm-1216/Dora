
using System.Collections.Generic;

namespace Dora.Weixin.MP.Entities
{
    /// <summary>
    /// 响应回复多客服消息
    /// </summary>
	public class ResponseMessageTransfer_Customer_Service : ResponseMessageBase, IResponseMessageBase
	{
		public ResponseMessageTransfer_Customer_Service()
		{
			TransInfo = new List<CustomerServiceAccount>();
		}

		public new virtual ResponseMsgType MsgType
		{
			get { return ResponseMsgType.Transfer_Customer_Service; }
		}

		public List<CustomerServiceAccount> TransInfo { get; set; }
	}

	public class CustomerServiceAccount
	{
		public string KfAccount { get; set; }
	}
 }