﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dora.Weixin.Entities;

namespace Dora.Weixin.MP.AdvancedAPIs.Card
{
    /// <summary>
    /// 卡券开放类目查询的返回结果
    /// </summary>
   public class GetApplyProtocolJsonResult : WxJsonResult
    {
      public List<GetApplyProtocol_Category> category { get; set; } 
     }
   public class GetApplyProtocol_Category
   {
       /// <summary>
       /// 一级目录id
       /// </summary>
       public int primary_category_id { get; set; }
       /// <summary>
       /// 
       /// </summary>
       public string category_name { get; set; }
       /// <summary>
       /// 二级目录id
       /// </summary>
       public List<GetApplyProtocol_Secondary_Category> secondary_category { get; set; } 

      
   }
   public class GetApplyProtocol_Secondary_Category
   {
       /// <summary>
       /// 
       /// </summary>
       public int secondary_category_id { get; set; }
       /// <summary>
       /// 
       /// </summary>
       public string category_name { get; set; }
       /// <summary>
       /// 
       /// </summary>
       public List<string> need_qualification_stuffs { get; set; }
       /// <summary>
       /// 
       /// </summary>
       public int can_choose_prepaid_card { get; set; }
       /// <summary>
       /// 
       /// </summary>
       public int can_choose_payment_card { get; set; }
   }
}
