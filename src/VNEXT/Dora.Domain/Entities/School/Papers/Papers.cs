namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;
    using System.Collections.Generic;

    public partial class Papers : BaseEntity
    {
        /// <summary>
        /// 试卷id
        /// </summary>
        public virtual string PaperId { get; set; }
        
        /// <summary>
        /// 试卷题目
        /// </summary>
        public virtual string Title { get; set; }
        
        /// <summary>
        /// 试卷描述
        /// </summary>
        public virtual string Description { get; set; }
        
        /// <summary>
        /// 学生
        /// </summary>
        public virtual string TeacherId { get; set; }   

        /// <summary>
        /// 学生
        /// </summary>
        public virtual Teacher Teacher { get; set; }

        /// <summary>
        /// 题目
        /// </summary>
        public virtual ICollection<PaperQuestions> PaperQuestions { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<PaperAnswers> PaperAnswers { get; set; }        
    }
}