<template>
<div>
  <div style="position:relative">
    <img :src="kc1" style="width:100%"/>
    <div class="today"><span class="d1">{{today.getDate()}}</span><span class="d2">/</span><span class="d3">{{today.getMonth()+1}}月</span></div>
  </div>
  <div>
    <tab :line-width="1" bar-active-color="#639ef4">
      <tab-item selected active-class="active-6-1"  @on-item-click="onItemClick">教学日志</tab-item>
      <tab-item active-class="active-6-1" @on-item-click="onItemClick">班级学生</tab-item>
    </tab>
  </div>
  <div>
    <div class="tab0 tabcontent" v-show= 'showtab1'>
      <div class="add">
        <i @click="downMeau" class="glyphicon glyphicon-plus-sign"></i>
      </div>
      <div class="timeline-demo">
        <timeline>
          <timeline-item v-for="(item, index) in list" :key="index">
            <p v-show="item.types===0"><span class="c_1">公告</span> {{item.createTimeTimeStamp | formatDate}}</p>
            <p v-show="item.types===1"><span class="c_2">课件</span> {{item.createTimeTimeStamp | formatDate}}</p>
            <p v-show="item.types===2"><span class="c_3">试卷</span> {{item.createTimeTimeStamp | formatDate}}</p>
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
  </div>
  <actionsheet v-model="show1" :menus="menus1" @on-click-menu="actionsheetclick"></actionsheet>
</div>
</template>

<script>
import { Timeline, TimelineItem, Tab, TabItem, Group, Grid, GridItem, Actionsheet } from 'vux'
import { GetClassCourse } from 'src/Api/api'
import { formatDate } from 'src/filters/date.js'
import 'src/assets/Glyphicons/Glyphicons.css'
var kc1 = require('src/assets/kc1.png')

export default {
  components: {
    Tab, TabItem, Group, Timeline, TimelineItem, Grid, GridItem, Actionsheet
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
      if (obj.types === 2) {
        this.$router.push(`/papersteacher/${obj.learnLogId}`)
      }
      if (obj.types === 1) {
        this.$router.push(`/wteacher/${obj.learnLogId}`)
      }
      if (obj.types === 0) {
        this.$router.push(`/noticeteacher/${obj.learnLogId}`)
      }
    },
    downMeau () {
      console.log('downMeau', 'downMeau')
      this.show1 = true
    },
    actionsheetclick (key) {
      if (key === 'menu1') {
        this.$router.push(`/sendw/${this.id}`)
      }
      if (key === 'menu2') {
        this.$router.push(`/sendpapers/${this.id}`)
      }
      if (key === 'menu3') {
        this.$router.push(`/sendnotice/${this.id}`)
      }
      if (key === 'menu4') {
        this.$router.push(`/sendnotice/${this.id}`)
      }
      console.log(key)
    }
  },
  data () {
    return {
      showtab1: true,
      showtab2: false,
      show1: false,
      id: this.$route.params.id,
      menus1: {
        menu1: '发布课件',
        menu2: '发布试卷',
        menu3: '发布公告',
        menu4: '上课签到'
      },
      students: [],
      list: [],
      kc1,
      today: new Date()
    }
  },
  filters: {
    formatDate (time) {
      return formatDate(time, 'yyyy-MM-dd EE mm:ss')
    }
  },
  created () {
    GetClassCourse({
      'openId': this.$store.state.user.token,
      'id': this.id
    }).then(response => {
      console.log(response.data)
      if (response.data.result === 0) {
        this.students = response.data.data.students
        this.list = response.data.data.list
      }
    })
  }
}
</script>

<style>
  .vux-tab .vux-tab-item.vux-tab-selected{
    color: #639ef4!important
  }
  .vux-timeline-item-tail,.vux-timeline-item-color{
    background-color: #639ef4!important;
  }
</style>

<style type="text/css" lang="less" scoped>
  div.tab0 {
    position: relative
  }
  div.add{
    font-size: 2rem;
    padding-left: 10px;
    color: #639ef4;
    text-align: right;
    position: absolute;
    top:5px;
    right:1rem;
    z-index: 10;

  }
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
    position: relative
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
</style>

