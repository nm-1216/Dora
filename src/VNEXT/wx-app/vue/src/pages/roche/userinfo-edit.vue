<template>
  <div class="reg">
    <form v-on:submit.prevent="submit">
      <group title="用户注册">
        <x-input title="昵称：" required v-model="form.nickName"></x-input>
        <x-input title="姓名：" required v-model="form.name" is-type="china-name"></x-input>
        <popup-radio title="性别：" :options="['男', '女']" v-model="form.sex"></popup-radio>
        <x-input title="手机：" required v-model="form.tel" keyboard="number" is-type="china-mobile"></x-input>
        <x-input title="医院：" required v-model="form.company"></x-input>
        <x-input title="科室：" required v-model="form.room"></x-input>
        <x-input title="职务：" v-model="form.position"></x-input>
        <x-input title="邮箱：" v-model="form.email"></x-input>
        <x-input title="微博：" v-model="form.weibo"></x-input>
      </group>
      <group title="地区">
        <x-address @on-hide="logHide" v-model="area" title="地区" :raw-value="true" :list="addressData"></x-address>
      </group>
      <group title="个人简介">
        <x-textarea :max="20" v-model="form.description"></x-textarea>
      </group>
      <group title="关注领域">
        <checker
        v-model="form.specialties"
        type="checkbox"
        style="padding-left:10px;padding-bottom:10px;"
        default-item-class="demo5-item"
        selected-item-class="demo5-item-selected"
        >
          <checker-item :value="item" v-for="(item, index) in Specialties" :key="index">{{item.name}}</checker-item>
        </checker>
      </group>
      <div style="padding:30px 15px;">
        <x-button type="warn">{{ '保存' }}</x-button>
      </div>
    </form>
  </div>
</template>
<script>
import { PopupRadio, XAddress, ChinaAddressV4Data, Value2nameFilter as value2name, XTextarea, XInput, XButton, Cell, CellBox, CellFormPreview, Group, Badge, XHeader, Actionsheet, TransferDom, Checklist, Checker, CheckerItem } from 'vux'
import { GetSpecialty, GetUserInfo, EditUserInfo } from 'src/Api/api'

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
    PopupRadio,
    XAddress
  },
  data () {
    return {
      form: {
        nickName: '',
        name: '',
        sex: '男',
        tel: '',
        company: '',
        room: '',
        position: '',
        email: '',
        weibo: '',
        area: '',
        description: '',
        specialties: []
      },
      Specialties: [],
      addressData: ChinaAddressV4Data,
      showAddress: false,
      area: []
    }
  },
  created () {
    GetSpecialty().then(response => {
      console.log('GetSpecialty', response.data)
      this.Specialties = response.data
    })
    // this.area= this.addressData.find(function(x) {return x.value = '110113'})
    console.log('addressData', this.addressData)
    this.GetList()
  },
  methods: {
    GetList () {
      GetUserInfo({openid: this.$store.state.user.token}).then(response => {
        console.log('GetUserInfo', response.data)
        this.form = response.data.data.wxUser
        console.log('this.form', this.form)
        if (this.form.area) {
          console.log('hwx', this.form.area.replace(/(\d\d\d\d)\d\d/ig, '$1' + '00'))
          this.area = [this.form.area.replace(/(\d\d)\d\d\d\d/ig, '$1' + '0000'), this.form.area.replace(/(\d\d\d\d)\d\d/ig, '$1' + '00'), this.form.area]
        }
        var xx = this.form.specialties
        var xx2 = xx.slice(0)
        xx.splice(0, xx.length)
        xx2.forEach(
          function (value, index) {
            xx.push({specialtyId: value.specialtyId, name: value.specialty.name})
          })
      })
    },
    getName (value) {
      return value2name(value, ChinaAddressV4Data)
    },
    logHide (str) {
      console.log('on-hide', str)
      console.log('area', this.area)
    },
    submit () {
      if (this.area !== null && this.area.length === 3) {
        this.form.area = this.area[2]
      }
      if (!this.form.nickName || !this.form.name || !this.form.sex || !this.form.tel || !this.form.company || !this.form.room) {
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
      EditUserInfo({
        model: this.form
      }).then(response => {
        console.log(response.data)
        if (response.data.result === 0) {
          var vm = this
          this.$vux.alert.show({
            title: '提示',
            content: response.data.msg,
            onShow () {
            },
            onHide () {
              vm.$router.replace({
                path: '/userinfo'
              })
            }
          })
        } else {
          this.$vux.alert.show({
            title: '提示',
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
