namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;


    public partial class PaperAnswerDetails : BaseEntity
    {

        /// <summary>
        /// 题目
        /// </summary>
        public virtual string PaperQuestionId { get; set; }


        /// <summary>
        /// 答卷
        /// </summary>
        public virtual string PaperAnswerId { get; set; }
        
        
        /// <summary>
        /// 答案
        /// </summary>
        public virtual string Value { get; set; }
  
        
        /// <summary>
        /// 是否正确
        /// </summary>
        public virtual bool IsRight { get; set; }
        
    }
}