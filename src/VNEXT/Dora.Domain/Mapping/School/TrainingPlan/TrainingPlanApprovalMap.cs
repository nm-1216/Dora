namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrainingPlanApprovalMap : EntityBaseConfiguration<TrainingPlanApproval>
    {
        public override void ConfigureDerived(EntityTypeBuilder<TrainingPlanApproval> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TrainingPlanApprovalId });

            ///Properties
            //builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_TrainingPlanApproval");

            ///Relationships
            //builder.HasOne(b => b.Course).WithMany(b => b.TeachingPlans).HasForeignKey(b => b.CourseId);
            //builder.HasOne(b => b.Class).WithMany().HasForeignKey(b => b.ClassId);
            //builder.HasOne(b => b.Teacher).WithMany().HasForeignKey(b => b.TeacherId);

            //builder.HasMany(b => b.TeachingPlanLogs).WithOne(b => b.TeachingPlan).HasForeignKey(b => b.TeachingPlanId);
            //builder.HasMany(b => b.TeachingPlanApprovals).WithOne(b => b.TeachingPlan).HasForeignKey(b => b.TeachingPlanId);
            //builder.HasMany(b => b.TeachingPlanDetails).WithOne(b => b.TeachingPlan).HasForeignKey(b => b.TeachingPlanId);

        }
    }
}

