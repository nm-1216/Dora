namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrainingPlanMap : EntityBaseConfiguration<TrainingPlan>
    {
        public override void ConfigureDerived(EntityTypeBuilder<TrainingPlan> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TrainingPlanId });

            ///Properties
            //builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_TrainingPlan");

            ///Relationships
            builder.HasOne(b => b.Course).WithMany().HasForeignKey(b => b.CourseId);
            builder.HasOne(b => b.Class).WithMany().HasForeignKey(b => b.ClassId);
            builder.HasOne(b => b.Teacher).WithMany().HasForeignKey(b => b.TeacherId);


            builder.HasMany(b => b.TrainingPlanLogs).WithOne(b => b.TrainingPlan).HasForeignKey(b => b.TrainingPlanId);
            builder.HasMany(b => b.TrainingPlanDetails).WithOne(b => b.TrainingPlan).HasForeignKey(b => b.TrainingPlanId);
            builder.HasMany(b => b.TrainingPlanApprovals).WithOne(b => b.TrainingPlan).HasForeignKey(b => b.TrainingPlanId);

        }
    }
}

