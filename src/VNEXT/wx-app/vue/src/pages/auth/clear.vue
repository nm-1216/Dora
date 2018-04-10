<template>
<div>
  Clear
</div>
</template>

<script>
import { mapActions } from 'vuex'
import {  USER_SIGNIN } from 'src/store/user'
export default {
  created () {
    
  },
  methods: {
    ...mapActions([USER_SIGNIN]),
  }
}
</script>
