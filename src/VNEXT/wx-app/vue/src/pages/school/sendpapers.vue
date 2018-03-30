<template>
  <div class="sendPapers">
    <search v-model="searchkey" @on-change="getResult" ref="search"></search>

    <group title="我的试卷">
      <radio title="title" :options="options" v-model="value"></radio>
    </group>

      <div style="padding:30px 15px;background-color:#fff">
        <x-button type="warn" @click.native="submit">发送</x-button>
      </div>
  </div>
</template>
<script>
import { XInput, XButton, Group, TransferDom, XTextarea, Search, Radio } from 'vux'
import { SendPapers, GetPapersList } from 'src/Api/api'
var _lodash = require('lodash')

export default {
  directives: {
    TransferDom
  },
  components: {
    Group,
    XInput,
    XButton,
    XTextarea,
    Search,
    Radio
  },
  data () {
    return {
      results: [],
      list: [],
      id: this.$route.params.id,
      searchList: [],
      searchkey: '',
      value: ''
    }
  },
  created () {
    this.getData()
  },
  computed: {
    options: function () {
      let temp = []
      _lodash.forEach(this.searchList, function (value) {
        temp.push({key: value.paperId, value: value.title})
      })
      return temp
    }
  },
  methods: {
    getData () {
      GetPapersList({
        openId: this.$store.state.user.token
      }).then(response => {
        this.list = response.data.data
        this.searchList = _lodash.clone(this.list)
      })
    },
    setFocus () {
      this.$refs.search.setFocus()
    },
    resultClick (item) {
      window.alert('you click the result item: ' + JSON.stringify(item))
    },
    getResult (val) {
      let vm = this
      vm.searchList = _lodash.filter(vm.list, function (o) { return o.title.search(val) >= 0 })
    },
    onSubmit () {
      this.$refs.search.setBlur()
      this.$vux.toast.show({
        type: 'text',
        position: 'top',
        text: 'on submit'
      })
    },
    onFocus () {
    },
    onCancel () {
    },
    submit () {
      if (!this.value) {
        this.$vux.alert.show({
          title: '提交失败',
          content: '请选择课件',
          onShow () {
            console.log('')
          },
          onHide () {
            console.log('')
          }
        })
        return
      }
      SendPapers({
        id: this.id,
        objectId: this.value,
        openId: this.$store.state.user.token
      }).then(response => {
        console.log(response.data)
        let vm = this
        if (response.data.result === 0) {
          this.$vux.alert.show({
            title: '提示',
            content: response.data.msg,
            onShow () {
            },
            onHide () {
              vm.$router.push(`/classteacher/${vm.id}`)
            }
          })
        } else {
          this.$vux.alert.show({
            title: '异常提示',
            content: response.data.msg,
            onShow () {
            },
            onHide () {
            }
          })
        }
      })
    }
  }
}
</script>

<style type="text/css">
  .vux-search-box{
    position: static!important;
  }
  .sendPapers{
    background-color: #f0f0f4
  }
</style>
