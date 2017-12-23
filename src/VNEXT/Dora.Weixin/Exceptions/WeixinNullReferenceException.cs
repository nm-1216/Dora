using System;

namespace Dora.Weixin.Exceptions
{
    /// <summary>
    /// 菜单异常
    /// </summary>
    public class WeixinNullReferenceException : WeixinException
    {
        /// <summary>
        /// 上一级不为null的对象（或对调试很重要的对象）。
        /// 如果需要调试多个对象，可以传入数组，如：new {obj1, obj2}
        /// </summary>
        public object ParentObject { get; set; }
        public WeixinNullReferenceException(string message)
            : this(message, null, null)
        {
        }

        public WeixinNullReferenceException(string message, object parentObject)
            : this(message, parentObject, null)
        {
            ParentObject = parentObject;
        }

        public WeixinNullReferenceException(string message, object parentObject, Exception inner)
            : base(message, inner)
        {
            ParentObject = parentObject;
        }
    }
}
