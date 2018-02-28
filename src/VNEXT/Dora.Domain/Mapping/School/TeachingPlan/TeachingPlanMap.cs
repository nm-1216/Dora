namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeachingPlanMap : EntityBaseConfiguration<TeachingPlan>
    {
        public override void ConfigureDerived(EntityTypeBuilder<TeachingPlan> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TeachingPlanId });

            ///Properties
            //builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_TeachingPlan");

            ///Relationships
            builder.HasOne(b => b.Course).WithMany(b => b.TeachingPlans).HasForeignKey(b => b.CourseId);

            builder.HasMany(b => b.Class).WithOne(b => b.TeachingPlan).HasForeignKey(b => b.TeachingPlanId);
            builder.HasMany(b => b.Teacher).WithOne(b => b.TeachingPlan).HasForeignKey(b => b.TeachingPlanId);
            builder.HasMany(b => b.TeachingPlanLogs).WithOne(b => b.TeachingPlan).HasForeignKey(b => b.TeachingPlanId);
            builder.HasMany(b => b.TeachingPlanApprovals).WithOne(b => b.TeachingPlan).HasForeignKey(b => b.TeachingPlanId);
            builder.HasMany(b => b.TeachingPlanDetails).WithOne(b => b.TeachingPlan).HasForeignKey(b => b.TeachingPlanId);

        }
    }
}

