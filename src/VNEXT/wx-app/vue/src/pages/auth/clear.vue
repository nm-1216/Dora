<template>
<div>
Clear
</div>
</template>

<script>
import { mapActions } from 'vuex'
import { USER_SIGNOUT } from 'src/store/user'
export default {
  created () {
    this.USER_SIGNOUT()
    this.$router.replace({ path: '/' })
  },
  methods: {
    ...mapActions([USER_SIGNOUT])
  }
}
</script>
