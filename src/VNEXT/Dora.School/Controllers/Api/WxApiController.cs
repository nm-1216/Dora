using System.Diagnostics;
using Dora.Domain.Entities.School;
using Microsoft.AspNetCore.Identity;

namespace Dora.School.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Cors;
    using Dora.Core;
    using Microsoft.EntityFrameworkCore;

    [EnableCors("AllowSameDomain")]
    public class WxApiController : Controller
    {
        private readonly ILogger _logger;
        private readonly UserManager<SchoolUser> _userManager;

        public WxApiController(
            UserManager<SchoolUser> userManager,
            ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger<WxApiController>();
            this._userManager = userManager;
        }

        #region user

        [EnableCors("AllowSameDomain")]
        public async Task<IActionResult> Register(string userId, string pwd, string openId)
        {
            var model = await this._userManager.FindByIdAsync(userId);
            var rst = false;
            if (null != model)
            {
                rst = await this._userManager.CheckPasswordAsync(model, pwd);
            }

            if (rst)
            {
                model.WxOpenId = openId;

                var temp = await this._userManager.UpdateAsync(model);
                rst = temp.Succeeded;
            }

            return Json(new AjaxResult(rst ? "绑定成功" : "绑定失败") {result = rst ? 0 : 1});
        }
        
        [EnableCors("AllowSameDomain")]
        public IActionResult GetUserInfo(string openId)
        {
            var model = this._userManager.Users.FirstOrDefault(o => o.WxOpenId == openId);
            var rst = model != null;
            
            return Json(new AjaxResult<SchoolUser>(rst ? "查询成功" : "查询失败") { result = rst ? 0 : 1, data = model });
        }

        #endregion

    }
}