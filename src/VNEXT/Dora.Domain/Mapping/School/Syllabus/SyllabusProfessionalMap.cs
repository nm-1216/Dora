namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SyllabusProfessionalMap : EntityBaseConfiguration<SyllabusProfessional>
    {
        public override void ConfigureDerived(EntityTypeBuilder<SyllabusProfessional> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.ProfessionalId, b.SyllabusId });

            ///Properties
            //builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();
            //builder.Property(b => b.InviteCode).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_SyllabusProfessional");

            /////Relationships
            builder.HasOne(b => b.Professional).WithMany().HasForeignKey(b => b.ProfessionalId);
            //builder.HasOne(b => b.Professional).WithMany().HasForeignKey(b => b.SpeID);
            //builder.HasOne(b => b.PersonnelTraining).WithMany().HasForeignKey(b => b.PersonnelTrainingId);
        }
    }
}