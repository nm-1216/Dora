<template>
  <div class="signin">
    <panel header="课程签到" :list="list" type="4"></panel>
    <div class="text-center">
      <img :src="url" style="width:90%;margin: 20px auto 0 auto" />
    </div>
  </div>
</template>
<script>

import { GetQrCode, GetTeachingTask } from 'src/Api/api'
import { Panel } from 'vux'
var _lodash = require('lodash')

export default {
  directives: { },
  components: { Panel },
  ready () {},
  data () {
    return {
      id: this.$route.params.id,
      url: '',
      model: {course: {name: ''}},
      list: [{
        title: '',
        desc: ''
      }]
    }
  },
  filters: {},
  methods: {
    GetObj (obj) {
      let tmp = ''
      _lodash.forEach(obj, function (o) {
        tmp += '/' + o.classId
      })
      return tmp.substr(1)
    }
  },
  created () {
    GetQrCode({
      'openId': this.$store.state.user.token,
      'id': this.id
    }).then(response => {
      console.log(response.data)
      if (response.data.result === 1) {
        this.url = response.data.msg
      }
    })

    GetTeachingTask({
      'openId': this.$store.state.user.token,
      'id': this.id
    }).then(response => {
      console.log(response.data)
      if (response.data.result === 0) {
        this.model = response.data.data.teachingTask
        this.list[0].title = this.model.course.name
        this.list[0].desc = this.GetObj(this.model.classes)
      }
    })
  }
}
</script>

<style lang="less" scoped>
.text-center{text-align:center}
</style>

