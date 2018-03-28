export function formatDate (date2, fmt) {
  let shiqu = (new Date().getTimezoneOffset()) / (-60)
  var a = shiqu - 8
  date2 = date2 + a * 60 * 60 * 1000
  // let conversionTime = date2.match(/\d+/g);
  // // 强制减去 28800000 毫秒； 如果有前导0（即如果你以ISO格式表示日期），就假设用户处于格林尼治国际标准时的时区，所以返回8点0分。但是，ES6改变了这种做法，规定凡是没有指定时区的日期字符串，一律认定用户处于本地时区。
  // let unixTime = new Date(conversionTime[0] + '-' + conversionTime[1] + '-' + conversionTime[2] + ' ' + conversionTime[3] + ':' + conversionTime[4] + ':' + conversionTime[5]).getTime();
  let date = new Date(date2)
  // if (/(y+)/.test(fmt)) {
  //  fmt = fmt.replace(RegExp.$1, (date.getFullYear() + '').substr(4 - RegExp.$1.length))
  // }
  let o = {
    'M+': date.getMonth() + 1,
    'd+': date.getDate(),
    'h+': date.getHours() % 12 === 0 ? 12 : date.getHours() % 12,
    'H+': date.getHours(),
    'm+': date.getMinutes(),
    's+': date.getSeconds(),
    'S': date.getMilliseconds()
  }
  let week = {
    '0': '日',
    '1': '一',
    '2': '二',
    '3': '三',
    '4': '四',
    '5': '五',
    '6': '六'
  }
  let quarter = {
    '1': '一',
    '2': '二',
    '3': '三',
    '4': '四'
  }

  if (/(y+)/.test(fmt)) {
    fmt = fmt.replace(RegExp.$1, (date.getFullYear() + '').substr(4 - RegExp.$1.length))
  }
  if (/(E+)/.test(fmt)) {
    fmt = fmt.replace(RegExp.$1, ((RegExp.$1.length > 1) ? (RegExp.$1.length > 2 ? '星期' : '周') : '') + week[date.getDay() + ''])
  }
  if (/(q+)/.test(fmt)) {
    fmt = fmt.replace(RegExp.$1, ((RegExp.$1.length > 1) ? '第' : '') + quarter[Math.floor((date.getMonth() + 3) / 3) + ''] + '季度')
  }
  for (let k in o) {
    if (new RegExp(`(${k})`).test(fmt)) {
      let str = o[k] + ''
      fmt = fmt.replace(RegExp.$1, (RegExp.$1.length === 1) ? str : padLeftZero(str))
    }
  }
  return fmt
}

function padLeftZero (str) {
  return ('00' + str).substr(str.length)
}
