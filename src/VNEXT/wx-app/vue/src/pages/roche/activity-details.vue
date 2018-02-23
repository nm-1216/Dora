<template>
<div class="activity-details">
  <div style="padding:10px 8px;">
    <img :src="this.global.DOMAIN +this.activity.img" v-show="this.activity.img" style="width:100%">
    <h2>{{this.activity.title}}</h2>
    <divider>-</divider>
    <p><i class="orange glyphicon glyphicon-time"></i> 时间：{{activity.activityTime}}</p>
    <p><i class="orange glyphicon glyphicon-map-marker"></i> 地点：{{activity.site}}</p>
    <p><i class="orange glyphicon glyphicon-user"></i> 报名人数：{{activityEnrollUsersNumber}} / {{activity.maxUser}}</p>
    <p>主办方：{{activity.sponsor}}</p>
    <p>联系电话：{{activity.tel}}</p>
    <h3>内容介绍</h3>
    <div v-html="activity.content"></div>
    <div style="padding:10px 0">
      <div v-for="(item,index) in activity.agendas" :key="index" style="background-color:#f3f4f2;margin-bottom:10px;padding:15px;">
        <h3>议程{{numberConvertToUppercase(index+1)}}: {{item.title}}</h3>
        <p><i class="red glyphicon glyphicon-time"></i> 时间：{{item.agendaTime}}</p>
        <p><i class="red glyphicon glyphicon-map-marker"></i> 地点：{{item.site}}</p>
        <div v-html="item.content"></div>
        <p style="text-align:right"><a href="http://www.baidu.com">详情>></a></p>
      </div>
    </div>
  </div>

</div>
</template>

<script>
import {
  GetActivityDetails
} from 'src/Api/api'
import {
  XButton,
  Box,
  GroupTitle,
  Group,
  Flexbox,
  FlexboxItem,
  Divider,
  Panel
} from 'vux'

export default {
  name: 'activity-details',
  components: {
    XButton,
    Box,
    GroupTitle,
    Group,
    Flexbox,
    FlexboxItem,
    Divider,
    Panel
  },
  data () {
    return {
      activity: {},
      activityEnrollUsersNumber: 0
    }
  },
  created () {
    this.GetList()
  },
  methods: {
    GetList () {
      GetActivityDetails({
        openid: this.$store.state.user.token,
        id: this.$route.params.id
      }).then(response => {
        console.log('GetActivity', response.data)
        this.activity = response.data.data
        this.activityEnrollUsersNumber = this.activity.activityEnrollUsers.length
      })
    },
    GoActivityDetails (id) {
      this.$router.push(`/activitydetails/${id}`)
    },
    numberConvertToUppercase (num) {
      num = Number(num)
      var upperCaseNumber = ['零', '一', '二', '三', '四', '五', '六', '七', '八', '九', '十', '百', '千', '万', '亿']
      var length = String(num).length
      if (length === 1) {
        return upperCaseNumber[num]
      } else if (length === 2) {
        if (num === 10) {
          return upperCaseNumber[num]
        } else if (num > 10 && num < 20) {
          return '十' + upperCaseNumber[String(num).charAt(1)]
        } else {
          return upperCaseNumber[String(num).charAt(0)] + '十' + upperCaseNumber[String(num).charAt(1)].replace('零', '')
        }
      }
    }
  }
}
</script>
<style lang="less">
@import '~vux/src/styles/1px.less';
/* @import '../../assets/Glyphicons/Glyphicons.css'; */

.activity-details {
    min-height: 100%;
}
.activity-details > div {
    background-color: #fff;
    min-height: 100%;
}
.orange{
  color:orange
}
.red{
  color:red
}
</style>
