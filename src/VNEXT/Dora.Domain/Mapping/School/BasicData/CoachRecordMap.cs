namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CoachRecordMap : EntityBaseConfiguration<CoachRecord>
    {
        public override void ConfigureDerived(EntityTypeBuilder<CoachRecord> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.CoachRecordId });

            ///Properties
            builder.Property(b => b.Date).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.Time).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.Addr).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.Content).HasMaxLength(Constants.INT256).IsRequired();
            

            ///Table & Column Mappings
            builder.ToTable("School_CoachRecord");

            ///Relationships
            builder.HasOne(b => b.Teacher).WithMany().HasForeignKey(b => b.TeacherId);
        }
    }
}
