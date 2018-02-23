/*
var base = 'http://localhost:50772/Api'
var base = 'http://116.62.235.138:81/Api'
*/
import axios from 'axios'
const Qs = require('qs')

console.log(process.env.NODE_ENV)
var base = ''
if (process.env.NODE_ENV === 'development') {
  console.log('in development')
  base = 'https://localhost:44314/WxApi'
} else {
  console.log('in production')
  base = 'http://rochewx.wojilu.com/WxApi'
}

export const GetCourseList = params => { return axios.get(`${base}/GetCourseList`, {params: params}) }
export const CreateCourse = params => { return axios.post(`${base}/CreateCourse`, Qs.stringify(params)) }

