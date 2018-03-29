import _global from '../config/global'
const AUTHOR = resolve => require(['src/pages/auth/author'], resolve)
const REG = resolve => require(['src/pages/auth/reg'], resolve)

export default [
  {
    path: '/author',
    meta: { auth: false, title: 'Auto Login-' + _global.APPTITle },
    component: AUTHOR
  },
  {
    path: '/author/:openId/:existsUser',
    meta: { auth: false, title: 'Auto Login-' + _global.APPTITle },
    component: AUTHOR
  },
  {
    path: '/reg',
    meta: { auth: false, title: 'Binding user-' + _global.APPTITle },
    component: REG
  }
]
