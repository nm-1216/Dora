namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StudentMap : EntityBaseConfiguration<Student>
    {
        public override void ConfigureDerived(EntityTypeBuilder<Student> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.StudentId });

            ///Properties
            builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();

            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_Student");

            ///Relationships
            builder.HasOne(b => b.Class).WithMany(b=>b.Students).HasForeignKey(b => b.ClassId);
            builder.HasOne(b => b.SchoolUser).WithOne(b => b.Student).HasForeignKey<Student>(b => b.StudentId);
        }
    }
}
