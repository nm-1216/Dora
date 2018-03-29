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

export default [
  {
    path: '/',
    meta: { auth: true, title: '首页-' + _global.APPTITle },
    component: INDEX
  },
  {
    path: '/class/:classId/:courseId',
    meta: { auth: false, title: '课程-' + _global.APPTITle },
    component: CLASS
  },
  {
    path: '/notice/:id',
    meta: { auth: false, title: '公告-' + _global.APPTITle },
    component: NOTICE
  },
  {
    path: '/papers/:id',
    meta: { auth: false, title: '试卷-' + _global.APPTITle },
    component: PAPERS
  },
  {
    path: '/classteacher/:classId/:courseId',
    meta: { auth: false, title: '课程-' + _global.APPTITle },
    component: classteacher
  },
  {
    path: '/papersteacher/:id',
    meta: { auth: false, title: '试卷-' + _global.APPTITle },
    component: papersteacher
  },
  {
    path: '/noticeteacher/:id',
    meta: { auth: false, title: '通知-' + _global.APPTITle },
    component: noticeteacher
  },
  {
    path: '/wteacher/:id',
    meta: { auth: false, title: '课件-' + _global.APPTITle },
    component: wteacher
  },
  {
    path: '/sendnotice/:classId/:courseId',
    meta: { auth: false, title: '通知-' + _global.APPTITle },
    component: sendnotice
  },
  {
    path: '/sendw/:classId/:courseId',
    meta: { auth: false, title: '发布课件-' + _global.APPTITle },
    component: sendw
  },
  {
    path: '/sendpapers/:classId/:courseId',
    meta: { auth: false, title: '发布试卷-' + _global.APPTITle },
    component: sendpapers
  }
]
