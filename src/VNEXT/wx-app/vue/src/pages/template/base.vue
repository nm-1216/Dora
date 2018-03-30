<template>
  <div class="base">
    <checklist :title="111111111" :label-position="labelPosition" required :options="commonList" v-model="model.value" @on-change="change"></checklist>
  </div>
</template>
<script>
import { Checklist } from 'vux'
export default {
  directives: { },
  components: { Checklist },
  ready () {},
  data () {
    return {
      labelPosition: '',
      commonList: [ 'China', 'Japan', 'America' ],
      model: {}
    }
  },
  filters: {},
  methods: {
    change (val, label) {
      console.log('change', val, label)
    }
  }
}
</script>

<style lang="less" scoped>
  body, html{background-color:#f0f0f4}
</style>

