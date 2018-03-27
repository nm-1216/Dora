<template>
<div>
  <div>
    <tab :line-width="1" :custom-bar-width="getBarWidth" bar-active-color="#639ef4">
      <tab-item selected active-class="active-6-1"  @on-item-click="onItemClick">教学日志</tab-item>
      <tab-item active-class="active-6-1" @on-item-click="onItemClick">我的同学</tab-item>
    </tab>
  </div>
  <div>
    <div class="tab0 tabcontent" v-show= 'showtab1'>
      <img :src="kc1" style="width:100%"/>
      <img :src="kc2" style="width:100%"/>
    </div>
    <div class="tab1 tabcontent" v-show= 'showtab2'>
      
      <group >
        <group-title>同学</group-title>
        <cell v-for="(item,index) in tongxue" :key="index" :title="item.name"></cell>
      </group>

    </div>
  </div>

</div>
</template>

<script>
import { GroupTitle, Tab, TabItem, Group, Cell } from 'vux'
import { GetTongXue } from 'src/Api/api'
import { formatDate } from 'src/common/date.js'

var kc1 = require('src/assets/kc1.png')
var kc2 = require('src/assets/kc2.png')

export default {
  components: {
    GroupTitle, Tab, TabItem, Group, Cell
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
      if (index === 3) {
        return
      } else {
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
      nowIndex: 0,
      dropdownActive: false,
      showtab1: true,
      showtab2: false,
      tabParams: [
          {name: '课程', url: '/#/'},
          {name: '发现', url: '/#/faxian'},
          {name: '消息', url: '/#/xiaoxi'},
          {name: '我', url: 'javascript:void(0)'}],
      dropParams: ['我的首页', '我的课件库', '我的试题库', '我的收藏'],
      getBarWidth: function (index) {
        return 4 * 22 + 'px'
      },
      tongxue: [],
      kc1,
      kc2
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
      GetTongXue({'openId': this.$store.state.user.token}).then(response => {
        console.log(response.data)
        if (response.data.result === 0) {
          this.tongxue=response.data.data.students
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
