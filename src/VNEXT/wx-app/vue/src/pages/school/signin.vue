<template>
  <div class="base">
    签到
  </div>
</template>
<script>

import { GetQrCode } from 'src/Api/api'

import { Checklist } from 'vux'
export default {
  directives: { },
  components: { Checklist },
  ready () {},
  data () {
    return {
      id: this.$route.params.id,
      labelPosition: '',
      commonList: [ 'China', 'Japan', 'America' ],
      model: {}
    }
  },
  filters: {},
  methods: {
  },
  created () {
    GetQrCode({
      'openId': this.$store.state.user.token,
      'id': this.id
    }).then(response => {
      console.log(response.data)
      if (response.data.result === 0) {
        this.students = response.data.data.students
        this.list = response.data.data.list
      }
    })
  }
}
</script>

<style lang="less" scoped>
</style>

