namespace Dora.Domain.Mapping.School
{
    using Dora.Infrastructure.Features.Common;
    using Entities.School;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProfessionalMap : EntityBaseConfiguration<Professional>
    {
        public override void ConfigureDerived(EntityTypeBuilder<Professional> builder)
        {
            ///Primary Key
            builder.HasKey(b => new { b.ProfessionalId });

            ///Properties
            builder.Property(b => b.Name).HasMaxLength(Constants.INT256).IsRequired();


            ///Table & Column Mappings
            builder.ToTable("School_Professional");

            ///Relationships
            builder.HasOne(b => b.Department).WithMany().HasForeignKey(b => b.OrganizationId);
            //builder.HasOne(b => b.Professional).WithMany().HasForeignKey(b => b.SpeID);
            //builder.HasOne(b => b.PersonnelTraining).WithMany().HasForeignKey(b => b.PersonnelTrainingId);
        }
    }
}
