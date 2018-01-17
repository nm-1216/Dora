namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Term : BaseEntity
    {
        [Display(Name = "学期")]
        public virtual string TermId { get; set; }

        [Display(Name = "开始时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public virtual DateTime StartTime { get; set; } = DateTime.Now;

        [Display(Name = "结束时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public virtual DateTime EndTime { get; set; } = DateTime.Now;

        [Display(Name = "默认学期")]
        public virtual bool IsDefault { get; set; } = false;
    }
}
