namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;

    public class TeachingTaskTeacher : BaseEntity
    {
        /// <summary>
        /// Gets or sets 此授课计划对应的维护人员
        /// </summary>
        public virtual string TeacherId { get; set; }

        /// <summary>
        /// Gets or sets
        /// </summary>
        public virtual string TeachingTaskId { get; set; }

        /// <summary>
        /// Gets or sets
        /// </summary>
        public virtual TeachingTask TeachingTask { get; set; }

        /// <summary>
        /// Gets or sets
        /// </summary>
        public virtual Teacher Teacher { get; set; }


    }
}
