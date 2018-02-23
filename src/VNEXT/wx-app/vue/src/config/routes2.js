export default [
  {
    path: '/login',
    meta: { auth: false },
    component: resolve => require(['@/pages/school/login'], resolve)
  },
  {
    path: '/',
    meta: { auth: false, title: '首页-职业教育教学诊改系统' },
    component: resolve => require(['@/pages/school/index'], resolve)
  },
  {
    path: '/faxian',
    meta: { auth: false, title: '发现-职业教育教学诊改系统' },
    component: resolve => require(['@/pages/school/faxian'], resolve)
  },
  {
    path: '/xiaoxi',
    meta: { auth: false, title: '消息-职业教育教学诊改系统' },
    component: resolve => require(['@/pages/school/xiaoxi'], resolve)
  },
  {
    path: '/addCourse',
    meta: { auth: false, title: '开课-职业教育教学诊改系统' },
    component: resolve => require(['@/pages/school/addCourse'], resolve)
  },
  {
    path: '*',
    redirect: '/login'
  }
]
