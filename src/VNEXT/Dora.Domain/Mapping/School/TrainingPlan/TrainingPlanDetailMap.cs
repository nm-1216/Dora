namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrainingPlanDetailMap : EntityBaseConfiguration<TrainingPlanDetail>
    {
        public override void ConfigureDerived(EntityTypeBuilder<TrainingPlanDetail> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TrainingPlanDetailId });

            ///Properties
            //builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_TrainingPlanDetail");

            ///Relationships
            builder.HasOne(b => b.TrainingLabDevice).WithMany().HasForeignKey(b => b.TrainingLabDeviceId);
            builder.HasOne(b => b.TrainingProject).WithMany().HasForeignKey(b => b.TrainingProjectId);
            builder.HasOne(b => b.Teacher).WithMany().HasForeignKey(b => b.TeacherId);
            

        }
    }
}

