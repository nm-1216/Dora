
namespace Dora.Weixin.MP.Entities.Menu
{
    /// <summary>
    /// 下发消息（除文本消息）按钮
    /// </summary>
    public class SingleViewLimitedButton : SingleButton
    {
        /// <summary>
        /// 用户点击view_limited类型按钮后，微信客户端将打开开发者在按钮中填写的永久素材id对应的图文消息URL，永久素材类型只支持图文消息。请注意：永久素材id必须是在“素材管理/新增永久素材”接口上传后获得的合法id。
        /// </summary>
        public string media_id { get; set; }

        public SingleViewLimitedButton()
            : base(ButtonType.view_limited.ToString())
        {
        }
    }
}
