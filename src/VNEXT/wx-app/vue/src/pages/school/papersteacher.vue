<template>
  <div class="notice">
    <div class="title">
      <h2>{{ courseName }}</h2>
      <p><i class="glyphicon glyphicon-user"></i> {{ this.teacher.name }} <i class="glyphicon glyphicon-th-list"></i> {{GetObj(this.teachingTask.classes)}}</p>
    </div>

    <div class="content">
      <h4>{{this.model.title}}</h4>
      <p class="auth"><i class="glyphicon glyphicon-time"></i> {{this.model.createTimeTimeStamp | formatDate}}</p>
      <p class="auth"><i class="glyphicon glyphicon-info-sign"></i> 总分：{{score}}</p>
    </div>

    <div id="main" style="height:200px;background-color:#fff;padding-top:10px"></div>

    <div class="papers">
      <div v-for="(item,index) in this.answers" :keys="index">
        
        <group :title="item.item.code +'. '+ item.item.text">
          <box gap="10px" style="padding:10px 0">
            <div class="progress">
              <div :class="['progress-bar',getProgressBar(Division(item.right,item.count))]" role="progressbar" :style="{'width': Division(item.right,item.count)+'%','min-width':'2em'}">
                <span class="sr-only">{{ Division(item.right,item.count) }}%</span>
              </div>
            </div>
          </box>
        </group>
      </div>
    </div>
    <div class="content">
      <p style="font-size:0.8rem;line-height:1.5;padding-top:20px">
        <x-button type="warn" @click.native="Del">删除</x-button>
      </p>
    </div> 
  </div>
</template>
<script>
import { XInput, XButton, Group, TransferDom, Box } from 'vux'
import { GetNotice, GetPaperTongJi, DelLearnLog } from 'src/Api/api'
import 'src/assets/Glyphicons/Glyphicons.css'
import 'src/assets/css/progress.css'
import 'src/assets/style/notice.css'
import { formatDate } from 'src/filters/date.js'
import echarts from 'echarts'
var _lodash = require('lodash')

export default {
  directives: { TransferDom },
  components: { Group, XInput, XButton, Box },
  data () {
    return {
      teacher: {},
      teachingTask: {},
      id: this.$route.params.id,
      courseName: '',
      learnLog: {},
      model: {},
      classes: {},
      course: {},
      answers: [],
      charts: '',
      score: '',
      opinion: ['不及格', '合格', '优秀'],
      opinionData: [
        {value: 335, name: '不及格'},
        {value: 310, name: '合格'},
        {value: 234, name: '优秀'}
      ]
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
  mounted () {
    this.$nextTick(function () {
      this.drawPie('main')
    })
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
      GetNotice({'id': this.id}).then(response => {
        console.log(response.data)
        this.learnLog = response.data.data.learnLog
        this.model = response.data.data.model
        this.teacher = response.data.data.teacher
        this.teachingTask = response.data.data.teachingTask
        this.courseName = this.teachingTask.course.name
      })

      GetPaperTongJi({'id': this.id}).then(response => {
        console.log(response.data.data)
        let abc = response.data.data.model
        abc = _lodash.orderBy(abc, ['item.code'], ['asc'])
        this.score = _lodash.sumBy(abc, function (o) { return o.item.value })
        this.answers = abc
      })
    },
    GetObj (obj, type) {
      let tmp = ''
      _lodash.forEach(obj, function (o) {
        tmp += '/' + o.classId
      })
      return tmp.substr(1)
    },
    Division (a, b) {
      if (b === 0) {
        return 0
      } else {
        return a / b * 100
      }
    },
    getProgressBar (value) {
      if (value <= 30) {
        return 'progress-bar-danger'
      } else if (value <= 60) {
        return 'progress-bar-warning'
      } else if (value <= 80) {
        return 'progress-bar-info'
      } else {
        return 'progress-bar-success'
      }
    },
    drawPie (id) {
      this.charts = echarts.init(document.getElementById(id))
      this.charts.setOption({
        tooltip: {
          trigger: 'item',
          formatter: '{a}<br/>{b}:{c} ({d}%)'
        },
        legend: {
          x: 'center',
          data: this.opinion
        },
        series: [{
          name: '测试成绩',
          type: 'pie',
          radius: ['30%', '60%'],
          avoidLabelOverlap: false,
          label: {
            normal: {
              show: false,
              position: 'center'
            },
            emphasis: {
              show: false,
              textStyle: {
                fontSize: '30',
                fontWeight: 'blod'
              }
            }
          },
          labelLine: {
            normal: {
              show: false
            }
          },
          data: this.opinionData
        }]
      })
    }
  }
}
</script>
<style type="text/css">
  .progress{
    margin-bottom: 0 
  }
</style>