

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.Weixin.MP.AdvancedAPIs.Card
{
    public class NorFilter
    {
        /// <summary>
        /// 反选，不要拉取的订单
        /// </summary>
        public string status { get; set; }
    }

    public class SortInfo
    {
        /// <summary>
        /// 排序依据，SORT_BY_TIME 以订单时间排序
        /// </summary>
        public string sort_key { get; set; }
        /// <summary>
        /// 排序规则，SORT_ASC 升序SORT_DESC 降序
        /// </summary>
        public string sort_type { get; set; }
    }
}
