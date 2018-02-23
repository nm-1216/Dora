<template>
  <div class="index">
    <swiper :aspect-ratio="300/800">
      <swiper-item class="swiper-demo-img" v-for="(item, index) in demo04_list" :key="index"><img :src="item"></swiper-item>
    </swiper>
    <div class="user">
      <flexbox :gutter="0" wrap="wrap" >
        <flexbox-item :span="3">
          <div class="flex-demo tuxiang">
            <div></div>
          </div>
        </flexbox-item>
        <flexbox-item :span="6">
          <div @click="GoUserInfo" class="" style="text-align:left">
            {{this.user.name}}
          </div>
        </flexbox-item>
        <flexbox-item :span="3">
          <div class="flex-demo tuxiang1"></div>
        </flexbox-item>
      </flexbox>
    </div>
    <div class="utils">
      <flexbox :gutter="0" wrap="wrap">
        <flexbox-item :span="4">
          <div class="flex-demo1" @click="GoActivity">
            <img src="../../assets/index/1.png"/>
            <span>会议中心</span>
          </div>
        </flexbox-item>
        <flexbox-item :span="4">
          <div class="flex-demo1">
            <img src="../../assets/index/2.png"/>
            <span>医学文献</span>
          </div>
        </flexbox-item>
        <flexbox-item :span="4">
          <div class="flex-demo1">
            <img src="../../assets/index/3.png"/>
            <span>医学问询</span>
          </div>
        </flexbox-item>
      </flexbox>
      <flexbox :gutter="0" wrap="wrap" style="padding-top:30px;">
        <flexbox-item :span="4">
          <div class="flex-demo1">
            <img src="../../assets/index/4.png"/>
            <span>AE报告</span>
          </div>
        </flexbox-item>
        <flexbox-item :span="4">
          <div class="flex-demo1">
            <img src="../../assets/index/5.png"/>
            <span>医学工具包</span>
          </div>
        </flexbox-item>
        <flexbox-item :span="4">
          <div class="flex-demo1">
            <img src="../../assets/index/6.png"/>
            <span>琢学成章</span>
          </div>
        </flexbox-item>
      </flexbox>
      <flexbox :gutter="0" wrap="wrap" style="padding-top:30px;">
        <flexbox-item :span="4">
          <div class="flex-demo1">
            <img src="../../assets/index/1.png"/>
            <span>会议中心</span>
          </div>
        </flexbox-item>
        <flexbox-item :span="4">
          <div class="flex-demo1">
            <img src="../../assets/index/2.png"/>
            <span>医学文献</span>
          </div>
        </flexbox-item>
        <flexbox-item :span="4">
          <div class="flex-demo1">
            <img src="../../assets/index/3.png"/>
            <span>医学问询</span>
          </div>
        </flexbox-item>
      </flexbox>
    </div>
  </div>
</template>

<script>
import { Swiper, SwiperItem, XButton, Box, GroupTitle, Group, Flexbox, FlexboxItem, Divider } from 'vux'
import { GetUserInfo } from 'src/Api/api'
import {
  mapActions
} from 'vuex'
import { USER_SIGNOUT } from 'src/store/user'
var img1 = require('src/assets/swiper/1.png')
var img2 = require('src/assets/swiper/2.png')
var img3 = require('src/assets/swiper/3.png')
var topbg = require('src/assets/index/top_bg.png')

const imgList = [
  img1,
  img2,
  img3
]

export default {
  components: {
    Swiper,
    SwiperItem,
    XButton,
    Box,
    GroupTitle,
    Group,
    Flexbox,
    FlexboxItem,
    Divider
  },
  methods: {
    ...mapActions([USER_SIGNOUT]),
    change (value) {
      console.log('change:', value)
    },
    GoUserInfo () {
      this.$router.push('/userinfo')
    },
    GoActivity () {
      this.$router.push('/activity')
    },
    GetUser () {
      GetUserInfo({openid: this.$store.state.user.token}).then(response => {
        // var vm = this
        console.log('GetUserInfo', response.data)
        this.user = response.data.data.wxUser
        // var xx = this.user.specialties
        // xx.forEach(
        //   function (value, index) {
        //     vm.spe.push({specialtyId: value.specialtyId, name: value.specialty.name})
        //   })
      })
    }
  },
  data () {
    return {
      user: {name: ''},
      submit001: 'click me',
      disable001: false,
      demo04_list: imgList,
      img: {top_bg: topbg}
    }
  },
  created () {
    this.GetUser()
  }
}
</script>
<style scoped>
.swiper-demo-img img {
  width: 100%;
}
.user{
  background-color: #fff;
  background-size: contain;
  background-repeat: no-repeat;
  background-position: center bottom;
  background-image: url('../../assets/index/top_bg.png');
  height: 100px;
}
</style>
<style lang="less">
.flex-demo {
  text-align:center;
  color: #fff;
}
.tuxiang {
  height:68px;
  margin-top:10px;
  background-color: #fff;
  background-size: contain;
  background-repeat: no-repeat;
  background-position: center center;
  background-image: url('../../assets/index/avatar_no.png');
}
.tuxiang div{
  height:68px;
  width:60%;
  margin:0 auto;
  background-size: 100%;
  background-repeat: no-repeat;
  background-position: center bottom;
  background-image: url('../../assets/index/avatar.png');
}

.tuxiang1{
  height:68px;
  margin-top:10px;
  background-color: #fff;
  background-size: auto 30%;
  background-repeat: no-repeat;
  background-position: center center;
  background-image: url('../../assets/index/arrow.png');
}

.flex-demo1 {
  text-align: center;
  color: #000;
}
.utils{
  background-color:#fff;
  background-size: 100% auto;
  background-repeat: no-repeat;
  background-position: center bottom;
  background-image: url('../../assets/index/b.png');
  padding-top:20px;
  padding-bottom:90px;
}
.utils .flex-demo1 img{
  display:block;
  margin:0 auto;
  width:50%;
}
.utils .flex-demo1 span{
  line-height:2.5;
}
.footer{
  margin-top:10px;
}
</style>
