﻿
namespace Dora.Weixin.MP.AppStore
{
   public class ReturnResult
    {
        /// <summary>
        /// 如果>0则进入某个APP状态，如果=0则维持当前状态不变，如果>0则退出某个App状态
        /// </summary>
       public AppStoreState AppStoreState { get; set; }
       /// <summary>
       /// 改变状态的AppId
       /// </summary>
       public int AppId { get; set; }
       /// <summary>
       /// 错误信息
       /// </summary>
       public string ErrorMessage { get; set; }
    }
}
