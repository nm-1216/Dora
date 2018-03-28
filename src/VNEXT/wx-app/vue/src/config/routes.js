const AUTHOR = resolve => require(['src/pages/roche/author'], resolve)
const INDEX = resolve => require(['src/pages/school/index'], resolve)
const REG = resolve => require(['src/pages/roche/reg'], resolve)
const FAXIAN = resolve => require(['@/pages/school/faxian'], resolve)
const XIAOXI = resolve => require(['@/pages/school/xiaoxi'], resolve)
const CLASS = resolve => require(['@/pages/school/class'], resolve)
/* 用户-用户资料 */
const UserInfo = resolve => require(['src/pages/roche/userinfo'], resolve)
const EditUserInfo = resolve => require(['src/pages/roche/userinfo-edit'], resolve)
/* 活动-活动列表 */
const APPTITle = '学校'

export default [
  {
    path: '/author',
    meta: { auth: false, title: '微信自动登陆-' + APPTITle },
    component: AUTHOR
  },
  {
    path: '/author/:openId/:existsUser',
    meta: { auth: false, title: '微信自动登陆-' + APPTITle },
    component: AUTHOR
  },
  {
    path: '/reg',
    meta: { auth: false, title: '用户注册-' + APPTITle },
    component: REG
  },
  {
    path: '/userinfo',
    meta: { auth: true, title: '我的资料-' + APPTITle },
    component: UserInfo
  },
  {
    path: '/edituserinfo',
    meta: { auth: true, title: '修改我的资料-' + APPTITle },
    component: EditUserInfo
  },
  {
    path: '/',
    meta: { auth: true, title: '首页-' + APPTITle },
    component: INDEX
  },
  {
    path: '/faxian',
    meta: { auth: false, title: '发现-' + APPTITle },
    component: FAXIAN
  },
  {
    path: '/xiaoxi',
    meta: { auth: false, title: '消息-' + APPTITle },
    component: XIAOXI
  },
  {
    path: '/class/:classId/:courseId',
    meta: { auth: false, title: '课程-' + APPTITle },
    component: CLASS
  }
]
