namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrainingLabMap : EntityBaseConfiguration<TrainingLab>
    {
        public override void ConfigureDerived(EntityTypeBuilder<TrainingLab> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TrainingLabId });

            ///Properties
            builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.School).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.BuildingNo).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.RoomNo).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.Base).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.Center).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_TrainingLab");

            /////Relationships
            //builder.HasOne(b => b.Department).WithMany().HasForeignKey(b => b.DepID);
            //builder.HasOne(b => b.Professional).WithMany().HasForeignKey(b => b.SpeID);
            //builder.HasOne(b => b.PersonnelTraining).WithMany().HasForeignKey(b => b.PersonnelTrainingId);
        }
    }
}
