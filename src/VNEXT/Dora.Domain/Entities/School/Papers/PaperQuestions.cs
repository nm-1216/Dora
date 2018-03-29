using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;


    public partial class PaperQuestions : BaseEntity
    {
        /// <summary>
        /// 主见
        /// </summary>
        public virtual string PaperQuestionId { get; set; }
        
        public virtual string PaperId { get; set; }

        /// <summary>
        /// 题号
        /// </summary>
        public virtual int Code { get; set; } = 1;

        /// <summary>
        /// 题目
        /// </summary>
        public virtual string Text { get; set; }

        /// <summary>
        /// 试题类型
        /// </summary>
        public virtual PaperQuestionType QType { get; set; }

        /// <summary>
        /// 分值
        /// </summary>
        public virtual int Value { get; set; }

        /// <summary>
        /// 正确答案
        /// </summary>
        public virtual string Answer { get; set; }

        /// <summary>
        /// 选项1
        /// </summary>
        public virtual string Option1 { get; set; }
        
        /// <summary>
        /// 选项2
        /// </summary>
        public virtual string Option2 { get; set; }
        
        /// <summary>
        /// 选项3
        /// </summary>
        public virtual string Option3 { get; set; }
        
        /// <summary>
        /// 选项4
        /// </summary>
        public virtual string Option4 { get; set; }
        
        /// <summary>
        /// 选项5
        /// </summary>
        public virtual string Option5 { get; set; }
        
        /// <summary>
        /// 选项6
        /// </summary>
        public virtual string Option6 { get; set; }
        
        [NotMapped]
        public virtual List<string> UserAnswer { get; set; }=new List<string>();
        
        /// <summary>
        /// 答案
        /// </summary>
        public virtual ICollection<PaperAnswerDetails> PaperAnswerDetails { get; set; }

    }
}