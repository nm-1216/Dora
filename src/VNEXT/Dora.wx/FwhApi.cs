namespace Dora.wx
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Weixin.MP;
    using Weixin.MP.Entities.Request;
    using Dora.Services.School.Interfaces;
    using Microsoft.Extensions.Options;

    [Route("api/FwhApi")]
    [AllowAnonymous]
    public class FwhApiController : Controller
    {
        protected readonly ILogger<FwhApiController> _logger;
        private ITimeCardService _timeCardService;
        private IStudentService _studentService;
        private readonly WxConfig _wxconfig;
        
        public FwhApiController(
            ILoggerFactory loggerFactory
            , ITimeCardService timeCardService
            , IStudentService studentService
            , IOptions<WxConfig> options
        )
        {
            this._logger = loggerFactory.CreateLogger<FwhApiController>();
            _studentService = studentService;
            _timeCardService = timeCardService;
            _wxconfig = options.Value;
        }

        // GET: api/values
        [AllowAnonymous]
        [HttpGet]
        public string Get(PostModel postModel, string echostr)
        {
            _logger.LogError("Get");

            if (CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, _wxconfig.Token))
            {
                return echostr;
            }
            else
            {
                return ("failed:" + postModel.Signature + "," + CheckSignature.GetSignature(postModel.Timestamp, postModel.Nonce, _wxconfig.Token) + "。" +
                    "如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
            }
        }


        // POST api/values
        [HttpPost]
        public string Post(PostModel postModel)
        {
            if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, _wxconfig.Token))
            {
                return "参数错误！";
            }

            postModel.Token = _wxconfig.Token;
            postModel.EncodingAESKey = _wxconfig.Appsecret;
            postModel.AppId = _wxconfig.AppID;

            var messageHandler =
                new CustomMessageHandler.CustomMessageHandler(Request.Body, postModel, _timeCardService,
                    _studentService, 10);

            messageHandler.Execute();
            return (messageHandler.ResponseDocument.ToString());
        }
    }
}

