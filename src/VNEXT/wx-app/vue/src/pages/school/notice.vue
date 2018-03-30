<template>
  <div class="notice">
    <div class="title">
      <h2>{{ courseName }}</h2>
      <p><i class="glyphicon glyphicon-user"></i> {{ this.teacher.name }} <i class="glyphicon glyphicon-th-list"></i> {{GetObj(this.teachingTask.classes)}}</p>
    </div>

    <div class="content" v-if="learnLog.types===0">
      <h4>{{this.model.title}}</h4>
      <p class="auth"><i class="glyphicon glyphicon-time"></i> {{this.model.createTimeTimeStamp | formatDate}}</p>
      <p style="border-top:1px solid #ccc"></p>
      <p style="font-size:0.8rem;line-height:1.5;padding-top:20px">{{this.model.content}}</p>
    </div>

    <div v-if="learnLog.types===1">
      <div class="content">
        <h4>{{this.model.title}}</h4>
        <p class="auth"><i class="glyphicon glyphicon-time"></i> {{this.model.createTimeTimeStamp | formatDate}}</p>
        <p style="border-top:1px solid #ccc"></p>
        <p class="files">
          <a :href="this.model.url">立即预览</a>
        </p>
      </div>

      <div class="content">
        <h4>答题情况</h4>
        <div>本次预习资料中没有习题</div>
      </div>

      <div class="content">
        <h4>报告老师</h4>
        <div>有什么问题可以直接报告老师</div>
      </div>

      <div class="content">
        <h4>学习心得</h4>
        <div>您可以在这里记录教学设计和心得等笔记，内容。仅自己可见</div>
      </div>
    </div>

    <div class="content" v-if="learnLog.types===2">
      <h4>{{this.model.title}}</h4>
      <p class="auth"><i class="glyphicon glyphicon-time"></i> {{this.model.createTimeTimeStamp | formatDate}}</p>
      <p class="auth"><i class="glyphicon glyphicon-info-sign"></i> 总分：{{score}}</p>
      <p style="font-size:0.8rem;line-height:1.5;padding-top:20px">
        <x-button type="primary" :link="`/papers/${this.learnLog.learnLogId}`">开始答题</x-button>
      </p>
    </div>
  </div>
</template>
<script>
import { XInput, XButton, Group, TransferDom } from 'vux'
import { GetNotice } from 'src/Api/api'
import 'src/assets/Glyphicons/Glyphicons.css'
import { formatDate } from 'src/filters/date.js'
import 'src/assets/style/notice.css'
var _lodash = require('lodash')

export default {
  directives: { TransferDom },
  components: { Group, XInput, XButton },
  data () {
    return {
      score: '',
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
    GetObj (obj, type) {
      let tmp = ''
      _lodash.forEach(obj, function (o) {
        tmp += '/' + o.classId
      })
      return tmp.substr(1)
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

        if (this.learnLog.types === 2) {
          this.score = _lodash.sumBy(this.model.paperQuestions, function (o) { return o.value })
        }
      })
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
