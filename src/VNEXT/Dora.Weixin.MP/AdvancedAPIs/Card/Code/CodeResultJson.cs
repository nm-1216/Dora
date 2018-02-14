

using System.Collections.Generic;
using Dora.Weixin.Entities;

namespace Dora.Weixin.MP.AdvancedAPIs.Card
{
    /// <summary>
    /// 查询导入code数目返回结果
    /// </summary>
    public class GetDepositCountResultJson : WxJsonResult
    {
        /// <summary>
        /// 货架已经成功存入的code数目。
        /// </summary>
        public int count { get; set; }
    }

    /// <summary>
    /// 核查code返回结果
    /// </summary>
    public class CheckCodeResultJson : WxJsonResult
    {
        /// <summary>
        /// 已经成功存入的code。
        /// </summary>
        public List<string> exist_code { get; set; }
        /// <summary>
        /// 没有存入的code。
        /// </summary>
        public List<string> not_exist_code { get; set; }
    }
}
