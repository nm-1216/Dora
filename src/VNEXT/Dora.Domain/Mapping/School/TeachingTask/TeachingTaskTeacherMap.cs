namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeachingTaskTeacherMap : EntityBaseConfiguration<TeachingTaskTeacher>
    {
        public override void ConfigureDerived(EntityTypeBuilder<TeachingTaskTeacher> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TeachingTaskId, b.TeacherId });

            ///Properties
            //builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_TeachingTaskTeacher");

            ///Relationships
            builder.HasOne(b => b.Teacher).WithMany().HasForeignKey(b => b.TeacherId);

        }
    }
}

