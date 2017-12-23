namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrainingLabDeviceMap : EntityBaseConfiguration<TrainingLabDevice>
    {
        public override void ConfigureDerived(EntityTypeBuilder<TrainingLabDevice> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TrainingLabDeviceId });

            ///Properties
            builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_TrainingLabDevice");

            ///Relationships
            builder.HasOne(b => b.TrainingLab).WithMany(b=> b.TrainingLabDevice).HasForeignKey(b => b.TrainingLabId);
        }
    }
}
