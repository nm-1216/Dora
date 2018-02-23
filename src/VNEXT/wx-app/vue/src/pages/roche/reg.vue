<template>
  <div class="reg">
    <form v-on:submit.prevent="submit">
      <group title="用户注册">
        <x-input title="昵称：" required v-model="form.NickName"></x-input>
        <x-input title="姓名：" required v-model="form.Name" is-type="china-name"></x-input>
        <popup-radio title="性别：" :options="['男', '女']" v-model="form.Sex"></popup-radio>
        <x-input title="手机：" required v-model="form.Tel" keyboard="number" is-type="china-mobile"></x-input>
        <x-input title="医院：" required v-model="form.Company"></x-input>
        <x-input title="科室：" required v-model="form.Room"></x-input>
        <x-input title="职务：" v-model="form.Position"></x-input>
        <x-input title="邮箱：" v-model="form.Email"></x-input>
        <x-input title="微博：" v-model="form.Weibo"></x-input>
        <x-input title="地区：" v-model="form.Area"></x-input>
      </group>
      <group title="个人简介">
        <x-textarea :max="20" v-model="form.Description"></x-textarea>
      </group>
      <group title="关注领域">
        <checker
        v-model="form.Specialties"
        type="checkbox"
        style="padding-left:10px;padding-bottom:10px;"
        default-item-class="demo5-item"
        selected-item-class="demo5-item-selected"
        >
          <checker-item :value="item" v-for="(item, index) in Specialties" :key="index">{{item.name}}</checker-item>
        </checker>
      </group>
      <div style="padding:30px 15px;">
        <x-button type="primary">{{ '注册' }}</x-button>
      </div>
    </form>
  </div>
</template>
<script>
import { PopupRadio, XTextarea, XInput, XButton, Cell, CellBox, CellFormPreview, Group, Badge, XHeader, Actionsheet, TransferDom, Checklist, Checker, CheckerItem } from 'vux'
import { GetSpecialty, Register } from 'src/Api/api'
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
    Cell,
    CellFormPreview,
    CellBox,
    Badge,
    XHeader,
    Actionsheet,
    XInput,
    XButton,
    Checklist,
    Checker,
    CheckerItem,
    XTextarea,
    PopupRadio
  },
  data () {
    return {
      form: {
        NickName: '',
        Name: '',
        Sex: '男',
        Tel: '',
        Company: '',
        Room: '',
        Position: '',
        Email: '',
        Weibo: '',
        Area: '',
        Description: '',
        Specialties: []
      },
      Specialties: [],
      openId: ''
    }
  },
  created () {
    this.openId = cookies.getCookie('openId')
    console.log('openId', this.openId)
    GetSpecialty().then(response => {
      console.log('GetSpecialty', response.data)
      this.Specialties = response.data
    })
  },
  methods: {
    ...mapActions([USER_SIGNIN]),
    submit () {
      if (!this.form.NickName || !this.form.Name || !this.form.Sex || !this.form.Tel || !this.form.Company || !this.form.Room) {
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

<style scoped>
.demo5-item {
  width: 100px;
  height: 30px;
  line-height: 30px;
  text-align: center;
  border-radius: 3px;
  border: 1px solid #ccc;
  background-color: #fff;
  margin-right: 10px;
  margin-top: 10px;
}
.demo5-item-selected {
  background: #ffffff url(../../assets/checker/active.png) no-repeat right bottom;
  border-color: #ff4a00;
}
</style>
