<template>
<div>
  <div class="wrapper" >
     <a :href="tabItem.url" class="nav-item" :class='{active: index == nowIndex}' v-for='(tabItem,index) in tabParams' @click='tabToggle(index)'>
         <span :class='(index==3 ? "dropdownBtn" : "") + (dropdownActive ? " dropdownBtnUp" : " dropdownBtnDown")'  @click='dropdown'>{{tabItem.name}}</span>
         <ul v-if='index == 3' class="dropdownWrapper" v-show='dropdownActive'>
            <li v-for='(item, index) in dropParams'>{{item}}</li>
        </ul>
     </a>
  </div>
  <div style="margin-top:5px;">
    <tab :line-width="1" :custom-bar-width="getBarWidth" bar-active-color="#639ef4">
      <tab-item selected active-class="active-6-1"  @on-item-click="onItemClick">任务</tab-item>
      <tab-item active-class="active-6-1" @on-item-click="onItemClick">通知</tab-item>
      <tab-item active-class="active-6-1" @on-item-click="onItemClick">粉丝</tab-item>
    </tab>
  </div>
  <div>
    <div class="tab0 tabcontent" v-show= 'showtab1'>
      <img src="src/assets/xx1.png"  style="width:100%;margin-top:30px"/>
    </div>
    <div class="tab1 tabcontent" v-show= 'showtab2'>
      <img src="src/assets/xx2.png"  style="width:100%;margin-top:30px"/>
    </div>
    <div class="tab2 tabcontent" v-show= 'showtab3'>
      <img src="src/assets/xx3.png"  style="width:100%;margin-top:30px"/>
    </div>
  </div>
</div>
</template>

<script>
import { Tab, TabItem } from 'vux'
import { formatDate } from '../../common/date.js'

export default {
  components: {
    Tab, TabItem
  },
  ready () {
  },
  methods: {
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
      if (index !== 3) {
        this.dropdownActive = false
      }
    },
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
      nowIndex: 2,
      showtab1: true,
      showtab2: false,
      showtab3: false,
      dropdownActive: false,
      tabParams: [
          {name: '课程', url: '/#/'},
          {name: '发现', url: '/#/faxian'},
          {name: '消息', url: '/#/xiaoxi'},
          {name: '我', url: 'javascript:void(0)'}],
      dropParams: ['我的首页', '我的课件库', '我的试题库', '我的收藏'],
      getBarWidth: function (index) {
        return 4 * 22 + 'px'
      }
    }
  },
  filters: {
    formatDate (time) {
      var date = new Date(time)
      return formatDate(date, 'yyyy-MM-dd')
    }
  },
  created () {
  }
}
</script>

<style lang="less" scoped>
    @import '~vux/src/styles/1px.less';
    @import '~vux/src/styles/center.less';

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

      .tabcontent{background-color:#edf2f6;height:100%!important}
      .weui-tab  {background-color:#edf2f6!important}
</style>
