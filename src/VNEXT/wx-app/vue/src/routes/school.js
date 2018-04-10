import _global from '../config/global'

const INDEX = resolve => require(['src/pages/school/index'], resolve)
const CLASS = resolve => require(['@/pages/school/class'], resolve)
const NOTICE = resolve => require(['@/pages/school/notice'], resolve)
const PAPERS = resolve => require(['@/pages/school/papers'], resolve)
const classteacher = resolve => require(['@/pages/school/classteacher'], resolve)
const papersteacher = resolve => require(['@/pages/school/papersteacher'], resolve)
const noticeteacher = resolve => require(['@/pages/school/noticeteacher'], resolve)
const wteacher = resolve => require(['@/pages/school/wteacher'], resolve)
const sendnotice = resolve => require(['@/pages/school/sendnotice'], resolve)
const sendw = resolve => require(['@/pages/school/sendw'], resolve)
const sendpapers = resolve => require(['@/pages/school/sendpapers'], resolve)
const signin = resolve => require(['@/pages/school/signin'], resolve)

export default [
  {
    path: '/',
    meta: { auth: true, title: '微课程-' + _global.APPTITle },
    component: INDEX
  },
  {
    path: '/class/:id',
    meta: { auth: true, title: '我的课程-' + _global.APPTITle },
    component: CLASS
  },
  {
    path: '/notice/:id',
    meta: { auth: true, title: '公告预览-' + _global.APPTITle },
    component: NOTICE
  },
  {
    path: '/papers/:id',
    meta: { auth: true, title: '我的试卷-' + _global.APPTITle },
    component: PAPERS
  },
  {
    path: '/classteacher/:id',
    meta: { auth: true, title: '我的课程-' + _global.APPTITle },
    component: classteacher
  },
  {
    path: '/papersteacher/:id',
    meta: { auth: true, title: '试卷成绩-' + _global.APPTITle },
    component: papersteacher
  },
  {
    path: '/noticeteacher/:id',
    meta: { auth: true, title: '通知预览-' + _global.APPTITle },
    component: noticeteacher
  },
  {
    path: '/wteacher/:id',
    meta: { auth: true, title: '课件预览-' + _global.APPTITle },
    component: wteacher
  },
  {
    path: '/sendnotice/:id',
    meta: { auth: true, title: '发布通知-' + _global.APPTITle },
    component: sendnotice
  },
  {
    path: '/sendw/:id',
    meta: { auth: true, title: '发布课件-' + _global.APPTITle },
    component: sendw
  },
  {
    path: '/sendpapers/:id',
    meta: { auth: true, title: '发布试卷-' + _global.APPTITle },
    component: sendpapers
  },
  {
    path: '/signin/:id',
    meta: { auth: true, title: '签到-' + _global.APPTITle },
    component: signin
  }
]
