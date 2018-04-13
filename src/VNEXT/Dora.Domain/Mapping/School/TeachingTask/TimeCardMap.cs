namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TimeCardMap : EntityBaseConfiguration<TimeCard>
    {
        public override void ConfigureDerived(EntityTypeBuilder<TimeCard> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TimeCardId });

            ///Table & Column Mappings
            builder.ToTable("School_TimeCards");

            ///Relationships
            //builder.HasOne(b => b.Class).WithMany().HasForeignKey(b => b.ClassId);
        }
    }
}

