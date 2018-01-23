namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SyllabusTeacherMap : EntityBaseConfiguration<SyllabusTeacher>
    {
        public override void ConfigureDerived(EntityTypeBuilder<SyllabusTeacher> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TeacherId, b.SyllabusId });

            ///Table & Column Mappings
            builder.ToTable("School_SyllabusTeacher");

            /////Relationships
            builder.HasOne(b => b.Teacher).WithMany().HasForeignKey(b => b.TeacherId);
        }
    }
}