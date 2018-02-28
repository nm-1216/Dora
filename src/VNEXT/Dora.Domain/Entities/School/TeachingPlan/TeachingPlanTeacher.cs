namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;

    public class TeachingPlanTeacher : BaseEntity
    {
        /// <summary>
        /// Gets or sets 此授课计划对应的维护人员
        /// </summary>
        public virtual string TeacherId { get; set; }

        /// <summary>
        /// Gets or sets
        /// </summary>
        public virtual string TeachingPlanId { get; set; }

        /// <summary>
        /// Gets or sets
        /// </summary>
        public virtual TeachingPlan TeachingPlan { get; set; }

        /// <summary>
        /// Gets or sets
        /// </summary>
        public virtual Teacher Teacher { get; set; }


    }
}
