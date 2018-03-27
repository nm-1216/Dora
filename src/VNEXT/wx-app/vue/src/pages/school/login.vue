<template>
  <div>
    <form class="login" v-on:submit.prevent="submit">
      <group label-width="4.5em" label-margin-right="2em" label-align="right">
        <x-input title="用户名" placeholder="手机号码" type="tel" v-model="form.user"></x-input>
        <cell-box v-show="btn && !form.user">用户名不能为空</cell-box>
        <x-input title="密&#12288;码" type="password" placeholder="必填" v-model="form.pwd"></x-input>
        <cell-box v-show="btn && !form.pwd">密码不能为空</cell-box>
        <cell-box></cell-box>
      </group>
      <div style="padding:30px 15px;">
        <x-button type="primary">{{ '登录' }}</x-button>
      </div>
    </form>
  </div>
</template>
<script>
import { XInput, XButton, Cell, CellBox, CellFormPreview, Group, Badge, XHeader, Actionsheet, TransferDom } from 'vux'
import { Login } from '../../Api/api'
import { mapActions } from 'vuex'
import { USER_SIGNIN } from '../../store/user'
export default {
  directives: {
    TransferDom
  },
  components: {
    Group,
    Cell,
    CellFormPreview,
    CellBox,
    Badge,
    XHeader,
    Actionsheet,
    XInput,
    XButton
  },
  data () {
    return {
      btn: false,
      form: {
        user: '',
        pwd: ''
      }
    }
  },
  methods: {
    ...mapActions([USER_SIGNIN]),
    submit () {
      this.btn = true
      if (!this.form.user || !this.form.pwd) return
      Login({'uid': this.form.user, 'pwd': this.form.pwd}).then(response => {
        console.log(response.data)
        if (response.data.result === 1) {
          var token = response.data.date.token
          var mobile = response.data.date.mobile
          this.USER_SIGNIN({'token': token, 'mobile': mobile})
          this.$router.replace({ path: '/home' })
        } else {
          this.$vux.alert.show({
            title: '异常提示',
            content: response.data.msg,
            onShow () {
              console.log('Plugin: I\'m showing')
            },
            onHide () {
              console.log('Plugin: I\'m hiding now')
            }
          })
        }
      })
    }
  }
}
</script>

<style>
.vux-cell-box div{
  text-align: right;
  width:100%;
  color:#c00
}

.login .weui-cells:after, .login .weui-cells:before{
  border:0;
  color:fff;
}
.login .weui-cell:after, .login .weui-cell:before{
  right: 15px;
}
</style>
