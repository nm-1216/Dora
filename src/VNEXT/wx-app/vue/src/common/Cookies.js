export default {
  setCookie: function (key, value, expire) {
    var exp = new Date()
    exp.setTime(exp.getTime() + expire)
    document.cookie = key + '=' + escape(value) + ';expires=' + exp.toGMTString()
  },
  getCookie: function (key) {
    console.log(document.cookie)
    var reg = new RegExp('(^| )' + key + '=([^;]*)(;|$)')
    var arr = document.cookie.match(reg)
    if (arr) {
      return unescape(arr[2])
    } else {
      return null
    }
  }
}
