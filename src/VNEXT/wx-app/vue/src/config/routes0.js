// // 首页
// const INDEX = resolve => require(['@/pages/school/index'], resolve)
// const FAXIAN = resolve => require(['@/pages/school/faxian'], resolve)
// const XIAOXI = resolve => require(['@/pages/school/xiaoxi'], resolve)
// const ADDCOURSE = resolve => require(['@/pages/school/addCourse'], resolve)
// export default [
//   {
//     path: '/login',
//     meta: { auth: false },
//     component: resolve => require(['../pages/login'], resolve)
//   },
//   {
//     path: '/',
//     meta: { auth: false, title: '首页-职业教育教学诊改系统' },
//     component: INDEX
//   },
//   {
//     path: '/faxian',
//     meta: { auth: false, title: '发现-职业教育教学诊改系统' },
//     component: FAXIAN
//   },
//   {
//     path: '/xiaoxi',
//     meta: { auth: false, title: '消息-职业教育教学诊改系统' },
//     component: XIAOXI
//   },
//   {
//     path: '/addCourse',
//     meta: { auth: false, title: '开课-职业教育教学诊改系统' },
//     component: ADDCOURSE
//   },
//   {
//     path: '/reg/:mobile',
//     meta: { auth: false },
//     component: resolve => require(['../pages/reg'], resolve)
//   },
//   {
//     path: '/downapp/:id',
//     meta: { auth: false },
//     component: resolve => require(['../pages/downapp'], resolve)
//   },
//   {
//     path: '/news/:type',
//     meta: { auth: false },
//     component: resolve => require(['../pages/news'], resolve)
//   },
//   {
//     path: '/infoDetails/:id',
//     meta: { auth: false },
//     component: resolve => require(['../pages/infoDetails'], resolve)
//   },
//   {
//     path: '/help',
//     meta: { auth: false },
//     component: resolve => require(['../pages/help'], resolve)
//   },
//   {
//     path: '/favorite',
//     meta: { auth: false },
//     component: resolve => require(['../pages/favorite'], resolve)
//   },
//   {
//     path: '/add',
//     meta: { auth: false },
//     component: resolve => require(['../pages/add'], resolve)
//   },
//   {
//     path: '/product/:type',
//     meta: { auth: false },
//     component: resolve => require(['../pages/product'], resolve)
//   },
//   {
//     path: '/productDetails/:id',
//     meta: { auth: false },
//     component: resolve => require(['../pages/productDetails'], resolve)
//   },
//   {
//     path: '/signout',
//     component: resolve => require(['../pages/signout'], resolve)
//   },
//   {
//     path: '/home',
//     component: resolve => require(['../pages/home'], resolve)
//   },
//   {
//     path: '/certified',
//     component: resolve => require(['../pages/certified'], resolve)
//   },
//   {
//     path: '/user',
//     component: resolve => require(['../pages/user'], resolve)
//   },
//   {
//     path: '/userInfo',
//     component: resolve => require(['../pages/userInfo'], resolve)
//   },
//   {
//     path: '/changeuserinfo',
//     component: resolve => require(['../pages/changeuserinfo'], resolve)
//   },
//   {
//     path: '/changepwd',
//     component: resolve => require(['../pages/changepwd'], resolve)
//   },
//   {
//     path: '/changepaypwd',
//     component: resolve => require(['../pages/changepaypwd'], resolve)
//   },
//   {
//     path: '/banklist',
//     component: resolve => require(['../pages/banklist'], resolve)
//   },
//   {
//     path: '/pointlist',
//     component: resolve => require(['../pages/pointlist'], resolve)
//   },
//   {
//     path: '/buylist',
//     component: resolve => require(['../pages/buylist'], resolve)
//   },
//   {
//     path: '*',
//     redirect: '/login'
//   }
// ]
