using System.Collections.Generic;

namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;


    public partial class PaperAnswers : BaseEntity
    {
        /// <summary>
        /// 答卷
        /// </summary>
        public virtual string PaperAnswerId { get; set; }
        
        /// <summary>
        /// 试卷
        /// </summary>
        public virtual string PaperId { get; set; }

        /// <summary>
        /// 学生
        /// </summary>
        public virtual string StudentId { get; set; }   

        /// <summary>
        /// 学生
        /// </summary>
        public virtual Student Student { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<PaperAnswerDetails> PaperAnswerDetails { get; set; }
    }
}