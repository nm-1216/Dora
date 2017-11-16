namespace Dora.Services.Wx.Interfaces
{
    public interface IQyhApiService
    {
        #region GetToken
        string getToken(string corpId, string corpSecret);
        #endregion

        #region 资源接口 -- 管理企业号应用 -- 获取企业号应用
        string agentGet(string access_token, string agentId);

        string agentSet(string access_token, string postValue);

        string agentList(string access_token);
        #endregion

        #region 资源接口 -- 管理通讯录 -- 管理成员

        /// <summary>
        /// 创建成员
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="postValue">POST 参数</param>
        /// <returns>返回结果集合</returns>
        string userCreate(string access_token, string postValue);

        /// <summary>
        /// 更新成员
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="postValue">POST 参数</param>
        /// <returns>返回结果集合</returns>
        string userUpdate(string access_token, string postValue);

        /// <summary>
        /// 获取成员
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="userId">成员UserID。对应管理端的帐号</param>
        /// <returns>返回结果集合</returns>
        string userGet(string access_token, string userId);

        /// <summary>
        /// 删除成员
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="userId">成员UserID。对应管理端的帐号</param>
        /// <returns>返回结果集合</returns>
        string userDelete(string access_token, string userId);

        /// <summary>
        /// 批量删除成员
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="postValue">POST 参数</param>
        /// <returns>返回结果集合</returns>
        string userBatchDelete(string access_token, string postValue);

        /// <summary>
        /// 获取部门成员
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="department_id">获取的部门id</param>
        /// <param name="fetch_child">1/0：是否递归获取子部门下面的成员</param>
        /// <param name="status">0获取全部成员，1获取已关注成员列表，2获取禁用成员列表，4获取未关注成员列表。status可叠加，未填写则默认为4</param>
        /// <returns>返回结果集合</returns>
        string userSimpleList(string access_token, int department_id, int fetch_child, string status);

        /// <summary>
        /// 获取部门成员(详情)
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="department_id">获取的部门id</param>
        /// <param name="fetch_child">1/0：是否递归获取子部门下面的成员</param>
        /// <param name="status">0获取全部成员，1获取已关注成员列表，2获取禁用成员列表，4获取未关注成员列表。status可叠加，未填写则默认为4</param>
        /// <returns>返回结果集合</returns>
        string userList(string access_token, int department_id, int fetch_child, string status);
        #endregion

        #region 资源接口 -- 管理通讯录 -- 部门管理

        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="postValue">POST 参数</param>
        /// <returns>返回结果集合</returns>
        string departmentCreate(string access_token, string postValue);

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="postValue">POST 参数</param>
        /// <returns>返回结果集合</returns>
        string departmentUpdate(string access_token, string postValue);

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="departmentId">部门id。（注：不能删除根部门；不能删除含有子部门、成员的部门）</param>
        /// <returns>返回结果集合</returns>
        string departmentDelete(string access_token, string departmentId);

        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="departmentId">部门id。（注：不能删除根部门；不能删除含有子部门、成员的部门）</param>
        /// <returns>返回结果集合</returns>
        string departmentList(string access_token, string departmentId);


        #endregion

        #region 资源接口 -- 管理通讯录 -- 管理标签

        /// <summary>
        /// 创建标签
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="postValue">POST 参数</param>
        /// <returns>返回结果集合</returns>
        string tagCreate(string access_token, string postValue);

        /// <summary>
        /// 更新标签名字
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="postValue">POST 参数</param>
        /// <returns>返回结果集合</returns>
        string tagUpdate(string access_token, string postValue);

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="tagId">标签ID</param>
        /// <returns>返回结果集合</returns>
        string tagDelete(string access_token, string tagId);


        /// <summary>
        /// 获取标签成员
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="tagId">标签ID</param>
        /// <returns>返回结果集合</returns>
        string tagGet(string access_token, string tagId);

        /// <summary>
        /// 增加标签成员
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="postValue">POST 参数</param>
        /// <returns>返回结果集合</returns>
        string tagAddTagUsers(string access_token, string postValue);

        /// <summary>
        /// 删除标签成员
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="postValue">POST 参数</param>
        /// <returns>返回结果集合</returns>
        string tagDelTagUsers(string access_token, string postValue);


        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <returns>返回结果集合</returns>
        string tagList(string access_token);

        #endregion

        #region 资源接口 -- 管理通讯录 -- 异步任务接口

        /// <summary>
        /// 增量更新成员
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="postValue">POST 参数</param>
        /// <returns>返回结果集合</returns>
        string BatchSyncUser(string access_token, string postValue);

        /// <summary>
        /// 全量覆盖成员
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="postValue">POST 参数</param>
        /// <returns>返回结果集合</returns>
        string BatchReplaceUser(string access_token, string postValue);

        /// <summary>
        /// 全量覆盖部门
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="postValue">POST 参数</param>
        /// <returns>返回结果集合</returns>
        string BatchReplaceParty(string access_token, string postValue);

        /// <summary>
        /// 获取异步任务结果
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="jobid">异步任务id，最大长度为64字节</param>
        /// <returns>返回结果集合</returns>
        string BatchGetResult(string access_token, string jobid);


        #endregion

        #region 资源接口 -- 管理素材文件 -- 上传临时素材文件

        /// <summary>
        /// 上传临时素材文件
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="type">媒体文件类型，分别有图片（image）、语音（voice）、视频（video），普通文件(file)</param>
        /// <param name="postValue">form-data中媒体文件标识，有filename、filelength、content-type等信息</param>
        /// <returns>返回结果集合</returns>
        string mediaUpload(string access_token, string type, string postValue);


        #endregion

        #region 资源接口 -- 自定义菜单 -- 创建应用菜单

        /// <summary>
        /// 创建应用菜单
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="agentid">应用ID</param>
        /// <param name="postValue">POST 参数</param>
        /// <returns>返回结果集合</returns>
        string menuCreate(string access_token, string agentid, string postValue);

        #endregion

        #region 资源接口 -- 自定义菜单 -- 删除菜单
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="agentid">应用ID</param>
        /// <returns>返回结果集合</returns>
        string menuDelete(string access_token, string agentid);
        #endregion

        #region 资源接口 -- 自定义菜单 -- 获取菜单列表

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="agentid">应用ID</param>
        /// <returns>返回结果集合</returns>
        string menuGet(string access_token, string agentid);

        #endregion

        #region 资源接口 -- 管理素材文件 -- 获取临时素材文件
        /// <summary>
        /// 获取临时素材文件
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="media_id">媒体文件id。最大长度为256字节</param>
        /// <returns></returns>
        string mediaGet(string access_token, string media_id);

        #endregion

        #region 能力接口 -- 发消息 -- 发送接口说明

        /// <summary>
        /// 获取临时素材文件
        /// </summary>
        /// <param name="access_token">调用接口凭证</param>
        /// <param name="postValue">消息型应用支持文本、图片、语音、视频、文件、图文等消息类型。主页型应用只支持文本消息类型，且文本长度不超过20个字</param>
        /// <returns></returns>
        string messageSend(string access_token, string postValue);



        #endregion

    }
}



