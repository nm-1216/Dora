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
export const GetSpecialty = params => { return axios.get(`${base}/GetSpecialty`, { params: params }) }
export const Register = params => { return axios.post(`${base}/Register`, Qs.stringify(params)) }
export const GetUserInfo = params => { return axios.get(`${base}/GetUserInfo`, { params: params }) }
export const EditUserInfo = params => { return axios.post(`${base}/EditUserInfo`, Qs.stringify(params)) }
export const GetActivity = params => { return axios.get(`${base}/GetActivity`, { params: params }) }
export const GetActivityDetails = params => { return axios.get(`${base}/GetActivityDetails`, { params: params }) }
