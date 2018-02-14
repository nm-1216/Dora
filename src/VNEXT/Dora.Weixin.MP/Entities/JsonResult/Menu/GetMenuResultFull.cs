﻿
using System.Collections.Generic;
using Dora.Weixin.Entities;
using Dora.Weixin.MP.Entities.Menu;

namespace Dora.Weixin.MP
{
    #region GetMenuResultFull 相关
    /// <summary>
    /// 获取菜单时候的完整结构，用于接收微信服务器返回的Json信息
    /// 注：menu为默认菜单，conditionalmenu为个性化菜单列表。字段说明请见个性化菜单接口页的说明。
    /// </summary>
    public class GetMenuResultFull : WxJsonResult
    {
        public MenuFull_ButtonGroup menu { get; set; }

        /// <summary>
        /// 有个性化菜单时显示。最新的在最前。
        /// </summary>
        public List<MenuFull_ConditionalButtonGroup> conditionalmenu { get; set; }
    }

    public class MenuFull_ButtonGroup
    {
        public List<MenuFull_RootButton> button { get; set; }
    }

    public class MenuFull_RootButton
    {
        public string type { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string url { get; set; }

        #region 小程序

        public string appid { get; set; }
        public string pagepath { get; set; }

        #endregion

        public string media_id { get; set; }

        public List<MenuFull_RootButton> sub_button { get; set; }
    }
    #endregion

    #region Conditional（个性化菜单）相关
    public class MenuTryMatchResult : WxJsonResult
    {
        public List<MenuFull_RootButton> button { get; set; }
    }

    /// <summary>
    /// 接收菜单信息时用的“最大可能性”类型
    /// </summary>
    public class MenuFull_ConditionalButtonGroup: MenuFull_ButtonGroup
    {
        public MenuMatchRule matchrule { get; set; }
        /// <summary>
        /// 菜单Id，只在获取的时候自动填充，提交“菜单创建”请求时不需要设置
        /// </summary>
        public long menuid { get; set; }
    }


    #endregion

}
