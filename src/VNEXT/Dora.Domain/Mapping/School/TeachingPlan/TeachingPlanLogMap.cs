namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeachingPlanLogMap : EntityBaseConfiguration<TeachingPlanLog>
    {
        public override void ConfigureDerived(EntityTypeBuilder<TeachingPlanLog> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TeachingPlanLogId });

            ///Properties
            //builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_TeachingPlanLog");

            ///Relationships
           

        }
    }
}

