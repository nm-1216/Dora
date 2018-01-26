using Dora.Domain.Entities.School;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dora.ViewModels
{
    public class PersonnelTrainingViewModel
    {

        /// <summary>
        /// Gets or sets 主键 
        /// </summary>
        public string PersonnelTrainingId { get; set; }

        /// <summary>
        /// Gets or sets 所属专业(组织架构表) 
        /// </summary>
        [Display(Name = "专业")]
        [Required]
        public string OrganizationId { get; set; }



        /// <summary>
        /// Gets or sets 学制 
        /// </summary>
        [Display(Name = "学制")]
        public string LenOfSch { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 培养目标 
        /// </summary>
        public string TraObj { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 毕业要求 
        /// </summary>
        public string GraReq { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 就业岗位 
        /// </summary>
        public string Post { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 课程设置和教学基本要求 
        /// </summary>
        public string BasReq { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 实施意见与说明 
        /// </summary>
        public string OpiExp { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 招生对象 
        /// </summary>
        public string EnrTar { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 录取年份 
        /// </summary>
        [Display(Name = "录取年份")]
        public string Year { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 使用状态 
        /// </summary>
        public BaseStatus Status { get; set; }


        /// <summary>
        /// Gets or sets 提交时间 
        /// </summary>
        public DateTime? SubTime { get; set; }


        /// <summary>
        /// Gets or sets 培养方案文件路径 
        /// </summary>
        [Display(Name = "培养方案")]
        public IFormFile CulProPath { get; set; }


        /// <summary>
        /// Gets or sets 审议会议纪要路径 
        /// </summary>
        [Display(Name = "审议会议纪要")]
        public IFormFile MeeSumPath { get; set; }


        /// <summary>
        /// Gets or sets 提交状态 
        /// </summary>
        public int? SubSta { get; set; }


        /// <summary>
        /// Gets or sets 审核次序 
        /// </summary>
        public int? AudOrd { get; set; }


        /// <summary>
        /// Gets or sets 审核名称 
        /// </summary>
        public string AudName { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 审核结果 
        /// </summary>
        public int? AudRes { get; set; }
    }
}
