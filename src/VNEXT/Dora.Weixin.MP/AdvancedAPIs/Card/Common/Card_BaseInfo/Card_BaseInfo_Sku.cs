

namespace Dora.Weixin.MP.AdvancedAPIs.Card
{
    /// <summary>
    /// 商品信息
    /// </summary>
    public class Card_BaseInfo_Sku
    {
        /// <summary>
        /// 上架的数量。（不支持填写0或无限大）
        /// 必填
        /// </summary>
        public int quantity { get; set; }
        /// <summary>
        /// 卡券全部库存的数量，上限为100000000。
        /// </summary>
        public int total_quantity { get; set; }
    }
}
