namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrainingPlanLogMap : EntityBaseConfiguration<TrainingPlanLog>
    {
        public override void ConfigureDerived(EntityTypeBuilder<TrainingPlanLog> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TrainingPlanLogId });

            ///Properties
            //builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_TrainingPlanLog");

            ///Relationships
            builder.HasOne(b => b.TrainingLab).WithMany().HasForeignKey(b => b.TrainingLabId);
            builder.HasOne(b => b.TrainingLabDevice).WithMany().HasForeignKey(b => b.TrainingLabDeviceId);
            builder.HasOne(b => b.Teacher).WithMany().HasForeignKey(b => b.TeacherId);
            

        }
    }
}

