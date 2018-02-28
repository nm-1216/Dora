<template>
  <div class="reg">
    <form v-on:submit.prevent="submit">
      <group title="用户绑定">
        <x-input title="账号：" v-model="form.user"></x-input>
        <x-input title="密码：" v-model="form.pwd"></x-input>
      </group>
      <div style="padding:30px 15px;">
        <x-button type="primary">用户绑定</x-button>
      </div>
    </form>
  </div>
</template>
<script>
import { XInput, XButton, Group, TransferDom } from 'vux'
import { Register } from 'src/Api/api'
import cookies from 'src/common/cookies'
import {
  mapActions
} from 'vuex'
import {
  USER_SIGNIN
} from 'src/store/user'

export default {
  directives: {
    TransferDom
  },
  components: {
    Group,
    XInput,
    XButton
  },
  data () {
    return {
      form: {
        user: '',
        pwd: ''
      },
      Specialties: [],
      openId: ''
    }
  },
  created () {
    this.openId = cookies.getCookie('openId')
    if (this.openId === null) {
      this.$router.replace({ path: '/' })
    }
    console.log('openId', this.openId)
  },
  methods: {
    ...mapActions([USER_SIGNIN]),
    submit () {
      if (!this.form.user || !this.form.pwd) {
        console.log('form', this.form)
        console.log('提交失败：必填项未填')
        this.$vux.alert.show({
          title: '提交失败',
          content: '必填项未填',
          onShow () {
            console.log('')
          },
          onHide () {
            console.log('')
          }
        })
        return
      }
      Register({
        model: this.form,
        openId: this.openId
      }).then(response => {
        console.log(response.data)
        if (response.data.result === 0) {
          this.USER_SIGNIN({
            'token': this.openId,
            'mobile': 1
          })
          this.$router.replace({
            path: '/'
          })
        } else {
          this.$vux.alert.show({
            title: '异常提示',
            content: response.data.msg,
            onShow () {
            },
            onHide () {
            }
          })
        }
      })
    }
  }
}
</script>
