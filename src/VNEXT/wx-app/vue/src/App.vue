<template>
  <div id="app">
    <div v-wechat-title="$route.meta.title" img-set="/static/favicon.ico"></div>
    <div v-transfer-dom><loading v-model="isLoading"></loading></div>
    <view-box ref="viewBox" class="view-box">
      <router-view class="router-view"></router-view>
    </view-box>
  </div>
</template>

<script>
import { ViewBox, Loading, TransferDom } from 'vux'
import { mapState } from 'vuex'

export default {
  name: 'app',
  directives: {
    TransferDom
  },
  components: {
    ViewBox,
    Loading
  },
  methods: {
  },
  computed: {
    ...mapState({
      route: state => state.route,
      path: state => state.route.path,
      isLoading: state => state.vux.isLoading,
      direction: state => state.vux.direction
    })
  },
  created () {
  },
  watch: {
  }
}
</script>

<style lang="less">
@import '~vux/src/styles/reset.less';
html, body, #app {
  height: 100%;
  width: 100%;
  overflow-x: hidden;
}
.view-box {
  height: 100%;
  width: 100%;
  overflow-x: hidden;
  background-color: #fbf9fe;
}
.weui-tab__panel{
  padding-bottom:0!important;
}
</style>
