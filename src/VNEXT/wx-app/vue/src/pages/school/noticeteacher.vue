<template>
  <div class="notice">
    <div class="title">
      <h2>{{this.course.name}}</h2>
      <p><i class="glyphicon glyphicon-user"></i> {{ this.teacher }} <i class="glyphicon glyphicon-th-list"></i> {{this.classes.name}}</p>
    </div>

    <div class="content" v-show="learnLog.types===0">
      <h4>{{this.model.title}}</h4>
      <p class="auth"><i class="glyphicon glyphicon-time"></i> {{this.model.createTimeTimeStamp | formatDate}}</p>
      <p style="border-top:1px solid #ccc"></p>
      <p style="font-size:0.8rem;line-height:1.5;padding-top:20px">{{this.model.content}}</p>
    </div>

    <div class="content">
      <p style="font-size:0.8rem;line-height:1.5;padding-top:20px">
        <x-button type="warn" @click.native="Del">删除</x-button>
      </p>
    </div> 
  </div>
</template>
<script>
import { XInput, XButton, Group, TransferDom } from 'vux'
import { GetNotice, DelLearnLog } from 'src/Api/api'
import 'src/assets/Glyphicons/Glyphicons.css'
import { formatDate } from 'src/filters/date.js'

export default {
  directives: { TransferDom },
  components: { Group, XInput, XButton },
  data () {
    return {
      learnLog: {},
      model: {},
      classes: {},
      course: {},
      teacher: ''
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
                  vm.$router.push(`/classteacher/${vm.learnLog.classId}/${vm.learnLog.courseId}`)
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
                  vm.$router.push(`/classteacher/${vm.learnLog.classId}/${vm.learnLog.courseId}`)
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
        this.teacher = this.model.teacher.name
        this.classes = response.data.data.classes
        this.course = response.data.data.course
      })
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
