
using System.Collections.Generic;
using Dora.Utilities.HttpUtility;
using Dora.Weixin.HttpUtility;

namespace Dora.Weixin.MP.AppStore.Api
{
    public class MemberApi : BaseApi
    {
        public MemberApi(Passport passport)
            : base(passport)
        {
        }

        private GetMemberResult GetMemberFunc(int weixinId, string openId)
        {
            var url = _passport.ApiUrl + "GetMember";
            var formData = new Dictionary<string, string>();
            formData["token"] = _passport.Token;
            formData["openid"] = openId;
            formData["weixinId"] = weixinId.ToString();

            var result = Post.PostGetJson<GetMemberResult>(url, formData: formData);
            return result;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public GetMemberResult GetMember(int weixinId, string openId)
        {
            return ApiConnection.Connection(() => GetMemberFunc(weixinId, openId)) as GetMemberResult;
        }
    }
}
