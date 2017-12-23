using System;

namespace Dora.Weixin.Entities
{
    /// <summary>
    /// 包含 errorcode 的 Json 返回结果接口
    /// </summary>
    public interface IWxJsonResult : IJsonResult
    {
        /// <summary>
        /// 返回结果代码
        /// </summary>
        ReturnCode errcode { get; set; }
    }

    /// <summary>
    /// 公众号 JSON 返回结果（用于菜单接口等）
    /// </summary>
    [Serializable]
    public class WxJsonResult : BaseJsonResult
    {
        //会造成循环引用
        //public WxJsonResult BaseResult
        //{
        //    get { return this; }
        //}

        public ReturnCode errcode { get; set; }

        /// <summary>
        /// 返回消息代码数字（同errcode枚举值）
        /// </summary>
        public override int ErrorCodeValue { get { return (int)errcode; } }


        public override string ToString()
        {
            return string.Format("WxJsonResult：{{errcode:'{0}',errcode_name:'{1}',errmsg:'{2}'}}",
                (int)errcode, errcode.ToString(), errmsg);
        }

        //public ReturnCode ReturnCode
        //{
        //    get
        //    {
        //        try
        //        {
        //            return (ReturnCode) errorcode;
        //        }
        //        catch
        //        {
        //            return ReturnCode.系统繁忙;//如果有“其他错误”的话可以指向其他错误
        //        }
        //    }
        //}
        //public void SerializingCallback()
        //{
        //}

        //public void SrializedCallback(string json)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeserializingCallback(string json)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeserializedCallback(string json)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
