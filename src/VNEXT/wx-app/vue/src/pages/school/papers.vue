<template>
  <div class="notice" v-show="showBody">
    <div class="title">
      <h2>{{ courseName }}</h2>
      <p><i class="glyphicon glyphicon-user"></i> {{ this.teacher.name }} <i class="glyphicon glyphicon-th-list"></i> {{GetObj(this.teachingTask.classes)}}</p>
    </div>

    <div class="content">
      <h4>{{this.model.title}}</h4>
      <p class="auth"><i class="glyphicon glyphicon-time"></i> {{this.model.createTimeTimeStamp | formatDate}}</p>
      <p class="auth"><i class="glyphicon glyphicon-info-sign"></i> 总分：{{score}}</p>
      <p class="auth start"><i class="glyphicon glyphicon-heart"></i> 成绩：{{myScore}}</p>
    </div>

    <div class="papers" v-if="this.answers !== null">
      <div v-for="(item,index) in this.model.paperQuestions" :keys="index">
        <checklist :title="(index+1)+'. ['+GetType(item.qType)+'] '+item.text+'  <i>'+item.answer+'</i>'" disabled label-position="left" :options="GetOptions(item)" v-model="item.newAnswer"></checklist>
      </div>
    </div>

    <div class="papers" v-if="this.answers === null">
      <div v-for="(item,index) in this.model.paperQuestions" :keys="index">
        <checklist v-if="item.qType===1" :title="(index+1)+'. ['+GetType(item.qType)+'] '+item.text" :max="1" label-position="left" :options="GetOptions(item)" v-model="item.userAnswer"></checklist>
        <checklist v-if="item.qType===2" :title="(index+1)+'. ['+GetType(item.qType)+'] '+item.text" :max="6" label-position="left" :options="GetOptions(item)" v-model="item.userAnswer"></checklist>
      </div>
      <div class="content">
        <p style="font-size:0.8rem;line-height:1.5;padding-top:20px">
          <x-button type="warn" @click.native="submitPaper">提交答卷</x-button>
        </p>
      </div> 
    </div>
  </div>
</template>
<script>
import { XInput, XButton, Group, TransferDom, Radio, Checklist } from 'vux'
import { GetPapers, PushAnswer } from 'src/Api/api'
import 'src/assets/Glyphicons/Glyphicons.css'
import { formatDate } from 'src/filters/date.js'
import 'src/assets/style/notice.css'
var _lodash = require('lodash')

export default {
  directives: { TransferDom },
  components: { Group, XInput, XButton, Radio, Checklist },
  data () {
    return {
      showBody: false,
      learnLog: {},
      model: {},
      classes: {},
      course: {},
      answers: null,
      score: 0,
      myScore: '',
      teachingTask: {},
      teacher: '',
      courseName: '',
      id: this.$route.params.id
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
      GetPapers({'id': this.$route.params.id, 'openId': this.$store.state.user.token}).then(response => {
        console.log(response.data)
        this.learnLog = response.data.data.learnLog
        this.teacher = response.data.data.teacher
        this.answers = response.data.data.answers
        this.teachingTask = response.data.data.teachingTask
        this.courseName = this.teachingTask.course.name

        let abc = response.data.data.model
        abc.paperQuestions = _lodash.orderBy(abc.paperQuestions, ['code'], ['asc'])
        this.model = abc
        this.score = _lodash.sumBy(abc.paperQuestions, function (o) { return o.value })
        let vm = this
        if (this.answers !== null) {
          _lodash.forEach(this.model.paperQuestions, function (value) {
            let tmpIndex = _lodash.findIndex(vm.answers.paperAnswerDetails, function (o) { return o.paperQuestionId === value.paperQuestionId })
            value.newAnswer = vm.answers.paperAnswerDetails[ tmpIndex ].value.split('')
            value.isRight = vm.answers.paperAnswerDetails[ tmpIndex ].isRight
          })

          this.myScore = _lodash.sumBy(
            _lodash.filter(this.model.paperQuestions, function (o) { return o.isRight })
            , function (o) { return o.value })
        }
        this.showBody = true
      })
    },
    submitPaper () {
      let flag = false
      let vm = this
      let index = 0
      _lodash.forEach(this.model.paperQuestions, function (value) {
        if (value.userAnswer.length <= 0) {
          flag = true
          if (index <= 0) {
            index = value.code
          }
        }
      })

      if (flag) {
        vm.$vux.alert.show({
          title: '提示',
          content: '试卷没有做完，不可以提交，请检查第 ' + index + ' 题',
          onShow () {
            console.log('Plugin: I\'m showing')
          },
          onHide () {
            console.log('Plugin: I\'m hiding')
          }
        })
        return
      }

      PushAnswer({'model': this.model, 'openId': this.$store.state.user.token, 'id': this.id}).then(response => {
        console.log(response.data)
        if (response.data.result === 0) {
          this.$vux.alert.show({
            title: '提示',
            content: response.data.msg,
            onShow () {
              console.log('Plugin: I\'m showing')
            },
            onHide () {
              vm.$router.push(`/class/${vm.learnLog.teachingTaskId}`)
            }
          })
        } else {
          this.$vux.alert.show({
            title: '提示',
            content: response.data.msg,
            onShow () {
              console.log('Plugin: I\'m showing')
            },
            onHide () {
              vm.$router.push(`/class/${vm.learnLog.teachingTaskId}`)
            }
          })
        }
      })
    },
    GetType (id) {
      if (id === 1) {
        return '单选'
      }
      if (id === 2) {
        return '多选'
      }
      if (id === 3) {
        return '打分'
      }
      if (id === 4) {
        return '主观'
      }
      return id
    },
    GetOptions (obj) {
      let temp = []
      let tmp

      tmp = obj.option1
      if (tmp !== null && tmp !== undefined && tmp !== '') {
        temp.push({key: 'A', value: 'A:' + tmp})
      }
      tmp = obj.option2
      if (tmp !== null && tmp !== undefined && tmp !== '') {
        temp.push({key: 'B', value: 'B:' + tmp})
      }
      tmp = obj.option3
      if (tmp !== null && tmp !== undefined && tmp !== '') {
        temp.push({key: 'C', value: 'C:' + tmp})
      }
      tmp = obj.option4
      if (tmp !== null && tmp !== undefined && tmp !== '') {
        temp.push({key: 'D', value: 'D:' + tmp})
      }
      tmp = obj.option5
      if (tmp !== null && tmp !== undefined && tmp !== '') {
        temp.push({key: 'E', value: 'E:' + tmp})
      }
      tmp = obj.option6
      if (tmp !== null && tmp !== undefined && tmp !== '') {
        temp.push({key: 'F', value: 'F:' + tmp})
      }
      return temp
    }
  }
}
</script>
<style type="text/css">
  .weui-cells__title i{
    color: #ff2d51;
    font-weight: bold;
  }
  .notice {
    background-color: #f0f0f4
  }
</style>
