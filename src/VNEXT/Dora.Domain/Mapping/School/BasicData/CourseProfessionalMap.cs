namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CourseProfessionalMap : EntityBaseConfiguration<CourseProfessional>
    {
        public override void ConfigureDerived(EntityTypeBuilder<CourseProfessional> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.CourseId,b.ProfessionalId });

            ///Properties
           

            ///Table & Column Mappings
            builder.ToTable("School_CourseProfessional");

            ///Relationships
            builder.HasOne(b => b.Course).WithMany(b=>b.CourseProfessionals).HasForeignKey(b => b.CourseId);
            builder.HasOne(b => b.Professional).WithMany(b => b.CourseProfessionals).HasForeignKey(b => b.ProfessionalId);
            //builder.HasOne(b => b.PersonnelTraining).WithMany().HasForeignKey(b => b.PersonnelTrainingId);
        }
    }
}
