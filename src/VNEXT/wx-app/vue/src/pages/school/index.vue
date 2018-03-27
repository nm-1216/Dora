<template>
<div>
  <div class="wrapper" >
     <a :href="tabItem.url" class="nav-item" :class='{active: index == nowIndex}' v-for='(tabItem,index) in tabParams' @click='tabToggle(index)'>
         <span :class='(index==3 ? "dropdownBtn" : "") + (dropdownActive ? " dropdownBtnUp" : " dropdownBtnDown")'  @click='dropdown'>{{tabItem.name}}</span>
         <ul v-if='index == 3' class="dropdownWrapper" v-show='dropdownActive'>
            <li v-for='(item, index) in dropParams' :key="index">{{item}}</li>
        </ul>
     </a>
  </div>
  <div style="margin-top:5px;">
    <tab :line-width="1" :custom-bar-width="getBarWidth" bar-active-color="#639ef4">
      <tab-item selected active-class="active-6-1"  @on-item-click="onItemClick">班级课程</tab-item>
      <tab-item active-class="active-6-1" @on-item-click="onItemClick">公开课</tab-item>
    </tab>
  </div>
  <div>
    <div class="tab0 tabcontent" v-show= 'isStudent'>
      <group >
        <group-title>我的课程</group-title>
        <cell v-for="(item,index) in list" :key="index" :title="item.course.name" :link="'/class/'+ClassId+'/'+item.course.courseId" is-link></cell>
      </group>

    </div>
    <div class="tab0 tabcontent" v-show= 'isTeacher'>
      <div style="padding:14px 15px 0;line-height:1.6;color:gray">我的课程</div>
      <group v-for="(item,index) in list" :key="index">
        <group-title>{{item.name}}<span style="float:right;color: #c00">管理</span></group-title>
        <cell v-for="(xx, index) in item.classes" :key="index"  :title="xx.name" :link="'/class/'+xx.classId" is-link :value="xx.user.length+'人'"></cell>
      </group>
    </div>
  </div>
</div>
</template>

<script>
import { GroupTitle, Tab, TabItem, Group, Cell } from 'vux'
import { GetCourseList } from 'src/Api/api'
import { formatDate } from 'src/common/date.js'
import { mapActions } from 'vuex'
import { USER_SIGNOUT } from 'src/store/user'
var bj1 = require('src/assets/bj1.png')

export default {
  components: {
    GroupTitle, Tab, TabItem, Group, Cell
  },
  ready () {
  },
  methods: {
    ...mapActions([USER_SIGNOUT]),
    onHide () {
      console.log('on hide')
    },
    onShow () {
      console.log('on show')
    },
    dropdown: function (event) {
      // console.log(event.target.getAttribute('class'))
      if (event.target.getAttribute('class') === 'dropdownBtn dropdownBtnDown' || event.target.getAttribute('class') === 'dropdownBtn dropdownBtnUp') {
        this.dropdownActive = !this.dropdownActive
      }
    },
    tabToggle: function (index) {
      this.nowIndex = index
      if (index === 3) {
        console.log('----')
      } else {
        this.dropdownActive = false
      }
    },
    onItemClick (index) {
      console.log('on item click:', index)
      
      

      if (index === 0) {
        this.showtab1 = true
      }
      if (index === 1) {
        this.showtab2 = true
      }
      
    },
    next () {
      if (this.index === this.list2.length - 1) {
        this.index = 0
      } else {
        ++this.index
      }
    },
    prev () {
      if (this.index === 0) {
        this.index = this.list2.length - 1
      } else {
        --this.index
      }
    }
  },
  data () {
    return {
      nowIndex: 0,
      dropdownActive: false,
      showtab1: true,
      showtab2: false,
      isStudent: false,
      ClassId: '',
      isTeacher: false,
      tabParams: [
          {name: '课程', url: '/#/'},
          {name: '发现', url: '/#/faxian'},
          {name: '消息', url: '/#/xiaoxi'},
          {name: '我', url: 'javascript:void(0)'}],
      dropParams: ['我的首页', '我的课件库', '我的试题库'],
      getBarWidth: function (index) {
        return 4 * 22 + 'px'
      },
      list: [],
      bj1
    }
  },
  filters: {
    formatDate (time) {
      var date = new Date(time)
      return formatDate(date, 'yyyy-MM-dd')
    }
  },
  created () {
    var isLogin = Boolean(this.$store.state.user.token)
    isLogin = true
    if (isLogin) {
      GetCourseList({'openId': this.$store.state.user.token}).then(response => {
        console.log(response.data)
        if (response.data.result === 0) {
          console.log(response.data.data)
          this.isStudent = response.data.data.user.userType==0
          this.ClassId=response.data.data.user.student.classId
          this.isTeacher = response.data.data.user.userType==1
          this.list=response.data.data.list
        }
      })
    }
  }
}
</script>

<style lang="less">
    @import '~vux/src/styles/1px.less';
    @import '~vux/src/styles/center.less';

    .weui-cells,.vux-no-group-title {
      margin-top:11px!important
    }
    .wrapper {
        display: flex;
        justify-content: center;
        align-items: center;
        box-shadow: 1px 1px 5px rgba(0,0,0,.4);
    }
    .wrapper>a {
        flex: 1;
        text-align: center;
        height: 36px;
        line-height: 36px;
        text-decoration: none;
        color: #000!important;
        font-size:18px!important;font-weight: bold;
    }
    .dropdownWrapper {
        /*margin-top: 36px;
        border: 1px solid #2C3E50;*/
        font-size: 14px;
        box-shadow: -1px 1px 5px rgba(0,0,0,.4);
        z-index:99;
        position: absolute;
        width:100%
    }
    .dropdownWrapper li {
        display: block;
        text-align: left;
        padding-left: 5px;
        border-bottom: 1px solid rgba(0,0,0,.4);
        background-color:#fff
    }

    .nav-item.active {
        background: #fff;
        color: #639ef4!important
    }
    .dropdownBtn {
        display: inline-block;
        width: 100%;
        height: 100%;
    }
    .nav-item {
        cursor: pointer;background:#edf2f6;display: block;
    }

    .box {
        padding: 15px;
      }
      .active-6-1 {
        color: #639ef4 !important;
        border-color: #639ef4 !important;
      }
      .active-6-2 {
        color: #04be02 !important;
        border-color: #04be02 !important;
      }
      .active-6-3 {
        color: rgb(55, 174, 252) !important;
        border-color: rgb(55, 174, 252) !important;
      }
      .tab-swiper {
        background-color: #fff;
        height: 100px;
      }

      .dropdownBtn:after {
        content: " ";
        display: inline-block;
        height: 6px;
        width: 6px;
        border-width: 2px 2px 0 0;
        border-color: #C8C8CD;
        border-style: solid;
        -webkit-transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0);
            -ms-transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0);
                transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0);
        position: relative;
        top: 15px;
        margin-right:4px;
        position: absolute;

        right: 17px;
      }

      .dropdownBtnDown:after{
        -webkit-transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0) rotate(90deg);
            -ms-transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0) rotate(90deg);
                transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0) rotate(90deg);
      }

      .dropdownBtnUp:after{
        -webkit-transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0) rotate(-90deg);
            -ms-transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0) rotate(-90deg);
                transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0) rotate(-90deg);
      }
</style>
