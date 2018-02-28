namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeachingPlanTeacherMap : EntityBaseConfiguration<TeachingPlanTeacher>
    {
        public override void ConfigureDerived(EntityTypeBuilder<TeachingPlanTeacher> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.TeachingPlanId, b.TeacherId });

            ///Properties
            //builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_TeachingPlanTeacher");

            ///Relationships
            builder.HasOne(b => b.Teacher).WithMany().HasForeignKey(b => b.TeacherId);

        }
    }
}

