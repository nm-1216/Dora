import _global from '../config/global'

const BASE = resolve => require(['src/pages/template/base'], resolve)

export default [
  {
    path: '/base',
    meta: { auth: false, title: 'BASE-' + _global.APPTITle },
    component: BASE
  }
]
