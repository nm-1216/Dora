namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeachingTaskClassMap : EntityBaseConfiguration<TeachingTaskClass>
    {
        public override void ConfigureDerived(EntityTypeBuilder<TeachingTaskClass> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TeachingTaskId, b.ClassId });

            ///Properties
            //builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_TeachingTaskClass");

            ///Relationships
            builder.HasOne(b => b.Class).WithMany().HasForeignKey(b => b.ClassId);

        }
    }
}

