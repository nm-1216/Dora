namespace Dora.Domain.Mapping.System
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


            ///Table & Column Mappings
            builder.ToTable("School_Course");
            builder.Property(b => b.CourseId).HasColumnName("CourseId");
            builder.Property(b => b.Name).HasColumnName("Name");


            ///Relationships
            //builder.HasMany(b => b.Classes).WithOne(b => b.Course).HasForeignKey(b => b.CourseId);
        }
    }
}
