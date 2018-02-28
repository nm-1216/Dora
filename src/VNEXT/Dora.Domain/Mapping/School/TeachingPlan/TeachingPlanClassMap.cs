namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeachingPlanClassMap : EntityBaseConfiguration<TeachingPlanClass>
    {
        public override void ConfigureDerived(EntityTypeBuilder<TeachingPlanClass> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TeachingPlanId, b.ClassId });

            ///Properties
            //builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_TeachingPlanClass");

            ///Relationships
            builder.HasOne(b => b.Class).WithMany().HasForeignKey(b => b.ClassId);

        }
    }
}

