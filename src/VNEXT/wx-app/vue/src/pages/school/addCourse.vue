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
  <div>
    <group title="">
      <x-input title="课程" placeholder="如：流体力学"
      novalidate

      :show-clear="false"
      @on-blur="onBlur"
      placeholder-align="left"
      v-model="coursename"
      :max="20"
      required
      ></x-input>
    </group>
    <div id="Course">
        <group title="">

          <div class="vux-x-input weui-cell" v-for="(item,index) in list">
            <div class="weui-cell__hd"><!---->
              <label class="weui-label" style="width: 3em;">班级</label>
            <!---->
            </div>
            <div class="weui-cell__bd weui-cell__primary vux-x-input-placeholder-left">
              <input autocomplete="off" autocapitalize="off" autocorrect="off" v-model="list[index]" spellcheck="false" type="text" placeholder="如：A班" class="weui-input">
            <!----> <!----> <!----> <!---->
            </div>
            <div class="weui-cell__ft">
              <i class="vux-input-icon weui-icon weui_icon_warn weui-icon-warn" @click="onDelete(index)"></i>
            </div>
          </div>
        </group>

      <div style="text-align:center;padding:10px 0">
        <a @click="addTodo">+ 新增班级</a>
      </div>

    </div>
    <div style="margin:15px auto 0 auto;width:60%">
      <x-button mini style="width:100%" :text="'完成'" @click.native="onSubmit" type="primary"></x-button>
    </div>
    <div v-transfer-dom>
      <alert v-model="show" :title="alertTitle" @on-show="onShow" @on-hide="onHide">{{alertMessage}}</alert>
    </div>
  </div>

</div>
</template>

<script>
import { GroupTitle, Tab, TabItem, Group, Cell, XInput, XButton, TransferDomDirective as TransferDom, Alert } from 'vux'
import { CreateCourse } from '../../Api/api'
import { formatDate } from '../../common/date.js'

export default {
  directives: {
    TransferDom
  },
  components: {
    GroupTitle, Tab, TabItem, Group, Cell, XInput, XButton, Alert
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
    change (val) {
      console.log('on change', val)
    },
    onBlur (val) {
      console.log('on blur', val)
    },
    onFocus (val, $event) {
      console.log('on focus', val, $event)
    },
    onEnter (val) {
      console.log('click enter!', val)
    },
    onDelete: function (index) {
      console.log('delete')
      console.log(this.list)
      if (this.list.length <= 1) {
        this.show = true
        this.alertMessage = '最少保留一个班级'
      } else {
        this.list.splice(index, 1)
      }
    },
    addTodo: function () {
      this.list = this.list.concat('')
    },
    onSubmit: function () {
      console.log('-------------------------------')
      console.log(this.coursename)
      console.log(this.list)
      // return
      // this.show = true
      CreateCourse({courseName: this.coursename, classList: this.list}).then(response => {
        console.log(response.data)
        if (response.data.result === 1) {
          this.$router.replace({ path: '/' })
        }
      })
    }
  },
  data () {
    return {
      coursename: '',
      show: false,
      alertTitle: '',
      alertMessage: '',
      nowIndex: 0,
      dropdownActive: false,
      iconType: 'error',
      tabParams: [
          {name: '课程', url: '/#/'},
          {name: '发现', url: '/#/faxian'},
          {name: '消息', url: '/#/xiaoxi'},
          {name: '我', url: 'javascript:void(0)'}],
      dropParams: ['我的首页', '我的课件库', '我的试题库', '我的收藏'],
      getBarWidth: function (index) {
        return 4 * 22 + 'px'
      },
      list: ['']
    }
  },
  filters: {
    formatDate (time) {
      var date = new Date(time)
      return formatDate(date, 'yyyy-MM-dd')
    }
  },
  watch: {
    list: {
      handler: function (list) {
        // todoStorage.save(list)
      },
      deep: true
    }
  },
  created () {

  }
}
</script>

<style lang="less">
    @import '~vux/src/styles/1px.less';
    @import '~vux/src/styles/center.less';

    #Course .weui_icon_warn{ color:gray}
    #Course .weui_icon_warn:before{ content:'\EA0F'}

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
