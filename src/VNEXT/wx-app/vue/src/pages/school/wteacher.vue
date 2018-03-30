<template>
  <div class="notice">
    <div class="title">
      <h2>{{ courseName }}</h2>
      <p><i class="glyphicon glyphicon-user"></i> {{ this.teacher.name }} <i class="glyphicon glyphicon-th-list"></i> {{GetObj(this.teachingTask.classes)}}</p>
    </div>

    <div class="content">
      <h4>{{this.model.title}}</h4>
      <p class="auth"><i class="glyphicon glyphicon-time"></i> {{this.model.createTimeTimeStamp | formatDate}}</p>
      <p style="border-top:1px solid #ccc"></p>
      <p class="files">
        <a :href="this.model.url">立即预览</a>
      </p>
    </div>
    <div class="content">
      <p style="font-size:0.8rem;line-height:1.5;padding-top:20px">
        <x-button type="warn" @click.native="Del">删除</x-button>
      </p>
    </div> 
  </div>
</template>
<script>
import { XButton, Group, TransferDom } from 'vux'
import { GetNotice, DelLearnLog } from 'src/Api/api'
import 'src/assets/Glyphicons/Glyphicons.css'
import { formatDate } from 'src/filters/date.js'
import 'src/assets/style/notice.css'
var _lodash = require('lodash')

export default {
  directives: { TransferDom },
  components: { Group, XButton },
  data () {
    return {
      learnLog: {},
      model: {},
      teacher: {},
      teachingTask: {},
      id: this.$route.params.id,
      courseName: ''
    }
  },
  filters: {
    formatDate (time) {
      return formatDate(time, 'yyyy-MM-dd mm:ss')
    }
  },
  created () {
    this.getData()
  },
  methods: {
    Del () {
      let vm = this
      this.$vux.confirm.show({
        title: '删除',
        content: '数据不可恢复，确定删除数据吗？',
        onCancel () {
        },
        onConfirm () {
          DelLearnLog({'learnLogId': vm.$route.params.id, 'openId': vm.$store.state.user.token}).then(response => {
            console.log(response.data)
            if (response.data.result === 0) {
              vm.$vux.alert.show({
                title: '提示',
                content: response.data.msg,
                onShow () {
                  console.log('Plugin: I\'m showing')
                },
                onHide () {
                  vm.$router.push(`/classteacher/${vm.learnLog.teachingTaskId}`)
                }
              })
            } else {
              vm.$vux.alert.show({
                title: '提示',
                content: response.data.msg,
                onShow () {
                  console.log('Plugin: I\'m showing')
                },
                onHide () {
                  vm.$router.push(`/classteacher/${vm.learnLog.teachingTaskId}`)
                }
              })
            }
          })
        }
      })
    },
    getData () {
      console.log('getData', 'GetNotice')
      GetNotice({'id': this.$route.params.id}).then(response => {
        console.log(response.data)
        this.learnLog = response.data.data.learnLog
        this.model = response.data.data.model
        this.teacher = response.data.data.teacher
        this.teachingTask = response.data.data.teachingTask
        this.courseName = this.teachingTask.course.name
      })
    },
    GetObj (obj, type) {
      let tmp = ''
      _lodash.forEach(obj, function (o) {
        tmp += '/' + o.classId
      })
      return tmp.substr(1)
    }
  }
}
</script>

<style type="text/css">
  .notice .files {
    font-weight: bold;
    line-height: 4;
    font-size: 1rem
  }
  .notice .files a {
    color: #639ef4
  }
</style>
