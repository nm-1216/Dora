using Dora.Services.School.Interfaces;
using Dora.Weixin;

namespace Dora.School.Controllers.Job
{
    using Pomelo.AspNetCore.TimedJob;
    using System;
    using wx;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System.Linq;
    using Domain.Entities.School;
    using Weixin.MP.AdvancedAPIs.User;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// 不能用异步操作
    /// </summary>
    public class JobWxUser : Job
    {
        [Invoke(Interval = 1000 * 3600 * 1, SkipWhileExecuting = true)]
        public void Run1([FromServices] IOptions<WxConfig> options, DbContext dbContext)
        {
            var wxconfig = options.Value;

            using (var db = dbContext as ApplicationDbContext)
            {
                if (db == null)
                    return;

                var list = db.Users.Where(b => !string.IsNullOrEmpty(b.WxOpenId));
                Weixin.MP.Containers.AccessTokenContainer.Register(wxconfig.AppID, wxconfig.Appsecret);
                foreach (var item in list)
                {
                    UserInfoJson model;
                    try
                    {
                        model = Weixin.MP.AdvancedAPIs.UserApi.Info(wxconfig.AppID, item.WxOpenId);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        continue;
                    }

                    if (model != null && (model.ErrorCodeValue<=0))
                    {
                        item.WxAvatar = model.headimgurl;
                        item.WxName = model.nickname;
                    }
                }

                db.Set<SchoolUser>().UpdateRange(list);
                db.SaveChanges();
            }
        }


    }



}