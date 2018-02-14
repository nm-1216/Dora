
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.Weixin.Entities;

namespace Dora.Weixin.MP.AdvancedAPIs.Card
{
    /// <summary>
    /// 拉取单个子商户信息的返回结果
    /// </summary>
    public class GetCardMerchantJsonResult : WxJsonResult 
    {
        /// <summary>
        /// 
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int primary_category_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int secondary_category_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string submit_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int result { get; set; }
        
    }
  
}
