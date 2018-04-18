using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dora.Domain.Entities.School
{
    public enum SchoolUserType
    {
        student,
        teacher,
        other
    }

    public enum ResourceType
    {
        img,
        word,
        excel,
        ppt,
        pdf,
        txt,
        other
    }

    public enum YesOrNo : int
    {
        Yes = 1,
        No = 0
    }
    public enum OrganizationType : int
    {

        教务处 = 1,
        教学部门 = 2,
        院系 = 3
    }

    public enum SectionType : int
    {
        节1_2 = 1,
        节3_4 = 2,
        节5_6 = 3,
        节7_8 = 4,
        节9_10 = 5,
        节11_12 = 6
    }

    public enum Week : int
    {
        星期一 = 1,
        星期二 = 2,
        星期三 = 3,
        星期四 = 4,
        星期五 = 5,
        星期六 = 6,
        星期日 = 0
    }


    public enum ApprovalWorkflowType : int
    {
        /// <summary>
        /// 专业人才培养方案
        /// </summary>
        student = 1,

        /// <summary>
        /// 课程大纲
        /// </summary>
        course = 2
    }

    public enum BaseStatus : int
    {
        /// <summary>
        /// 有效
        /// </summary>
        有效 = 1,

        /// <summary>
        /// 无效
        /// </summary>
        无效 = 0
    }

    public enum TrainingLabDeviceStatus : int
    {
        正常 = 1,
        待维修 = 2,
        停用 = 3,
        报废 = 0
    }

    public enum BasicDataType : int
    {
        ///1=教师职称    2=课程性质    3=课程类别    4=实训方式    5=教育资源平台    6=适用教育层次    7=学制    8=授课方式    9=校区    10=公共教室楼号    11=校内实训基地    12=校内实训中心

        /// <summary>
        /// 教师职称
        /// </summary>
        教师职称 = 1,

        /// <summary>
        /// 课程性质
        /// </summary>
        课程性质 = 2,

        /// <summary>
        /// 课程类别
        /// </summary>
        课程类别 = 3,

        /// <summary>
        /// 实训方式
        /// </summary>
        实训方式 = 4,

        /// <summary>
        /// 教育资源平台
        /// </summary>
        教育资源平台 = 5,

        /// <summary>
        /// 适用教育层次
        /// </summary>
        适用教育层次 = 6,

        /// <summary>
        /// 学制
        /// </summary>
        学制 = 7,

        /// <summary>
        /// 授课方式
        /// </summary>
        授课方式 = 8,

        /// <summary>
        /// 校区
        /// </summary>
        校区 = 9,

        /// <summary>
        /// 公共教室楼号
        /// </summary>
        公共教室楼号 = 10,

        /// <summary>
        /// 校内实训基地
        /// </summary>
        校内实训基地 = 11,

        /// <summary>
        /// 校内实训中心
        /// </summary>
        校内实训中心 = 12
    }

    public enum InfomationType : int
    {
        校级教学通知发布 = 1,
        校级教学管理制度上传 = 2
    }


    public enum PaperQuestionType : int
    {
        单选 = 1,
        多选 = 2,
        判断 = 3,
        打分 = 4,
        主管 = 5
    }
}
