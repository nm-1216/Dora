namespace WxPayAPI
{
    public partial class JsApiPayPage 
    {
        //H5调起JS API参数
        public static string wxJsApiParam {get;set;}


        protected void Page_Load()
        {
            string openid = "";
            int total_fee = 100;
            JsApiPay jsApiPay = new JsApiPay("");
            
            jsApiPay.openid = "openid";
            jsApiPay.total_fee = 100; //小费100;
            
            wxJsApiParam = jsApiPay.GetJsApiParameters(); //获取H5调起JS API参数   
        }
    }
}