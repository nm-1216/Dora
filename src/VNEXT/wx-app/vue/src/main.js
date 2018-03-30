import Vue from 'vue'
import VueRouter from 'vue-router'
import App from './App'
import Vuex from 'vuex'
import cookies from './common/cookies'
import routesAuth from './routes/auth'
import routesSchool from './routes/school'
import routesTemplate from './routes/template'
import store from './store/'
import { LocalePlugin, DevicePlugin, ToastPlugin, AlertPlugin, ConfirmPlugin, LoadingPlugin, WechatPlugin, AjaxPlugin } from 'vux'
import FastClick from 'fastclick'
import global_ from './config/global'

Vue.use(VueRouter)
Vue.use(Vuex)
Vue.use(require('vue-wechat-title'))

store.registerModule('vux', {
  state: {
    demoScrollTop: 0,
    isLoading: false,
    direction: 'forward'
  },
  mutations: {
    updateDemoPosition (state, payload) {
      state.demoScrollTop = payload.top
    },
    updateLoadingStatus (state, payload) {
      state.isLoading = payload.isLoading
    },
    updateDirection (state, payload) {
      state.direction = payload.direction
    }
  },
  actions: {
    updateDemoPosition ({ commit }, top) {
      commit({ type: 'updateDemoPosition', top: top })
    }
  }
})

Vue.use(DevicePlugin)
Vue.use(ToastPlugin)
Vue.use(AlertPlugin)
Vue.use(ConfirmPlugin)
Vue.use(LoadingPlugin)
Vue.use(WechatPlugin)
Vue.use(AjaxPlugin)
Vue.use(LocalePlugin)

FastClick.attach(document.body)
Vue.config.productionTip = false

const router = new VueRouter({
  routes: routesAuth.concat(routesSchool).concat(routesTemplate)
})
// console.log(router)

router.beforeEach(({ meta, path }, from, next) => {
  store.commit('updateLoadingStatus', { isLoading: true })
  var { auth = true } = meta
  var isLogin = Boolean(store.state.user.token)
  if (auth && !isLogin && !/author/i.test(path)) {
    cookies.setCookie('beforeLoginUrl', path, 3 * 60 * 1000)
    return next({ path: '/author' })
  }
  next()
})

router.afterEach(function (to) {
  store.commit('updateLoadingStatus', { isLoading: false })
})

Vue.directive('title', {
  inserted: function (el, binding) {
    document.title = el.innerText
    el.remove()
  }
})

Vue.prototype.global = global_

new Vue({
  store,
  router,
  render: h => h(App)
}).$mount('#app-box')
