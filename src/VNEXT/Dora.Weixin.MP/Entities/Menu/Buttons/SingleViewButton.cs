
namespace Dora.Weixin.MP.Entities.Menu
{
    /// <summary>
    /// Url按钮
    /// </summary>
    public class SingleViewButton : SingleButton
    {
        /// <summary>
        /// 类型为view时必须
        /// 网页链接，用户点击按钮可打开链接，不超过1024字节
        /// </summary>
        public string url { get; set; }

        public SingleViewButton()
            : base(ButtonType.view.ToString())
        {
        }
    }
}
