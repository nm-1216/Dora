namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CourseMap : EntityBaseConfiguration<Course>
    {
        public override void ConfigureDerived(EntityTypeBuilder<Course> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.CourseId });

            ///Properties
            builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.AppLev).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.CouNat).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.CouType).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.CouAbs).HasMaxLength(Constants.INT256).IsRequired();

            ///Table & Column Mappings
            builder.ToTable("School_Course");

            ///Relationships
            builder.HasOne(b => b.Department).WithMany().HasForeignKey(b => b.OrganizationId);
        }
    }
}
