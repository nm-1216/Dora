<template>
  <div class="notice">
    <div class="title">
      <h2>{{this.course.name}}</h2>
      <p><i class="glyphicon glyphicon-user"></i> {{ this.teacher }} <i class="glyphicon glyphicon-th-list"></i> {{this.classes.name}}</p>
    </div>

    <div class="content">
      <h4>{{this.model.title}}</h4>
      <p class="auth"><i class="glyphicon glyphicon-time"></i> {{this.model.createTimeTimeStamp | formatDate}}</p>
      <p style="border-top:1px solid #ccc"></p>
    </div>

    <div class="papers" v-show="this.answers === null">
      <div v-for="(item,index) in this.model.paperQuestions" :keys="index">
        <checklist v-show="item.qType===1" :title="(index+1)+'. ['+GetType(item.qType)+'] '+item.text" :max="1" label-position="left" :options="GetOptions(item)" v-model="item.userAnswer"></checklist>
        <checklist v-show="item.qType===2" :title="(index+1)+'. ['+GetType(item.qType)+'] '+item.text" :max="6" label-position="left" :options="GetOptions(item)" v-model="item.userAnswer"></checklist>
      </div>
      <div class="content">
        <p style="font-size:0.8rem;line-height:1.5;padding-top:20px">
          <x-button type="warn" @click.native="submitPaper">提交答卷</x-button>
        </p>
      </div> 
    </div>

    <div class="papers" v-show="this.answers !== null">
      <div v-for="(item,index) in this.model.paperQuestions" :keys="index">
        <checklist :title="(index+1)+'. ['+GetType(item.qType)+'] '+item.text+'  '+item.answer" disabled label-position="left" :options="GetOptions(item)" v-model="item.newAnswer"></checklist>
      </div>
    </div>

  </div>
</template>
<script>
import { XInput, XButton, Group, TransferDom, Radio, Checklist } from 'vux'
import { GetPapers, PushAnswer } from 'src/Api/api'
import 'src/assets/Glyphicons/Glyphicons.css'
import { formatDate } from 'src/filters/date.js'
var _lodash = require('lodash')

export default {
  directives: { TransferDom },
  components: { Group, XInput, XButton, Radio, Checklist },
  data () {
    return {
      learnLog: {},
      model: {},
      classes: {},
      course: {},
      teacher: '',
      answers: {}
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
    getData () {
      console.log('getData', 'GetNotice')
      GetPapers({'id': this.$route.params.id, 'openId': this.$store.state.user.token}).then(response => {
        console.log(response.data)
        this.learnLog = response.data.data.learnLog
        let abc = response.data.data.model
        abc.paperQuestions = _lodash.orderBy(abc.paperQuestions, ['code'], ['asc'])
        this.model = abc
        this.teacher = this.model.teacher.name
        this.classes = response.data.data.classes
        this.course = response.data.data.course
        this.answers = response.data.data.answers
        let vm = this
        if (this.answers !== null) {
          _lodash.forEach(this.model.paperQuestions, function (value) {
            let tmpIndex = _lodash.findIndex(vm.answers.paperAnswerDetails, function (o) { return o.paperQuestionId === value.paperQuestionId })
            value.newAnswer = vm.answers.paperAnswerDetails[ tmpIndex ].value.split('')
          })
        }
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

      PushAnswer({'model': this.model, 'openId': this.$store.state.user.token}).then(response => {
        console.log(response.data)
        if (response.data.result === 0) {
          this.$vux.alert.show({
            title: '提示',
            content: response.data.msg,
            onShow () {
              console.log('Plugin: I\'m showing')
            },
            onHide () {
              vm.$router.push(`/class/${vm.learnLog.classId}/${vm.learnLog.courseId}`)
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
              vm.$router.push(`/class/${vm.learnLog.classId}/${vm.learnLog.courseId}`)
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
  .notice .title{
    padding: 20px 20px 10px 20px;
    background: #fff
  }
  .notice .content{
    padding: 20px;
    background: #fff;
    margin:10px auto;
  }
  .notice .content p.auth,.notice .title p{
    font-size:0.5rem;
    color: #ccc;
    line-height: 4;
  }

.notice .content div{
  background-color: #F5F5F5;
  font-size:0.8rem;
  padding: 5px 10px;
  margin-top: 10px;
  min-height: 3rem;
  color: #ccc
}

</style>
