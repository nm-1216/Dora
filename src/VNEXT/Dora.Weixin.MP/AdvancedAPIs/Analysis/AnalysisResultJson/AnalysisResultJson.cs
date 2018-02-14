

using System.Collections.Generic;

namespace Dora.Weixin.MP.AdvancedAPIs.Analysis
{
    /// <summary>
    /// 分析数据接口返回结果
    /// </summary>
    public class AnalysisResultJson<T> : BaseAnalysisResult
    {
        public List<T> list
        {
            get { return base.ListObj as List<T>; }
            set { base.ListObj = value; }
        }

        public AnalysisResultJson()
        {
            ListObj = new List<T>();
        }
    }

}
