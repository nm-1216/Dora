<template>
  <div class="index">
    <blur :blur-amount=40 :url="url">
      <p class="center"><img :src="url"></p>
    </blur>
    <div class="main" v-show="isShow">
      <group v-show= 'isStudent' title="我的课程">
        <cell v-for="(item,index) in studentList" :key="index" :title="item.course.name" :link="'/class/'+item.teachingTaskId" is-link></cell>
      </group>
      <group v-show= 'isTeacher' v-for="(item,index) in course" :key="index" :title="item.name">
        <cell v-for="(xx, index) in  GetClasses(item.courseId) " :key="index"  
        :title="GetObj(xx.classes,1)" 
        :link="'/classteacher/'+xx.teachingTaskId" 
        is-link 
        :value="GetObj(xx.classes,2)+'人'"></cell>
      </group>
    </div>
  </div>
</template>

<script>
import { Group, Cell, Blur } from 'vux'
import { GetCourseList, GetUserInfo } from 'src/Api/api'
var _lodash = require('lodash')

export default {
  name: 'index',
  components: { Group, Cell, Blur },
  data () {
    return {
      isStudent: false,
      isTeacher: false,
      ClassId: '',
      studentList: [],
      teacherList: [],
      course: [],
      url: 'https://o3e85j0cv.qnssl.com/tulips-1083572__340.jpg',
      isShow: false
    }
  },
  methods: {
    GetClasses (id) {
      let tmp = _lodash.filter(this.teacherList, function (o) { return o.courseId === id })
      console.log('tmp', tmp)
      return tmp
    },
    GetObj (obj, type) {
      let tmp = ''
      let abc = 0
      if (type === 1) {
        _lodash.forEach(obj, function (o) {
          tmp += '/' + o.classId
        })
        return tmp.substr(1)
      } else if (type === 2) {
        _lodash.forEach(obj, function (o) {
          abc += o.class.students.length
        })
        return abc
      }
    }
  },
  created () {
    GetCourseList({'openId': this.$store.state.user.token}).then(response => {
      console.log('GetCourseList', response.data)
      if (response.data.result === 0) {
        this.isStudent = response.data.data.user.userType === 0
        this.isTeacher = response.data.data.user.userType === 1

        if (this.isStudent) {
          this.ClassId = response.data.data.user.student.classId
          this.studentList = response.data.data.list
        } else {
          this.teacherList = response.data.data.list
          this.course = response.data.data.course
        }
        this.isShow = true
      }
    })

    GetUserInfo({'openId': this.$store.state.user.token}).then(response => {
      console.log('GetUserInfo', response.data)
      if (response.data.result === 0) {
        if (response.data.data.wxAvatar) {
          this.url = response.data.data.wxAvatar
        }
      }
    })
  }
}
</script>

<style lang="less" scoped>
.center {
  text-align: center;
  padding-top: 30px;
  color: #fff;
  font-size: 18px;
}
.center img {
  width: 100px;
  height: 100px;
  border-radius: 50%;
  border: 4px solid #ececec;
}
.index .main{ 
  background-color:#f0f0f4;
  margin-top:-10px;
  padding-top:5px;
}
</style>

