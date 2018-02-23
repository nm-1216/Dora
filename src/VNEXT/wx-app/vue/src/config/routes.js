const AUTHOR = resolve => require(['src/pages/roche/author'], resolve)
const INDEX = resolve => require(['src/pages/roche/index'], resolve)
const REG = resolve => require(['src/pages/roche/reg'], resolve)

/* 用户-用户资料 */
const UserInfo = resolve => require(['src/pages/roche/userinfo'], resolve)
const EditUserInfo = resolve => require(['src/pages/roche/userinfo-edit'], resolve)

/* 活动-活动列表 */
const Activity = resolve => require(['src/pages/roche/activity'], resolve)
const ActivityDetails = resolve => require(['src/pages/roche/activity-details'], resolve)

export default [
  {
    path: '/author',
    meta: { auth: false, title: '微信自动登陆-罗氏' },
    component: AUTHOR
  },
  {
    path: '/author/:openId/:existsUser',
    meta: { auth: false, title: '微信自动登陆-罗氏' },
    component: AUTHOR
  },
  {
    path: '/reg',
    meta: { auth: false, title: '用户注册-罗氏' },
    component: REG
  },
  {
    path: '/userinfo',
    meta: { auth: true, title: '我的资料-罗氏' },
    component: UserInfo
  },
  {
    path: '/edituserinfo',
    meta: { auth: true, title: '修改我的资料-罗氏' },
    component: EditUserInfo
  },
  {
    path: '/activity',
    meta: { auth: true, title: '会议列表-罗氏' },
    component: Activity
  },
  {
    path: '/activitydetails/:id',
    meta: { auth: true, title: '会议详情-罗氏' },
    component: ActivityDetails
  },
  {
    path: '/',
    meta: { auth: true, title: '首页-罗氏' },
    component: INDEX
  }
]
