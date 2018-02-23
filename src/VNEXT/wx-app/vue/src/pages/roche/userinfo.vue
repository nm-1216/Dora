<template>
  <div class="userinfo">
      <group :title="('我的资料')">
        <cell title="昵称：" is-link :value="user.nickName"></cell>
        <cell title="姓名：" is-link :value="user.name"></cell>
        <cell title="性别：" is-link :value="user.sex"></cell>
        <cell title="手机：" is-link :value="user.tel"></cell>
        <cell title="医院：" is-link :value="user.company"></cell>
        <cell title="科室：" is-link :value="user.room"></cell>
        <cell title="职务：" is-link :value="user.position"></cell>
        <cell title="邮箱：" is-link :value="user.email"></cell>
        <cell title="微博：" is-link :value="user.weibo"></cell>
        <cell title="地区：" is-link :value="getName(area)"></cell>
      </group>
      <group title="个人简介">
        <x-textarea :readonly="true" v-model="user.description" :show-counter="false"></x-textarea>
      </group>
      <group title="关注领域">
        <checker
        type="checkbox"
        v-model="spe"
        style="padding-left:10px;padding-bottom:10px;"
        default-item-class="demo5-item"
        selected-item-class="demo5-item-selected"
        >
          <checker-item :value="item" v-for="item in Specialties" :key="item.name" :disabled="true">{{item.name}}</checker-item>
        </checker>
      </group>
      <div style="padding:20px 8px 50px 8px">
        <x-button @click.native="GoUrl" type="primary">修改</x-button>
        <x-button @click.native="LogOut" type="primary">退出</x-button>
      </div>
  </div>
</template>
<script>
import { XButton, XTextarea, Cell, Group, TransferDom, Checker, ChinaAddressV4Data, Value2nameFilter as value2name, CheckerItem } from 'vux'
import { GetSpecialty, GetUserInfo } from 'src/Api/api'
import {
  mapActions
} from 'vuex'
import {
  USER_SIGNOUT
} from 'src/store/user'

export default {
  directives: {
    TransferDom
  },
  components: {
    XButton,
    Group,
    Cell,
    Checker,
    CheckerItem,
    XTextarea
  },
  data () {
    return {
      user: {
        NickName: '',
        Name: '',
        Sex: '男',
        Tel: '',
        Company: '',
        Room: '',
        Position: '',
        Email: '',
        Weibo: '',
        area: '',
        Description: '',
        Specialties: []
      },
      Specialties: [],
      spe: [],
      area: []
    }
  },
  created () {
    GetSpecialty().then(response => {
      console.log('GetSpecialty', response.data)
      this.Specialties = response.data
    })
    this.GetList()
  },
  methods: {
    ...mapActions([USER_SIGNOUT]),
    GetList () {
      GetUserInfo({openid: this.$store.state.user.token}).then(response => {
        var vm = this
        console.log('GetUserInfo', response.data)
        this.user = response.data.data.wxUser
        if (this.user.area) {
          this.area = [this.user.area.replace(/(\d\d)\d\d\d\d/ig, '$1' + '0000'), this.user.area.replace(/(\d\d\d\d)\d\d/ig, '$1' + '00'), this.user.area]
        }
        var xx = this.user.specialties
        xx.forEach(
          function (value, index) {
            vm.spe.push({specialtyId: value.specialtyId, name: value.specialty.name})
          })
      })
    },
    GoUrl () {
      this.$router.push('/edituserinfo')
    },
    LogOut () {
      this.USER_SIGNOUT()
    },
    getName (value) {
      return value2name(value, ChinaAddressV4Data)
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
