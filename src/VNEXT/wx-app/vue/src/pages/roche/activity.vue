<template>
<div class="activity">
  <div class="weui-panel weui-panel_access" v-for="(item,index) in activity" :key="index">
    <div class="weui-panel__hd" @click="GoActivityDetails(item.activityId)">{{item.title}}</div>
    <div class="weui-panel__bd">
      <a href="" class="weui-media-box weui-media-box_appmsg">
        <div class="weui-media-box__hd">
          <div class="weui-media-box__thumb" :style="'background-image:url('+vm.global.DOMAIN +item.img+')'">
          </div>
        </div>
        <div class="weui-media-box__bd">
          <p class="weui-media-box__desc"><i class="glyphicon glyphicon-time"></i> {{item.activityTime}}</p>
          <p class="weui-media-box__desc"><i class="glyphicon glyphicon-map-marker"></i> {{item.site}}</p>
          <p class="weui-media-box__desc"><i class="glyphicon glyphicon-user"></i> 30人报名</p>
          <p class="weui-media-box__desc"><i class="glyphicon glyphicon-user"></i> 我已经报名</p>
        </div>
      </a>
    </div>
  </div>
  <div style="display:none">
    <panel
    :list="[]"
    :type="'1'"
    ></panel>
  </div>


</div>
</template>

<script>
import { GetActivity } from 'src/Api/api'

import {
  Swiper,
  SwiperItem,
  XButton,
  Box,
  GroupTitle,
  Group,
  Flexbox,
  FlexboxItem,
  Divider,
  Panel
} from 'vux'

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
    Divider,
    Panel
  },
  data () {
    return {
      activity: [],
      vm: this
    }
  },
  created () {
    this.GetList()
  },
  methods: {
    GetList () {
      GetActivity({openid: this.$store.state.user.token}).then(response => {
        // var vm = this
        console.log('GetActivity', response.data)
        this.activity = response.data.data
        // this.user = response.data.data.wxUser
        // var xx = this.user.specialties
      })
    },
    GoActivityDetails (id) {
      this.$router.push(`/activitydetails/${id}`)
    }
  }
}
</script>
<style lang="less">
@import '~vux/src/styles/1px.less';
/* @import 'src/assets/Glyphicons/Glyphicons.css'; */



.activity .weui-media-box__desc{line-height:2}
.activity .weui-media-box__desc i{color:#888;font-size:12px;}
.activity .weui-media-box_appmsg .weui-media-box__hd{width:100px;height:100px;line-height:100px;}
.activity .weui-media-box_appmsg .weui-media-box__thumb{min-height:100%;background-size:cover;background-position:center center}


</style>
