namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeacherMap : EntityBaseConfiguration<Teacher>
    {
        public override void ConfigureDerived(EntityTypeBuilder<Teacher> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TeacherId });

            ///Properties
            builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            builder.Property(b => b.JobTit).HasMaxLength(Constants.INT256).IsRequired();

            ///Table & Column Mappings
            builder.ToTable("School_Teacher");

            ///Relationships
            builder.HasOne(b => b.Department).WithMany().HasForeignKey(b => b.OrganizationId);
            builder.HasOne(b => b.SchoolUser).WithOne(b=>b.Teacher).HasForeignKey<Teacher>(b => b.TeacherId);
        }
    }
}
