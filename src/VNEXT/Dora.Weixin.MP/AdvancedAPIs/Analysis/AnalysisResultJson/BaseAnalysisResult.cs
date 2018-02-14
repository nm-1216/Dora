


using Dora.Weixin.Entities;
using Dora.Weixin.Entities;

namespace Dora.Weixin.MP.AdvancedAPIs.Analysis
{
    public interface IBaseAnalysisResult
    {
        object ListObj { get; set; }
    }

    public abstract class BaseAnalysisResult : WxJsonResult, IBaseAnalysisResult
    {
        public object ListObj { get; set; }

        //public BaseAnalysisResult()
        //{
        //    list = new List<BaseAnalysisObject>();
        //}
    }
}
