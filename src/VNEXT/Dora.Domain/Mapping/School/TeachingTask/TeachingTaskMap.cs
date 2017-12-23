namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeachingTaskMap : EntityBaseConfiguration<TeachingTask>
    {
        public override void ConfigureDerived(EntityTypeBuilder<TeachingTask> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TeachingTaskId });

            ///Properties
            //builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_TeachingTask");

            ///Relationships
            builder.HasOne(b => b.Course).WithMany().HasForeignKey(b => b.CourseId);
            //builder.HasOne(b => b.Class).WithMany().HasForeignKey(b => b.ClassId);
            builder.HasOne(b => b.Teacher).WithMany().HasForeignKey(b => b.TeacherId);

            builder.HasMany(b => b.TeachingTaskDetails).WithOne(b=>b.TeachingTask).HasForeignKey(b => b.TeachingTaskId);

        }
    }
}

