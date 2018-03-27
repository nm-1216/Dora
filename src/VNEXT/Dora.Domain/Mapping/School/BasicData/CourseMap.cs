namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CourseMap : EntityBaseConfiguration<Course1>
    {
        public override void ConfigureDerived(EntityTypeBuilder<Course1> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.CourseId });

            ///Properties
            builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.AppLev).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.Nature).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.Type).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.Discription).HasMaxLength(Constants.INT4000).IsRequired();

            ///Table & Column Mappings
            builder.ToTable("School_Course1");

            ///Relationships
            builder.HasOne(b => b.Department).WithMany().HasForeignKey(b => b.OrganizationId);
            builder.HasMany(b => b.TeachingPlans).WithOne(b => b.Course).HasForeignKey(b => b.CourseId);


        }
    }
}
