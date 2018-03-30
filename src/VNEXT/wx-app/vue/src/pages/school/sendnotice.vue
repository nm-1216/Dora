<template>
  <div class="sendNotice">
    <form v-on:submit.prevent="submit">
      <group title="标题（必填）">
        <x-input placeholder="" v-model="title"></x-input>
      </group>
      <group title="你可以向学生发送的文字">
        <x-textarea v-model="des"></x-textarea>
      </group>

      <div style="padding:30px 15px;background-color:#fff">
        <x-button type="warn">发送</x-button>
      </div>
    </form>
  </div>
</template>
<script>
import { XInput, XButton, Group, TransferDom, XTextarea } from 'vux'
import { SendNotice } from 'src/Api/api'

export default {
  directives: {
    TransferDom
  },
  components: {
    Group,
    XInput,
    XButton,
    XTextarea
  },
  data () {
    return {
      title: '',
      id: this.$route.params.id,
      des: ''
    }
  },
  created () {
  },
  methods: {
    submit () {
      if (!this.title || !this.des) {
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
      SendNotice({
        id: this.id,
        title: this.title,
        des: this.des,
        openId: this.$store.state.user.token
      }).then(response => {
        console.log(response.data)
        let vm = this
        if (response.data.result === 0) {
          this.$vux.alert.show({
            title: '提示',
            content: response.data.msg,
            onShow () {
            },
            onHide () {
              vm.$router.push(`/classteacher/${vm.id}`)
            }
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
<style type="text/css" scoped>
  .sendNotice{
    background-color: #f0f0f4;
    margin-top:-10px;
    padding-top:10px;
  }
</style>

