using System;
using System.Text;
using Dora.Core.Net;
using Dora.Services.Wx.Interfaces;

namespace Dora.Services.Wx
{
    /// <summary>
    /// 微信企业号接口
    /// </summary>
    public class QyhApiService : IQyhApiService
    {
        const string CORPID = "wxec46009c21377bf5";
        const string CORPSECRET = "A8Yc_LDpBM3rPL8ssTDVpCaavl_HkAXwmu3StojrDnqB7m8lB3hd_Yffar5-IG-f";

        const string URL_GETTOKEN = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}";


        const string URL_AGENT_LIST = "https://qyapi.weixin.qq.com/cgi-bin/agent/list?access_token={0}";
        const string URL_AGENT_GET = "https://qyapi.weixin.qq.com/cgi-bin/agent/get?access_token={0}&agentid={1}";
        const string URL_AGENT_SET = "https://qyapi.weixin.qq.com/cgi-bin/agent/set?access_token={0}";
                                       


        string IQyhApiService.agentGet(string access_token, string agentId)
        {
            return UrlRequest.GetText(string.Format(URL_AGENT_GET, access_token, agentId));
        }

        string IQyhApiService.agentList(string access_token)
        {
            return UrlRequest.GetText(string.Format(URL_AGENT_LIST, access_token));
        }

        string IQyhApiService.agentSet(string access_token, string postValue)
        {
            return UrlRequest.GetText(UrlRequest.Send(string.Format(URL_AGENT_SET, access_token), "", "post", Encoding.UTF8, postValue).Result);
        }

        string IQyhApiService.BatchGetResult(string access_token, string jobid)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.BatchReplaceParty(string access_token, string postValue)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.BatchReplaceUser(string access_token, string postValue)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.BatchSyncUser(string access_token, string postValue)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.departmentCreate(string access_token, string postValue)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.departmentDelete(string access_token, string departmentId)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.departmentList(string access_token, string departmentId)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.departmentUpdate(string access_token, string postValue)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.getToken(string corpId, string corpSecret)
        {
            if (string.IsNullOrEmpty(corpId))
                return UrlRequest.GetText(string.Format(URL_GETTOKEN, CORPID, CORPSECRET));
            else
                return UrlRequest.GetText(string.Format(URL_GETTOKEN, corpId, corpSecret));
        }

        string IQyhApiService.mediaGet(string access_token, string media_id)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.mediaUpload(string access_token, string type, string postValue)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.menuCreate(string access_token, string agentid, string postValue)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.menuDelete(string access_token, string agentid)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.menuGet(string access_token, string agentid)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.messageSend(string access_token, string postValue)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.tagAddTagUsers(string access_token, string postValue)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.tagCreate(string access_token, string postValue)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.tagDelete(string access_token, string tagId)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.tagDelTagUsers(string access_token, string postValue)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.tagGet(string access_token, string tagId)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.tagList(string access_token)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.tagUpdate(string access_token, string postValue)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.userBatchDelete(string access_token, string postValue)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.userCreate(string access_token, string postValue)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.userDelete(string access_token, string userId)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.userGet(string access_token, string userId)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.userList(string access_token, int department_id, int fetch_child, string status)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.userSimpleList(string access_token, int department_id, int fetch_child, string status)
        {
            throw new NotImplementedException();
        }

        string IQyhApiService.userUpdate(string access_token, string postValue)
        {
            throw new NotImplementedException();
        }
    }

}
