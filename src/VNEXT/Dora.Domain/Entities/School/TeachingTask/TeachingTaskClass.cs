namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;

    public class TeachingTaskClass : BaseEntity
    {
        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual string CourseId { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual string TeachingTaskId { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual Course Course { get; set; }

        /// <summary>
        /// Gets or sets  
        /// </summary>
        public virtual TeachingTask TeachingTask { get; set; }

    }
}
