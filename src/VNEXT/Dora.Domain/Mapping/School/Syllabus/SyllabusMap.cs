namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SyllabusMap : EntityBaseConfiguration<Syllabus>
    {
        public override void ConfigureDerived(EntityTypeBuilder<Syllabus> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.SyllabusId });

            ///Properties
            //builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_Syllabus");

            ///Relationships
            builder.HasOne(b => b.Course).WithMany(b=>b.Syllabuss).HasForeignKey(b => b.CourseId);

            builder.HasMany(b => b.SyllabusBooks).WithOne(b => b.Syllabus).HasForeignKey(b => b.SyllabusId);
            builder.HasMany(b => b.SyllabusApprovals).WithOne(b => b.Syllabus).HasForeignKey(b => b.SyllabusId);
            builder.HasMany(b => b.SyllabusLogs).WithOne(b => b.Syllabus).HasForeignKey(b => b.SyllabusId);
            builder.HasMany(b => b.SyllabusPeriods).WithOne(b => b.Syllabus).HasForeignKey(b => b.SyllabusId);

        }
    }
}

