namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;

    public class TeachingPlanClass : BaseEntity
    {
        /// <summary>
        /// Gets or sets 
        /// </summary>
        public string ClassId { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual string TeachingPlanId { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual Class Class { get; set; }

        /// <summary>
        /// Gets or sets  
        /// </summary>
        public virtual TeachingPlan TeachingPlan { get; set; }

    }
}
