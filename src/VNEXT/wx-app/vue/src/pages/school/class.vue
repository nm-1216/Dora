<template>
<div class="_class">
  <div style="position:relative">
    <img :src="kc1" style="width:100%"/>
    <div class="today"><span class="d1">{{today.getDate()}}</span><span class="d2">/</span><span class="d3">{{today.getMonth()+1}}月</span></div>
  </div>
  <div>
    <tab :line-width="1"  bar-active-color="#639ef4">
      <tab-item selected active-class="active-6-1"  @on-item-click="onItemClick">教学日志</tab-item>
      <tab-item active-class="active-6-1" @on-item-click="onItemClick">我的同学</tab-item>
      <tab-item active-class="active-6-1" @on-item-click="onItemClick">我的签到</tab-item>
    </tab>
  </div>
  <div>
    <div class="tab0 tabcontent" v-show= 'showtab1'>
      <div class="timeline-demo">
      <timeline>
      <timeline-item v-for="(item, index) in list" :key="index">
        <p v-show="item.types===0"><span class="c_1">公 告</span> {{item.createTimeTimeStamp | formatDate}}</p>
        <p v-show="item.types===1"><span class="c_2">课 件</span> {{item.createTimeTimeStamp | formatDate}}</p>
        <p v-show="item.types===2"><span class="c_3">试 卷</span> {{item.createTimeTimeStamp | formatDate}}</p>
        <div class="msg" @click="toNotice(item)">{{item.name}}</div>
      </timeline-item>
      </timeline>
      </div>
    </div>
    <div class="tab1 tabcontent" v-show= 'showtab2'>
      <grid :show-lr-borders="false" :cols="4">
        <grid-item :label="item.name" v-for="(item,index) in students" :key="index">
          <img slot="icon" src="../../assets/3b.png">
        </grid-item>
      </grid>
    </div>
    <div class="tab2 tabcontent" v-show= 'showtab3'>
      <div style="padding:15px 15px">
        <div class="progress">
          <div class="progress-bar progress-bar-success" style="width: 30%">
            <span class="sr-only">正常(15)</span>
          </div>
          <div class="progress-bar progress-bar-warning progress-bar-striped" style="width: 20%">
            <span class="sr-only">请假(10)</span>
          </div>
          <div class="progress-bar progress-bar-danger" style="width: 10%">
            <span class="sr-only">旷课(5)</span>
          </div>
        </div>
      </div>

      <grid :show-lr-borders="false" :cols="3">
        <grid-item v-for="(item,index) in QD" :key="index">
          <span slot="label">{{item.text}}<br/><i style="color:#999;font-size:12px">180412-1</i></span>
          <x-icon v-if="item.type === 1" slot="icon" type="ios-checkmark" size="30"></x-icon>
          <x-icon v-if="item.type === 2" slot="icon" type="ios-information" size="30"></x-icon>
          <x-icon v-if="item.type === 3" slot="icon" type="ios-minus" size="30"></x-icon>
          <x-icon v-if="item.type === 4" slot="icon" type="ios-close" size="30"></x-icon>
        </grid-item>
      </grid>

    </div>
  </div>
</div>
</template>

<script>
import { Timeline, TimelineItem, Tab, TabItem, Group, Grid, GridItem } from 'vux'
import { GetClassCourse } from 'src/Api/api'
import { formatDate } from 'src/filters/date.js'
import 'src/assets/css/progress.css'
var kc1 = require('src/assets/kc1.png')

export default {
  components: {
    Tab, TabItem, Group, Timeline, TimelineItem, Grid, GridItem
  },
  methods: {
    onItemClick (index) {
      console.log('on item click:', index)
      this.showtab1 = false
      this.showtab2 = false
      this.showtab3 = false

      if (index === 0) {
        this.showtab1 = true
      }
      if (index === 1) {
        this.showtab2 = true
      }
      if (index === 2) {
        this.showtab3 = true
      }
    },
    toNotice (obj) {
      console.log('toNotice', obj)
      this.$router.push(`/notice/${obj.learnLogId}`)
    }
  },
  data () {
    return {
      showtab1: true,
      showtab2: false,
      showtab3: false,
      students: [],
      list: [],
      // QD: [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24],
      QD: [ {text: '正常', type: 1}, {text: '迟到', type: 2}, {text: '请假', type: 3}, {text: '旷课', type: 4} ],
      kc1,
      today: new Date(),
      id: this.$route.params.id
    }
  },
  filters: {
    formatDate (time) {
      return formatDate(time, 'yyyy-MM-dd EE mm:ss')
    }
  },
  created () {
    GetClassCourse({'openId': this.$store.state.user.token, 'id': this.id}).then(response => {
      console.log(response.data)
      if (response.data.result === 0) {
        this.students = response.data.data.students
        this.list = response.data.data.list
      }
    })
  }
}
</script>
<style type="text/css" lang="less">
  .vux-timeline-item-tail,.vux-timeline-item-color{
    background-color: #639ef4!important;
  }
</style>

<style type="text/css" lang="less" scoped>
  .today{
    position: absolute;
    width: 100%;
    left: 0;
    top: 0;
    text-align: center;
    padding-top: 25px;
    color: #fff;
  }
  .today .d1{
    font-size:3rem;
    font-weight: bold;
  }
  .today .d2{
    font-size:3rem;
    font-weight: bold;
  }
  .today .d3{
    font-size:1.5rem;
    font-weight: bold;
  }
  .timeline-demo {
      span.c_1{
        BORDER: 1PX SOLID #FF6666;
        color:#FF6666
      }
      span.c_2{
        BORDER: 1PX SOLID #99CC66;
        color:#99CC66
      }
      span.c_3{
        BORDER: 1PX SOLID #0066CC;
        color:#0066CC
      }
      .recent {
          color: rgb(4, 190, 2)
      }
      div.msg {
        border: 1px solid;
        border-color: #efefef;
        margin-top: 10px;
        padding: 15px 5px;
        background-color: #f0f0f4;
      }
  }
  .vux-x-icon-ios-checkmark,.vux-x-icon-ios-information {
    fill: green;
  }
  .vux-x-icon-ios-minus,.vux-x-icon-ios-close {
    fill: #F70968;
  }
</style>
<style type="text/css">
</style>