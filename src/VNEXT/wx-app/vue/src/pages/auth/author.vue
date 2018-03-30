<template>
<div>
</div>
</template>

<script>
import cookies from 'src/common/cookies'
import {
  mapActions
} from 'vuex'
import {
  USER_SIGNIN
} from 'src/store/user'
export default {
  created () {
    var isLogin = Boolean(this.$store.state.user.token)
    var openId = this.$route.params.openId
    var existsUser = this.$route.params.existsUser
    console.log('isLogin', isLogin)
    console.log('openId', openId)
    console.log('existsUser1', existsUser)
    if (openId === undefined || existsUser === undefined) {
      if (process.env.NODE_ENV === 'development') {
        // console.log('写OPENID')
        // cookies.setCookie('openId', 'oi5_2t4H7dLUWvvdk6OI1zOA3Qba', 10 * 60 * 1000)
        // this.$router.replace({
        //   path: '/reg'
        // })

        // this.Login('oq90mwOVwiR40sSR9e0bRTQb6xJ8', '老师')
        this.Login('oi5_2t4H7dLUWvvdk6OI1zOA3Qbg', '学生')
      }
      if (!isLogin) {
        let ua = window.navigator.userAgent.toLowerCase()
        if ((/micromessenger/i).test(ua)) {
          window.location.href = this.global.OAUTH2
        }
      }
    } else {
      this.Login(openId, existsUser)
    }
  },
  methods: {
    ...mapActions([USER_SIGNIN]),
    Login (openId, existsUser) {
      if (existsUser !== '0') {
        this.USER_SIGNIN({
          'token': openId,
          'userId': existsUser
        })
        this.$router.replace({
          path: '/'
        })
      } else {
        cookies.setCookie('openId', openId, 10 * 60 * 1000)
        this.$router.replace({
          path: '/reg'
        })
      }
    }
  }
}
</script>
