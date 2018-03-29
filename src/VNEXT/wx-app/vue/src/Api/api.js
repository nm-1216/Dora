import axios from 'axios'
const Qs = require('qs')

console.log(process.env.NODE_ENV)
var base = ''
if (process.env.NODE_ENV === 'development') {
  console.log('in development')
  base = 'http://localhost:5000/WxApi'
} else {
  console.log('in production')
  base = 'http://wx.nieba.cn/WxApi'
}

export const GetCourseList = params => { return axios.get(`${base}/GetCourseList`, {params: params}) }
export const CreateCourse = params => { return axios.post(`${base}/CreateCourse`, Qs.stringify(params)) }
export const GetSpecialty = params => { return axios.get(`${base}/GetSpecialty`, { params: params }) }
export const Register = params => { return axios.post(`${base}/Register`, Qs.stringify(params)) }
export const GetUserInfo = params => { return axios.get(`${base}/GetUserInfo`, { params: params }) }
export const EditUserInfo = params => { return axios.post(`${base}/EditUserInfo`, Qs.stringify(params)) }
export const GetActivity = params => { return axios.get(`${base}/GetActivity`, { params: params }) }
export const GetActivityDetails = params => { return axios.get(`${base}/GetActivityDetails`, { params: params }) }
export const GetClassCourse = params => { return axios.get(`${base}/GetClassCourse`, { params: params }) }
export const GetNotice = params => { return axios.get(`${base}/GetNotice`, { params: params }) }
export const GetPapers = params => { return axios.get(`${base}/GetPapers`, { params: params }) }
export const PushAnswer = params => { return axios.post(`${base}/PushAnswer`, Qs.stringify(params)) }
export const DelLearnLog = params => { return axios.get(`${base}/DelLearnLog`, { params: params }) }
export const GetPaperTongJi = params => { return axios.get(`${base}/GetPaperTongJi`, { params: params }) }
export const SendNotice = params => { return axios.post(`${base}/SendNotice`, Qs.stringify(params)) }
export const GetCoursewareList = params => { return axios.post(`${base}/GetCoursewareList`, Qs.stringify(params)) }
export const SendPapers = params => { return axios.post(`${base}/SendPapers`, Qs.stringify(params)) }
export const SendCoursewaree = params => { return axios.post(`${base}/SendCoursewaree`, Qs.stringify(params)) }
export const GetPapersList = params => { return axios.post(`${base}/GetPapersList`, Qs.stringify(params)) }
