import Vue from 'vue'

export const USER_SIGNIN = 'USER_SIGNIN'
export const USER_SIGNOUT = 'USER_SIGNOUT'
export const USER_TOKEN = 'USERTOKEN'

export default {
  state: JSON.parse(window.localStorage.getItem(USER_TOKEN)) || {},
  mutations: {
    [USER_SIGNIN] (state, token) {
      console.log(token)
      window.localStorage.setItem(USER_TOKEN, JSON.stringify(token))
      Object.assign(state, token)
    },
    [USER_SIGNOUT] (state) {
      window.localStorage.removeItem(USER_TOKEN)
      Object.keys(state).forEach(k => Vue.delete(state, k))
    }
  },
  actions: {
    [USER_SIGNIN] ({commit}, token) {
      commit(USER_SIGNIN, token)
    },
    [USER_SIGNOUT] ({commit}) {
      commit(USER_SIGNOUT)
    }
  }
}
