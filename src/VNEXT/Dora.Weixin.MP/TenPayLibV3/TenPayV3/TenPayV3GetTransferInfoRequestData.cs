﻿namespace Dora.Weixin.MP.TenPayLibV3
{
    /// <summary>
    ///微信支付提交的XML Data数据[查询企业付款]
    /// </summary>
    public class TenPayV3GetTransferInfoRequestData
    {
        /// <summary>
        /// 公众账号ID [appid]
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 商户号 [mch_id]
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// 随机字符串 [nonce_str]
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        /// 商户订单号，[partner_trade_no]
        /// </summary>
        public string PartnerTradeNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Key { get; set; }

        public readonly RequestHandler PackageRequestHandler;
        public readonly string Sign;

        /// <summary>
        /// 查询企业付款
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="mchId"></param>
        /// <param name="nonceStr"></param>
        /// <param name="partnerTradeNo"></param>
        /// <param name="key"></param>
        public TenPayV3GetTransferInfoRequestData(string appId, string mchId, string nonceStr,
            string partnerTradeNo, string key)
        {
            AppId = appId;
            MchId = mchId;
            NonceStr = nonceStr;
            PartnerTradeNo = partnerTradeNo;
            Key = key;

            #region 设置RequestHandler

            //创建支付应答对象
            PackageRequestHandler = new RequestHandler(null);
            //初始化
            PackageRequestHandler.Init();
            //设置package订单参数
            PackageRequestHandler.SetParameter("nonce_str", this.NonceStr); //随机字符串
            PackageRequestHandler.SetParameter("partner_trade_no", this.PartnerTradeNo); //商户订单号
            PackageRequestHandler.SetParameter("mch_id", this.MchId); //商户号
            PackageRequestHandler.SetParameter("appid", this.AppId); //Appid
            Sign = PackageRequestHandler.CreateMd5Sign("key", this.Key);
            PackageRequestHandler.SetParameter("sign", Sign); //签名

            #endregion
        }
    }
}